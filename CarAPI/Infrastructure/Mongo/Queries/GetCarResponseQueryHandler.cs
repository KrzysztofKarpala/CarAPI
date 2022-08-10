using CarAPI.Application.Dto;
using CarAPI.Application.Queries;
using CarAPI.Core.Repository;
using CarAPI.Utils;
using MediatR;

namespace CarAPI.Infrastructure.Mongo.Queries
{
    public class GetCarResponseQueryHandler : IRequestHandler<GetCarResponseQuery, List<CarResponseDto>>
    {
        private readonly ICarRepository _carRepository;
        private readonly ILogger<GetCarResponseQueryHandler> _logger;
        public GetCarResponseQueryHandler(ICarRepository carRepository, ILogger<GetCarResponseQueryHandler> logger)
        {
            _carRepository = carRepository;
            _logger = logger;
        }

        public async Task<List<CarResponseDto>> Handle(GetCarResponseQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _carRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.GetCarResponseQueryHandlerFailure, ex, "GetCarResponseQueryHandler failed");
                return null;
            }
        }
    }
}
