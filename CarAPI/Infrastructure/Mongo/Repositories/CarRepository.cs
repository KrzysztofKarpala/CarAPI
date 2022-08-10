using AutoMapper;
using CarAPI.Application.Dto;
using CarAPI.Core.Repository;
using CarAPI.Infrastructure.Mongo.Document;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarAPI.Infrastructure.Mongo.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly IMongoCollection<CarResponse> _carCollection;
        private readonly IMapper _mapper;

        public CarRepository(IOptions<CarDatabaseSettings> carDatabaseSettings, IMapper mapper)
        {
            var mongoClient = new MongoClient(carDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(carDatabaseSettings.Value.DatabaseName);
            _carCollection = mongoDatabase.GetCollection<CarResponse>(carDatabaseSettings.Value.CarCollectionName);
            _mapper = mapper;
        }

        public async Task<bool> CheckCarId(int carId) =>
            await _carCollection.Find(x => x.CarId == carId).AnyAsync();

        public async Task CreateAsync(CarResponseDto NewResponse) =>
            await _carCollection.InsertOneAsync(_mapper.Map<CarResponse>(NewResponse));

        public async Task<List<CarResponseDto>> GetAllAsync()
        {
            return(await GetAsync()).Select(or => _mapper.Map<CarResponseDto>(or)).ToList();
        }

        public async Task<List<CarResponse>> GetAsync() =>
            await _carCollection.Find(_ => true).ToListAsync();
        public async Task UpdateAsync(int carId, CarResponseDto UpdateResponse) =>
            await _carCollection.ReplaceOneAsync(x => x.CarId == carId, _mapper.Map<CarResponse>(UpdateResponse));

    }
}
