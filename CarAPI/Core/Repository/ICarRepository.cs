using CarAPI.Application.Dto;
using CarAPI.Core.Entities;
using CarAPI.Infrastructure.Mongo.Document;

namespace CarAPI.Core.Repository
{
    public interface ICarRepository
    {
        public Task CreateAsync(CarResponse carResponse);
        public Task UpdateAsync(CarResponse carResponse);
        public Task<CarResponse> GetCarByIdAsync(Guid id);
        public Task<List<CarResponse>> GetAllAsync();
        public Task<bool> CheckCarId(Guid id);
        public Task<bool> CheckCarBrandAndModel(string brand, string model);
    }
}
