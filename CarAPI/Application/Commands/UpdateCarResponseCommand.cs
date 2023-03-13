using AutoMapper;
using CarAPI.Application.Dto;
using CarAPI.Core.Entities;
using CarAPI.Core.Repository;
using CarAPI.Utils;
using MediatR;

namespace CarAPI.Application.Commands
{
    public class UpdateCarResponseCommand : IRequest
    {
        public CarResponseDto carResponseDto { get; set; }
    }
    public class UpdateCarResponseCommandHandler : IRequestHandler<UpdateCarResponseCommand>
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

        public async Task<Unit> Handle(UpdateCarResponseCommand response, CancellationToken cancellationToken)
        {
            try
            {
                var carResponse = _mapper.Map<CarResponse>(response.carResponseDto);
                await _carRepository.UpdateAsync(carResponse);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.UpdateCarResponseCommandHandlerFailure, ex, "UpdateCarResponseCommandHandler failed");
            }
            return Unit.Value;
        }
    }
}
