using AutoMapper;
using CarAPI.Application.Dto;
using CarAPI.Infrastructure.Mongo.Document;

namespace CarAPI.Infrastructure.Mongo.Profiles
{
    public class CarResponseEngineDtoToCarResponseEngine : Profile
    {
        public CarResponseEngineDtoToCarResponseEngine()
        {
            CreateMap<CarResponseEngineDto, CarResponseEngine>();
        }
    }
}
