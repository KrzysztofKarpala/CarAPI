using AutoMapper;
using CarAPI.Application.Dto;
using CarAPI.Core.Entities;
using CarAPI.Core.Repository;
using CarAPI.Infrastructure.Mongo.Document;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Net;

namespace CarAPI.Infrastructure.Mongo.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly IMongoCollection<CarResponseDocument> _carCollection;
        private readonly IMapper _mapper;

        public CarRepository(IOptions<CarDatabaseSettings> carDatabaseSettings, IMapper mapper)
        {
            var mongoClient = new MongoClient(carDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(carDatabaseSettings.Value.DatabaseName);
            _carCollection = mongoDatabase.GetCollection<CarResponseDocument>(carDatabaseSettings.Value.CarCollectionName);
            _mapper = mapper;
        }

        public async Task<bool> CheckCarBrandAndModel(string brand, string model)
        {
            var res = await _carCollection.Find(x => x.Brand == brand && x.Model == model).AnyAsync();
            return res;
        }

        public async Task<bool> CheckCarId(Guid carId) =>
            await _carCollection.Find(x => x.Id == carId).AnyAsync();

        public async Task CreateAsync(CarResponse carResponse) =>
            await _carCollection.InsertOneAsync(_mapper.Map<CarResponseDocument>(carResponse));

        public async Task<List<CarResponse>> GetAllAsync()
        {
            var res = await _carCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<CarResponse>>(res);
        }

        public async Task<CarResponse> GetCarByIdAsync(Guid id)
        {
            var res = await _carCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<CarResponse>(res);
        }

        public async Task UpdateAsync(CarResponse carResponse)
        {
            var oldCarResponse = await _carCollection.Find(x => x.Model == carResponse.Model && x.Brand == carResponse.Brand).FirstOrDefaultAsync();
            carResponse.Id = oldCarResponse.Id;
            await _carCollection.ReplaceOneAsync(x => x.Brand == carResponse.Brand && x.Model == carResponse.Model, _mapper.Map<CarResponseDocument>(carResponse));
        }
    }
}
