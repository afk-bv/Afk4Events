using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Afk4Events.Data.Entities
{
    public class Group
    {
        public Guid Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public IList<UserGroup> Users { get; set; }
        public IList<Event> Events { get; set; }
    }
}