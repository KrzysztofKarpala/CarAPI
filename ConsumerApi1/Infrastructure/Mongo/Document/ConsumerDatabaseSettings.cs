namespace ConsumerApi1.Infrastructure.Mongo.Document
{
    public class ConsumerDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string Consumer1CollectionName { get; set; } = null!;
    }
}
