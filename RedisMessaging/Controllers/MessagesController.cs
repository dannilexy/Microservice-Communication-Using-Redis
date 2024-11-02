using Microsoft.AspNetCore.Mvc;

namespace RedisMessaging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly MessagePublisher _publisher;

        public MessagesController(MessagePublisher publisher)
        {
            _publisher = publisher;
        }

        // POST api/messages/publish
        [HttpPost("publish")]
        public async Task<IActionResult> PublishMessage([FromQuery] string channel, [FromBody] string message)
        {
            await _publisher.PublishMessageAsync(channel, message);
            return Ok($"Message published to channel '{channel}': {message}");
        }

    }
}
