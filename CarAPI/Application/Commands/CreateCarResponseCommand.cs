using CarAPI.Application.Dto;
using MediatR;

namespace CarAPI.Application.Commands
{
    public class CreateCarResponseCommand : IRequest
    {
        public CarResponseDto CarResponse { get; set; }
    }
}
