using ConsumerApi1.Application.Dto;

namespace ConsumerApi1.Core.Repository
{
    public interface IConsumerRepository
    {
        Task CreateAsync(MessageCarDto NewRequest);
        Task<List<MessageCarDto>> GetAllAsync();
    }
}
