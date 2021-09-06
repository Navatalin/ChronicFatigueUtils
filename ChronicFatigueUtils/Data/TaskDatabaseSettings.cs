
namespace ChronicFatigueUtils.Data;
public class TaskDatabaseSettings : ITaskDatabaseSettings
{
    public string TaskCollectionName { get; set; }
    public string Server { get; set; }
    public int ServerPort { get; set; }
    public string DatabaseName { get; set; }
    public string DBUSER { get; set; }
    public string DBPASS {  get; set; }
}
public interface ITaskDatabaseSettings
{
    string TaskCollectionName { get; set; }
    string Server { get; set; }
    int ServerPort { get; set; }
    string DatabaseName { get; set; }
    string DBUSER {  get; set; }
    string DBPASS {  get; set; }
}
