using AutoMapper;
using CarAPI.Application.Dto;
using CarAPI.Core.Repository;
using CarAPI.Utils;
using MediatR;

namespace CarAPI.Application.Queries
{
    public class GetCarResponseQuery : IRequest<List<CarResponseDto>>
    {
    }
    public class GetCarResponseQueryHandler : IRequestHandler<GetCarResponseQuery, List<CarResponseDto>>
    {
        private readonly ICarRepository _carRepository;
        private readonly ILogger<GetCarResponseQueryHandler> _logger;
        private readonly IMapper _mapper;
        public GetCarResponseQueryHandler(ICarRepository carRepository, ILogger<GetCarResponseQueryHandler> logger, IMapper mapper)
        {
            _carRepository = carRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<CarResponseDto>> Handle(GetCarResponseQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _carRepository.GetAllAsync();
                return _mapper.Map<List<CarResponseDto>>(res);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.GetCarResponseQueryHandlerFailure, ex, "GetCarResponseQueryHandler failed");
                return null;
            }
        }
    }
}
