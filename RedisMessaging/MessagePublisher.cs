using StackExchange.Redis;

namespace RedisMessaging
{
    public class MessagePublisher
    {
        private readonly IConnectionMultiplexer _redis;

        public MessagePublisher(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public async Task PublishMessageAsync(string channel, string message)
        {
            var subscriber = _redis.GetSubscriber();
            await subscriber.PublishAsync(channel, message);
        }
    }
}
