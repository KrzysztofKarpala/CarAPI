using CarAPI.Application.Queries;
using CarAPI.Core.Repository;
using MediatR;

namespace CarAPI.Infrastructure.Mongo.Queries
{
    public class CheckCarResponseQueryHandler : IRequestHandler<CheckCarResponseQuery, bool>
    {
        private readonly ICarRepository _carRepository;
        public CheckCarResponseQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<bool> Handle(CheckCarResponseQuery request, CancellationToken cancellationToken)
        {
            return await _carRepository.CheckCarId(request.CarId);
        }
    }
}
