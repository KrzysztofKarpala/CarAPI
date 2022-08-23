using ConsumerApi1.Application.Commands;
using ConsumerApi1.Core.Repository;
using MediatR;

namespace ConsumerApi1.Infrastructure.Mongo.Commands
{
    public class RecieveMessageCommandHandler : IRequestHandler<RecieveMessageCommand>
    {
        private readonly IConsumerRepository _consumerRepository;
        public RecieveMessageCommandHandler(IConsumerRepository consumerRepository)
        {
            _consumerRepository = consumerRepository;
        }

        public async Task<Unit> Handle(RecieveMessageCommand request, CancellationToken cancellationToken)
        {
            await _consumerRepository.CreateAsync(request.MessageDto);
            return Unit.Value;
        }
    }
}
