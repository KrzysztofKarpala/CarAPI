using AutoMapper;
using CarAPI.Application.Dto;
using CarAPI.Core.Entities;
using CarAPI.Core.Repository;
using CarAPI.Utils;
using MediatR;

namespace CarAPI.Application.Commands
{
    public record CreateCarResponseCommand(CarResponseDto carResponseDto) : IRequest<CarResponseDto>
    {
    }
    public class CreateCarResponseCommandHandler : IRequestHandler<CreateCarResponseCommand, CarResponseDto>
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

        public async Task<CarResponseDto> Handle(CreateCarResponseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var engines = new List<CarResponseEngine>();
                foreach(var engineDto in request.carResponseDto.Engines)
                {
                    var engine = CarResponseEngine.CreateCarResponseEngine(engineDto.Capacity, engineDto.Hp, engineDto.Fuel);
                    engines.Add(engine);
                }
                var carResponse = CarResponse.CreateCarResponse(request.carResponseDto.Id, request.carResponseDto.Brand, request.carResponseDto.Model, engines);
                await _carRepository.CreateAsync(carResponse);
                return _mapper.Map<CarResponseDto>(carResponse);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.CreateCarResponseCommandHandlerFailure, ex, "CreateCarResponseCommandHandler failed");
                throw ex;
            }
        }
    }
}
