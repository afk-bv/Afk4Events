using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace Afk4Events.Models
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProfilePictureUrl { get; set; }
    }

    public class EventDto
    {
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string ThemeName { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Location { get; set; }
        public IList<EventDateDto> EventDates { get; set; }
    }

    public class EventDateDto
    {
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
    }
}
