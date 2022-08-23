using ConsumerApi2.Application.Dto;
using MediatR;

namespace ConsumerApi2.Application.Commands
{
    public class RecieveMessageCommand : IRequest
    {
        public MessageCarDto MessageDto { get; set; }
    }
}
