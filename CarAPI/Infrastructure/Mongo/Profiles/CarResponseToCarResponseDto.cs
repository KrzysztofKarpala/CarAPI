using AutoMapper;
using CarAPI.Application.Dto;
using CarAPI.Infrastructure.Mongo.Document;

namespace CarAPI.Infrastructure.Mongo.Profiles
{
    public class CarResponseToCarResponseDto : Profile
    {
        public CarResponseToCarResponseDto()
        {
            CreateMap<CarResponse, CarResponseDto>();
        }
    }
}
