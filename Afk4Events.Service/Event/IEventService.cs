using System;
using System.Collections.Generic;
using Afk4Events.Data.Entities;
using Afk4Events.Models;

namespace Afk4Events.Service
{
    public interface IEventService
    {
        Event CreateEvent(EventDto eventDto, Guid createdById, Guid groupId);

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