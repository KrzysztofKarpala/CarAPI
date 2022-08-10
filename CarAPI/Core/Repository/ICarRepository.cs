using CarAPI.Application.Dto;
using CarAPI.Infrastructure.Mongo.Document;

namespace CarAPI.Core.Repository
{
    public interface ICarRepository
    {
        public Task CreateAsync(CarResponseDto NewResponse);
        public Task UpdateAsync(int carId, CarResponseDto UpdateResponse);
        public Task<List<CarResponse>> GetAsync();
        public Task<List<CarResponseDto>> GetAllAsync();
        public Task<bool> CheckCarId(int CarId);
    }
}
