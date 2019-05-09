using System;

namespace Afk4Events.Data.Entities
{
    public class EventDate
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Event Event { get; set; }
        public Guid EventId { get; set; }
    }
}