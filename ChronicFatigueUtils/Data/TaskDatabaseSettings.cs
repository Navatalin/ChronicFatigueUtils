
namespace ChronicFatigueUtils.Data;
public class TaskDatabaseSettings : ITaskDatabaseSettings
{
    public string TaskCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}
public interface ITaskDatabaseSettings
{
    string TaskCollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}
