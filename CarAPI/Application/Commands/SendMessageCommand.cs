using CarAPI.Application.Dto;
using CarAPI.Infrastructure.Mongo.Repositories;
using MediatR;

namespace CarAPI.Application.Commands
{
    public class SendMessageCommand : IRequest
    {
        public CarResponseDto CarResponseDto { get; set; }
    }
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand>
    {
        private readonly RabbitMqCarApiRepository _rabbitMqCarApiRepository;
        public SendMessageCommandHandler(RabbitMqCarApiRepository rabbitMqCarApiRepository)
        {
            _rabbitMqCarApiRepository = rabbitMqCarApiRepository;
        }

        public async Task<Unit> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            await Task.Yield();
            _rabbitMqCarApiRepository.SendMessage(request.CarResponseDto);
            return Unit.Value;
        }
    }
}
