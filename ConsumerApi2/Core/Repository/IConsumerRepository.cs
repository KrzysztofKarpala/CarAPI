using ConsumerApi2.Application.Dto;

namespace ConsumerApi2.Core.Repository
{
    public interface IConsumerRepository
    {
        Task CreateAsync(MessageCarDto NewRequest);
        Task<List<MessageCarDto>> GetAllAsync();
    }
}