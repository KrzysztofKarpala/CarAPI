using CarAPI.Application.Commands;
using CarAPI.Core.Repository;
using CarAPI.Utils;
using MediatR;

namespace CarAPI.Infrastructure.Mongo.Commands
{
    public class CreateCarResponseCommandHandler : IRequestHandler<CreateCarResponseCommand>
    {
        private readonly ICarRepository _carRepository;
        private readonly ILogger<CreateCarResponseCommandHandler> _logger;

        public CreateCarResponseCommandHandler(ICarRepository carRepository, ILogger<CreateCarResponseCommandHandler> logger)
        {
            _carRepository = carRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(CreateCarResponseCommand response, CancellationToken cancellationToken)
        {
            try
            {
                await _carRepository.CreateAsync(response.CarResponse);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.CreateCarResponseCommandHandlerFailure, ex, "CreateCarResponseCommandHandler failed");
            }
            return Unit.Value;
        }
    }
}
