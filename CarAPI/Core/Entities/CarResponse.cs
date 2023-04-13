using CarAPI.Infrastructure.Mongo.Document;
using CarAPI.Utils;
using MongoDB.Bson.Serialization.Attributes;

namespace CarAPI.Core.Entities
{
    public class CarResponse
    {
        public Guid Id { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public List<CarResponseEngine> Engines { get; private set; }
        public static CarResponse CreateCarResponse(Guid id, string brand, string model, List<CarResponseEngine> engines)
        {
            if(id == Guid.Empty)
            {
                id = Guid.NewGuid();
            }
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new EmptyBrandException();
            }
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new EmptyModelException();
            }
            var carResponse = new CarResponse()
            {
                Id = id,
                Brand = brand.Trim(),
                Model = model.Trim(),
                Engines = engines
            };
            return carResponse;
        }
    }
}
