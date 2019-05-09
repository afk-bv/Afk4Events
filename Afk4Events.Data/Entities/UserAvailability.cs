using System;

namespace Afk4Events.Data.Entities
{
    public class UserAvailability
    {
        public Guid UserId { get; set; }
        public Guid EventDateId { get; set; }
        public EventDate EventDate { get; set; }
        public string Comment { get; set; }
        public UserAvailabilityKind AvailabilityKind { get; set; }
    }
}