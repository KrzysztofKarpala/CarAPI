using AutoMapper;
using ConsumerApi1.Application.Dto;
using ConsumerApi1.Infrastructure.Mongo.Document;

namespace ConsumerApi1.Infrastructure.Mongo.Profiles
{
    public class MessageCarEngineDtoToMessageCarEngineDocument : Profile
    {
        public MessageCarEngineDtoToMessageCarEngineDocument()
        {
            CreateMap<MessageCarEngineDto, MessageCarEngineDocument>();
        }
    }
}