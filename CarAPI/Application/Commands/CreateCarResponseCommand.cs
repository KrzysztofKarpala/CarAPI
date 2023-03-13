using AutoMapper;
using CarAPI.Application.Dto;
using CarAPI.Core.Entities;
using CarAPI.Core.Repository;
using CarAPI.Utils;
using MediatR;

namespace CarAPI.Application.Commands
{
    public class CreateCarResponseCommand : IRequest
    {
        public CarResponseDto carResponseDto { get; set; }
    }
    public class CreateCarResponseCommandHandler : IRequestHandler<CreateCarResponseCommand>
    {
        private readonly ICarRepository _carRepository;
        private readonly ILogger<CreateCarResponseCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateCarResponseCommandHandler(ICarRepository carRepository, ILogger<CreateCarResponseCommandHandler> logger, IMapper mapper)
        {
            _carRepository = carRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCarResponseCommand response, CancellationToken cancellationToken)
        {
            try
            {
                var carResponse = _mapper.Map<CarResponse>(response.carResponseDto);
                await _carRepository.CreateAsync(carResponse);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.CreateCarResponseCommandHandlerFailure, ex, "CreateCarResponseCommandHandler failed");
            }
            return Unit.Value;
        }
    }
}
