using CarAPI.Application.Dto;
using MediatR;

namespace CarAPI.Application.Queries
{
    public class GetCarResponseQuery : IRequest<List<CarResponseDto>>
    {
    }
}
