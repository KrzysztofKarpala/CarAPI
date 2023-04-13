using CarAPI.Core.Repository;
using MediatR;

namespace CarAPI.Application.Queries
{
    public record CheckCarResponseQuery(string brand, string model) : IRequest<bool>
    {
    }
    public class CheckCarResponseQueryHandler : IRequestHandler<CheckCarResponseQuery, bool>
    {
        private readonly ICarRepository _carRepository;
        public CheckCarResponseQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<bool> Handle(CheckCarResponseQuery request, CancellationToken cancellationToken)
        {
            return await _carRepository.CheckCarBrandAndModel(request.brand, request.model);
        }
    }
}
