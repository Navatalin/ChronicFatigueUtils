
using static ChronicFatigueUtils.Data.TaskEnums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChronicFatigueUtils.Data;
public class TaskItem
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id {  get; set; }
    public DateTime CreatedOn { get; set; }
    public string? TaskName { get; set; }
    public int TimeTaken { get; set; }
    public FeelAfter FeelAfter {  get; set; }
    public Recover Recovery {  get; set; }
    
    public TaskItem()
    {
        this.Id = ObjectId.GenerateNewId();
    }
}
