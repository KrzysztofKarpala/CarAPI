namespace CarAPI.Infrastructure.Mongo.Document
{
    public class CarDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string CarCollectionName { get; set; } = null!;
    }
}
