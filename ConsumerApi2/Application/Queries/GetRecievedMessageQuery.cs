using ConsumerApi2.Application.Dto;
using MediatR;

namespace ConsumerApi2.Application.Queries
{
    public class GetRecievedMessageQuery : IRequest<List<MessageCarDto>>
    {
    }
}

