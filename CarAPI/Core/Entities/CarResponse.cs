using CarAPI.Infrastructure.Mongo.Document;
using MongoDB.Bson.Serialization.Attributes;

namespace CarAPI.Core.Entities
{
    public class CarResponse
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public List<CarResponseEngineDocument> Engines { get; set; }
    }
}
