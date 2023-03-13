using ConsumerApi2.Application.Dto;
using ConsumerApi2.Core.Repository;
using MediatR;

namespace ConsumerApi2.Application.Queries
{
    public class GetRecievedMessageQuery : IRequest<List<MessageCarDto>>
    {
    }
    public class GetRecievedMessageQueryHandler : IRequestHandler<GetRecievedMessageQuery, List<MessageCarDto>>
    {
        private readonly IConsumerRepository _consumerRepository;
        public GetRecievedMessageQueryHandler(IConsumerRepository consumerRepository)
        {
            _consumerRepository = consumerRepository;
        }

        public async Task<List<MessageCarDto>> Handle(GetRecievedMessageQuery request, CancellationToken cancellationToken)
        {
            return await _consumerRepository.GetAllAsync();
        }
    }
}

