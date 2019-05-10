using System.ComponentModel.DataAnnotations;

namespace Afk4Events.Data.Entities.Themes
{
	public class Theme
	{
		/// <summary>
		///   The Theme's unique identifier.
		/// </summary>
		[Key]
		[MaxLength(250)]
		public string Id { get; set; }

		/// <summary>
		///   The markup.
		/// </summary>
		public string Css { get; set; }
	}
}
