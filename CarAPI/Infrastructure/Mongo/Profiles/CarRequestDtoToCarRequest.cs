using AutoMapper;
using CarAPI.Application.Dto;
using CarAPI.Infrastructure.Mongo.Document;

namespace CarAPI.Infrastructure.Mongo.Profiles
{
    public class CarRequestDtoToCarRequest : Profile
    {
        public CarRequestDtoToCarRequest()
        {
            CreateMap<CarRequestDto, CarRequest>();
        }
    }
}
