using ConsumerApi1.Application.Dto;
using MediatR;

namespace ConsumerApi1.Application.Queries
{
    public class GetRecievedMessageQuery : IRequest<List<MessageCarDto>>
    {
    }
}
