using System.Collections.Generic;
using System.Threading.Tasks;

namespace Registration.EventFeed
{
    public interface IEventStore
    {
        Task Raise(string eventName, object content);
        Task<IEnumerable<Event>> GetEvents(long firstEventSequenceNumber, long lastEventSequenceNumber);
    }
}