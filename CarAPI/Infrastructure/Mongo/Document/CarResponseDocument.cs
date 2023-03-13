using MongoDB.Bson.Serialization.Attributes;

namespace CarAPI.Infrastructure.Mongo.Document
{
    public class CarResponseDocument
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public List<CarResponseEngineDocument> Engines { get; set; }
    }
}
