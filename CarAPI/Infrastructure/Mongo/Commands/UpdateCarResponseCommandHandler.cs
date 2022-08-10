using CarAPI.Application.Commands;
using CarAPI.Core.Repository;
using CarAPI.Utils;
using MediatR;

namespace CarAPI.Infrastructure.Mongo.Commands
{
    public class UpdateCarResponseCommandHandler : IRequestHandler<UpdateCarResponseCommand>
    {
        private readonly ICarRepository _carRepository;
        private readonly ILogger<UpdateCarResponseCommandHandler> _logger;

        public UpdateCarResponseCommandHandler(ICarRepository carRepository, ILogger<UpdateCarResponseCommandHandler> logger)
        {
            _carRepository = carRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCarResponseCommand response, CancellationToken cancellationToken)
        {
            try
            {
                await _carRepository.UpdateAsync(response.CarId, response.CarResponse);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(LogEvents.UpdateCarResponseCommandHandlerFailure, ex, "UpdateCarResponseCommandHandler failed");
            }
            return Unit.Value;
        }
    }
}