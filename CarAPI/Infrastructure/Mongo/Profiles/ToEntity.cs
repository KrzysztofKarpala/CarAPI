using AutoMapper;
using CarAPI.Application.Dto;
using CarAPI.Core.Entities;
using CarAPI.Infrastructure.Mongo.Document;

namespace CarAPI.Infrastructure.Mongo.Profiles
{
    public class CarResponseEngineDocumentToCarResponseEngine : Profile
    {
        public CarResponseEngineDocumentToCarResponseEngine()
        {
            CreateMap<CarResponseEngineDocument, CarResponseEngine>();
        }
    }
    public class CarResponseEngineDtoToCarResponseEngine : Profile
    {
        public CarResponseEngineDtoToCarResponseEngine()
        {
            CreateMap<CarResponseEngineDto, CarResponseEngine>();
        }
    }
    public class CarResponseDocumentToCarResponse : Profile
    {
        public CarResponseDocumentToCarResponse()
        {
            CreateMap<CarResponseDocument, CarResponse>();
        }
    }
    public class CarResponseDtoToCarResponse : Profile
    {
        public CarResponseDtoToCarResponse()
        {
            CreateMap<CarResponseDto, CarResponse>();
        }
    }
}
