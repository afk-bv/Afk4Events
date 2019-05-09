using System;
using System.Collections.Generic;
using Afk4Events.Data.Entities.UserAvailabilities;
using Afk4Events.Models;
using Afk4Events.Models.Events;

namespace Afk4Events.Service.Event
{
    public interface IEventService
    {
        Data.Entities.Events.Event CreateEvent(EventDto eventDto, Guid createdById);

        /// <param name="eventDateId">
        /// The Id of the EventDate.
        /// Future me, you read that correctly the EVENT DATE not the EVENT
        /// </param>
        /// <returns>
        /// True if date has been pinned and participants notified.
        /// False if group has conflicting event
        /// </returns>
        bool PinDate(Guid eventDateId);

        void SpecifyAvailability(Dictionary<Guid, UserAvailabilityKind> availabilities, Guid userId);
    }
}