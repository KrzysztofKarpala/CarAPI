namespace ConsumerApi2.Infrastructure.Mongo.Document
{
    public class ConsumerDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string Consumer2CollectionName { get; set; } = null!;
    }
}