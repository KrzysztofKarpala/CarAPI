namespace CarAPI.Core.Repository
{
    public interface IRabbitMqCarApiRepository
    {
        void SendMessage<T> (T message) where T : class;
    }
}
