using ConsumerApi1.Application.Dto;
using MediatR;

namespace ConsumerApi1.Application.Commands
{
    public class RecieveMessageCommand : IRequest
    {
        public MessageCarDto MessageDto { get; set; }
    }
}
