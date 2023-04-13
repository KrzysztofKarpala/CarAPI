using AutoMapper;
using CarAPI.Application.Dto;
using CarAPI.Core.Entities;
using CarAPI.Core.Repository;
using CarAPI.Utils;
using MediatR;

namespace CarAPI.Application.Commands
{
    public record UpdateCarResponseCommand(CarResponseDto carResponseDto) : IRequest<CarResponseDto>
    {
    }
    public class UpdateCarResponseCommandHandler : IRequestHandler<UpdateCarResponseCommand, CarResponseDto>
    {
        private readonly ICarRepository _carRepository;
        private readonly ILogger<UpdateCarResponseCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateCarResponseCommandHandler(ICarRepository carRepository, ILogger<UpdateCarResponseCommandHandler> logger, IMapper mapper)
        {
            _carRepository = carRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CarResponseDto> Handle(UpdateCarResponseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var engines = new List<CarResponseEngine>();
                foreach (var engineDto in request.carResponseDto.Engines)
                {
                    var engine = CarResponseEngine.CreateCarResponseEngine(engineDto.Capacity, engineDto.Hp, engineDto.Fuel);
                    engines.Add(engine);
                }
                var carResponse = CarResponse.CreateCarResponse(request.carResponseDto.Id, request.carResponseDto.Brand, request.carResponseDto.Model, engines);
                await _carRepository.UpdateAsync(carResponse);
                return _mapper.Map<CarResponseDto>(carResponse);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.UpdateCarResponseCommandHandlerFailure, ex, "UpdateCarResponseCommandHandler failed");
                throw ex;
            }
        }
    }
}
