using MongoDB.Bson.Serialization.Attributes;

namespace CarAPI.Infrastructure.Mongo.Document
{
    public class CarRequest
    {
        /// <summary>
        /// Car Id
        /// </summary>
        [BsonId]
        public int CarId { get; set; }

        /// <summary>
        /// Car Brand
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Car Model
        /// </summary>
        public string Model { get; set; }
    }
}
