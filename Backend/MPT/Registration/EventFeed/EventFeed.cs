using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Registration.EventFeed
{
    [ApiController]
    [Route("[controller]")]
    public class EventFeed:ControllerBase
    {
        private readonly IEventStore _eventStore;

        public EventFeed(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }
        [HttpGet("events")]
        public async Task<IActionResult> GetEvents(long start, long end)
        {
            
            var events=
                await _eventStore.GetEvents(
                    start,
                    end);

            return Ok(JsonConvert.SerializeObject(events));
        }
    }
}
