using AutoMapper;
using CarAPI.Application.Dto;
using CarAPI.Infrastructure.Mongo.Document;

namespace CarAPI.Infrastructure.Mongo.Profiles
{
    public class CarResponseEngineToCarResponseEngineDto : Profile
    {
        public CarResponseEngineToCarResponseEngineDto()
        {
            CreateMap<CarResponseEngine, CarResponseEngineDto>();
        }
    }
}
