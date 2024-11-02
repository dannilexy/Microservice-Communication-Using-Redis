using StackExchange.Redis;

namespace RedisMessaging
{
    public class SubscriberBackgroundService : BackgroundService
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly string _channelName = "my-channel"; // specify your channel

        public SubscriberBackgroundService(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var subscriber = _redis.GetSubscriber();

            // Subscribe to the specified channel and listen for messages
            await subscriber.SubscribeAsync(_channelName, (channel, message) =>
            {
                Console.WriteLine($"Received message from channel '{channel}': {message}");
                // Add additional processing logic if needed
            });

            // Keep the service running while listening for messages
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
    }
}
