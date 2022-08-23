using CarAPI.Application.Dto;
using MediatR;

namespace CarAPI.Application.Commands
{
    public class SendMessageCommand : IRequest
    {
        public CarResponseDto CarResponseDto { get; set; }
    }
}
