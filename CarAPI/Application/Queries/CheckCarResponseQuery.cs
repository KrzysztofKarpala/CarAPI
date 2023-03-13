using CarAPI.Core.Repository;
using MediatR;

namespace CarAPI.Application.Queries
{
    public class CheckCarResponseQuery : IRequest<bool>
    {
        public string Brand { get; set; }
        public string Model { get; set; }
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
            return await _carRepository.CheckCarBrandAndModel(request.Brand, request.Model);
        }
    }
}
