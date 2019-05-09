using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Afk4Events.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        [MaxLength(250)]
        [Required]
        public string Name { get; set; }
       
        [MaxLength(250)]
        [Required]
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public string ProfilePictureUrl { get; set; }

        /// <summary>
        /// maps to 'sub' claim of id tokens issued by Google
        /// https://developers.google.com/identity/protocols/OpenIDConnect
        /// </summary>
        [MaxLength(250)]
        [Required]
        public string GoogleId { get; set; }

        public IList<UserGroup> Groups { get; set; }
    }
}
