using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Afk4Events.Data.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public Group Group { get; set; }
        public Guid GroupId { get; set; }
        public Theme Theme { get; set; }
        public string ThemeId { get; set; }
        [MaxLength(500)]
        [Required]
        public string Name { get; set; }
        [MaxLength(1000)]
        [Required]
        public string Location { get; set; }
        public EventDate PickedDate { get; set; }
        public Guid? PickedDateId { get; set; }
        public IList<EventDate> EventDates { get; set; }
        public User CreatedBy { get; set; }
        public Guid CreatedById { get; set; }
    }
}