using AutoMapper;
using ConsumerApi2.Application.Dto;
using ConsumerApi2.Infrastructure.Mongo.Document;

namespace ConsumerApi2.Infrastructure.Mongo.Profiles
{
    public class MessageCarDtoToMessageCarDocument : Profile
    {
        public MessageCarDtoToMessageCarDocument()
        {
            CreateMap<MessageCarDto, MessageCarDocument>();
        }
    }
}
