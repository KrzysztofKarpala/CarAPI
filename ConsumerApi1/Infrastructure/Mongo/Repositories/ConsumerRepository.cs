using AutoMapper;
using ConsumerApi1.Application.Dto;
using ConsumerApi1.Core.Repository;
using ConsumerApi1.Infrastructure.Mongo.Document;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ConsumerApi1.Infrastructure.Mongo.Repositories
{
    public class ConsumerRepository : IConsumerRepository
    {
        private readonly IMongoCollection<MessageCarDocument> _messageCollection;
        private readonly IMapper _mapper;

        public ConsumerRepository(IOptions<ConsumerDatabaseSettings> consumerDatabaseSettings, IMapper mapper)
        {
            var mongoClient = new MongoClient(consumerDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(consumerDatabaseSettings.Value.DatabaseName);
            _messageCollection = mongoDatabase.GetCollection<MessageCarDocument>(consumerDatabaseSettings.Value.Consumer1CollectionName);
            _mapper = mapper;
        }
        public async Task CreateAsync(MessageCarDto NewRequest) =>
            await _messageCollection.InsertOneAsync(_mapper.Map<MessageCarDocument>(NewRequest));

        public async Task<List<MessageCarDto>> GetAllAsync()
        {
            try
            {
                var responseDocumentList = await _messageCollection.FindAsync(_ => true);
                return responseDocumentList.ToEnumerable().Select(or => _mapper.Map<MessageCarDto>(or)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}