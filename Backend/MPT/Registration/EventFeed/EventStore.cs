using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using Newtonsoft.Json;

namespace Registration.EventFeed
{
    public class EventStore : IEventStore
    {
        private const string ConnectionString =
            "discover://http://127.0.0.1:2113/";
        private readonly IEventStoreConnection _connection =
            EventStoreConnection.Create(ConnectionString);
        public async Task Raise(string eventName, object content)
        {
            await _connection.ConnectAsync().ConfigureAwait(false);
            var contentJson = JsonConvert.SerializeObject(content);
            var metaDataJson =
                JsonConvert.SerializeObject(new EventMetadata
                {
                    OccurredAt = DateTimeOffset.Now,
                    EventName = eventName
                });
            var eventData = new EventData(
                Guid.NewGuid(),
                "RegisterEvent",
                isJson: true,
                data: Encoding.UTF8.GetBytes(contentJson),
                metadata: Encoding.UTF8.GetBytes(metaDataJson)
            );
            await
                _connection.AppendToStreamAsync(
                    "Register",
                    ExpectedVersion.Any,
                    eventData);
        }

        public async Task<IEnumerable<Event>> GetEvents(long firstEventSequenceNumber, long lastEventSequenceNumber)
        {
            await _connection.ConnectAsync().ConfigureAwait(false);
            var result = await _connection.ReadStreamEventsForwardAsync(
                "Register",
                start: (int)firstEventSequenceNumber,
                count: (int)(lastEventSequenceNumber - firstEventSequenceNumber),
                resolveLinkTos: false).ConfigureAwait(false);
            return result.Events
                .Select(ev =>
                    new
                    {
                        Content = JsonConvert.DeserializeObject(
                            Encoding.UTF8.GetString(ev.Event.Data)),
                        Metadata = JsonConvert.DeserializeObject<EventMetadata>(
                            Encoding.UTF8.GetString(ev.Event.Data))
                    })
                .Select((ev, i) =>
                    new Event(
                        i + firstEventSequenceNumber,
                        ev.Metadata.OccurredAt,
                        ev.Metadata.EventName,
                        ev.Content));
        }

        private class EventMetadata
        {
            public DateTimeOffset OccurredAt { get; set; }
            public string EventName { get; set; }
        }
    }
}