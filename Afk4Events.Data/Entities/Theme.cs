using System.ComponentModel.DataAnnotations;

namespace Afk4Events.Data.Entities
{
    public class Theme
    {
        [Key]
        [MaxLength(250)]
        public string Id { get; set; }

        public string Css { get; set; }
    }
}