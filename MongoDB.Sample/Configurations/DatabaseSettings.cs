namespace MongoDB.Sample.Configurations
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string MongoDBCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IDatabaseSettings
    {
        public string MongoDBCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
