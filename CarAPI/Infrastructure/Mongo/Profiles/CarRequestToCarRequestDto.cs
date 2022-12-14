using AutoMapper;
using CarAPI.Application.Dto;
using CarAPI.Infrastructure.Mongo.Document;

namespace CarAPI.Infrastructure.Mongo.Profiles
{
    public class CarRequestToCarRequestDto : Profile
    {
        public CarRequestToCarRequestDto()
        {
            CreateMap<CarRequest, CarRequestDto>();
        }
    }
}
