using System;
using System.Collections.Generic;
using System.Linq;
using Afk4Events.Data;
using Afk4Events.Data.Entities.Events;
using Afk4Events.Data.Entities.UserAvailabilities;
using Afk4Events.Models.Events;
using Microsoft.EntityFrameworkCore;

namespace Afk4Events.Service.Events
{
    public class EventService : IEventService
    {
        private readonly Afk4EventsContext _db;

        public EventService(Afk4EventsContext db)
        {
            _db = db;
        }

        public Data.Entities.Events.Event CreateEvent(EventDto eventDto, Guid createdById)
        {
            if (eventDto.EventDates.Count < 2)
            {
                throw new ArgumentException("At least two dates must be specified", nameof(eventDto.EventDates));
            }
            
            var dbEvent = new Data.Entities.Events.Event()
            {
                CreatedById = createdById,
                GroupId = eventDto.GroupId,
                Location = eventDto.Location,
                Name = eventDto.Name,
                ThemeId = eventDto.ThemeName,
                EventDates = new List<EventDate>()
            };

            HashSet<DateTime> dates = new HashSet<DateTime>();
            foreach (var eventDate in eventDto.EventDates)
            {
                if (dates.Contains(eventDate.Start.Date))
                {
                    throw new ArgumentException("Creating two date possibilities on one date is currently not allowed", nameof(eventDto.EventDates));
                }

                dates.Add(eventDate.Start.Date);
                dbEvent.EventDates.Add(new EventDate()
                {
                    Start = eventDate.Start,
                    End = eventDate.End
                });
            }

            _db.Events.Add(dbEvent);
            _db.SaveChanges();


            return dbEvent;
        }

        /// <param name="eventDateId">
        /// The Id of the EventDate.
        /// Future me, you read that correctly the EVENT DATE not the EVENT
        /// </param>
        /// <returns>
        /// True if date has been pinned and participants notified.
        /// False if group has conflicting event
        /// </returns>
        public bool PinDate(Guid eventDateId)
        {
            var eventDate = _db.EventDates.Include(x => x.Event).FirstOrDefault(x => x.Id == eventDateId);
            if (eventDate == null)
            {
                throw new ArgumentException($"Event Date with Id '{eventDateId}' does not exist", nameof(eventDateId));
            }

            if (eventDate.Event.PickedDateId.HasValue)
            {
                throw new InvalidOperationException($"Date has already been pinned for event {eventDate.Event.Name}");
            }

            if (_db.Events.Any(x => x.GroupId == eventDate.Event.GroupId && x.PickedDate != null && x.PickedDate.Start.Date == eventDate.Start))
            {
                return false;
            }

            eventDate.Event.PickedDateId = eventDateId;
            _db.SaveChanges();

            //todo inform participants

            return true;
        }

        public void SpecifyAvailability(Dictionary<Guid, UserAvailabilityKind> availabilities, Guid userId)
        { 
            foreach (var availability in availabilities)
            {
                var availabilityEntry = _db.UserAvailabilities.Find(userId, availability.Value);
                // Update existing
                if (availabilityEntry != null)
                {
                    availabilityEntry.AvailabilityKind = availability.Value;
                }

                // Create new 
                _db.UserAvailabilities.Add(new UserAvailability()
                {
                    EventDateId = availability.Key,
                    AvailabilityKind = availability.Value,
                    UserId = userId
                });
            }

            _db.SaveChanges();

            // todo inform owner?
        }
    }
}