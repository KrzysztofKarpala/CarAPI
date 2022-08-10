using MongoDB.Bson.Serialization.Attributes;

namespace CarAPI.Infrastructure.Mongo.Document
{
    public class CarResponse
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

        /// <summary>
        /// Engine lists
        /// </summary>
        public ICollection<CarResponseEngine> Engines { get; set; }
            = new List<CarResponseEngine>();
    }
}
