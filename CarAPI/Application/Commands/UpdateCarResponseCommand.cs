using CarAPI.Application.Dto;
using MediatR;

namespace CarAPI.Application.Commands
{
    public class UpdateCarResponseCommand : IRequest
    {
        public int CarId { get; set; }
        public CarResponseDto CarResponse { get; set; }
    }
}
