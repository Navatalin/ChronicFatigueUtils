
using ChronicFatigueUtils.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ChronicFatigueUtils.Services;
public class TaskService
{
    private readonly IMongoCollection<TaskItem> _tasks;

    public TaskService(ITaskDatabaseSettings settings)
    {
        if(string.IsNullOrWhiteSpace(settings.DBUSER) || string.IsNullOrWhiteSpace(settings.DBPASS)){
            Console.WriteLine("Error in getting DB Credentials");
            throw new Exception("Unable to connect to database due to missing credentials");
        }
        var credential = MongoCredential.CreateCredential(settings.DatabaseName,settings.DBUSER, settings.DBPASS);
        var mongoSettings = new MongoClientSettings()
        {
            Credential = credential,
            Server = new MongoServerAddress(settings.Server, settings.ServerPort)
        };

        var client = new MongoClient(mongoSettings);

        var database = client.GetDatabase(settings.DatabaseName);

        _tasks = database.GetCollection<TaskItem>("Tasks");
    }

    public List<TaskItem> Get() => _tasks.Find(task => true).ToList();

    public List<TaskItem>? Get(DateTime? date)
    {
        try
        {
            if (date != null)
            {
                var start = date.Value.Date;
                var end = date.Value.Date.AddDays(1);

                var dateQuery = new BsonDocument
            {
                {
                    "CreatedOn", new BsonDocument
                    {
                        {"$gt", start },
                        {"$lt", end }
                    }
                }
            };
                var matchedDocuments = _tasks.Find(dateQuery).ToList();
                return matchedDocuments;

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            return null;
        }

        return null;
        
    }

    public TaskItem Get(ObjectId id) => _tasks.Find<TaskItem>(task => task.Id == id).FirstOrDefault();

    public TaskItem Create(TaskItem task)
    {
        _tasks.InsertOne(task);
        return task;
    }

    public void Update(TaskItem taskIn)
    {
        _tasks.ReplaceOne(task => task.Id == taskIn.Id, taskIn);
    }

    public void Remove(TaskItem taskIn)
    {
        _tasks.DeleteOne(task => task.Id == taskIn.Id);
    }

    public void Remove(ObjectId id)
    {
        _tasks.DeleteOne(task => task.Id == id);
    }

}
