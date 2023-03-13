using AutoMapper;
using CarAPI.Application.Dto;
using CarAPI.Core.Entities;
using CarAPI.Infrastructure.Mongo.Document;

namespace CarAPI.Infrastructure.Mongo.Profiles
{
    public class CarResponseEngineDtoToCarResponseEngineDocument : Profile
    {
        public CarResponseEngineDtoToCarResponseEngineDocument()
        {
            CreateMap<CarResponseEngineDto, CarResponseEngineDocument>();
        }
    }
    public class CarResponseEngineToCarResponseEngineDocument : Profile
    {
        public CarResponseEngineToCarResponseEngineDocument()
        {
            CreateMap<CarResponseEngine, CarResponseEngineDocument>();
        }
    }
    public class CarResponseDtoToCarResponseDocument : Profile
    {
        public CarResponseDtoToCarResponseDocument()
        {
            CreateMap<CarResponseDto, CarResponseDocument>();
        }
    }
    public class CarResponseToCarResponseDocument : Profile
    {
        public CarResponseToCarResponseDocument()
        {
            CreateMap<CarResponse, CarResponseDocument>();
        }
    }
}
