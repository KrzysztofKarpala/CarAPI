using CarAPI.Application.Dto;
using CarAPI.Infrastructure.Mongo.Repositories;
using MediatR;

namespace CarAPI.Application.Commands
{
    public record SendMessageCommand(CarResponseDto carResponseDto) : IRequest
    {
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
            _rabbitMqCarApiRepository.SendMessage(request.carResponseDto);
            return Unit.Value;
        }
    }
}
