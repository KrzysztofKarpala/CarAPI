using ConsumerApi1.Application.Dto;
using ConsumerApi1.Application.Queries;
using ConsumerApi1.Core.Repository;
using MediatR;

namespace ConsumerApi1.Infrastructure.Mongo.Queries
{
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
