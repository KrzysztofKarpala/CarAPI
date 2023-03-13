using AutoMapper;
using CarAPI.Application.Dto;
using CarAPI.Core.Entities;
using CarAPI.Infrastructure.Mongo.Document;

namespace CarAPI.Infrastructure.Mongo.Profiles
{
    public class CarResponseEngineDocumentToCarResponseEngineDto : Profile
    {
        public CarResponseEngineDocumentToCarResponseEngineDto()
        {
            CreateMap<CarResponseEngineDocument, CarResponseEngineDto>();
        }
    }
    public class CarResponseEngineToCarResponseEngineDto : Profile
    {
        public CarResponseEngineToCarResponseEngineDto()
        {
            CreateMap<CarResponseEngine, CarResponseEngineDto>();
        }
    }
    public class CarResponseDocumentToCarResponseDto : Profile
    {
        public CarResponseDocumentToCarResponseDto()
        {
            CreateMap<CarResponseDocument, CarResponseDto>();
        }
    }
    public class CarResponseToCarResponseDto : Profile
    {
        public CarResponseToCarResponseDto()
        {
            CreateMap<CarResponse, CarResponseDto>();
        }
    }
}
