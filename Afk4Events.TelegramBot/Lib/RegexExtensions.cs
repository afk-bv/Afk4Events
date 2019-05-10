using System.Text.RegularExpressions;

namespace Afk4Events.TelegramBot.Lib
{
	/// <summary>
	/// Extension methods for Regex C# Class.
	/// </summary>
	public static class RegexExtensions
	{
		private static readonly GroupCollection _emptyMatch = Regex.Match("anime", "isbad").Groups;
		
		/// <summary>
		/// Check a match and collect its groups in one go.
		/// </summary>
		/// <returns>True if pattern matched, false otherwise.</returns>
		public static bool MatchGroups(this Regex pattern, string input , out GroupCollection groups)
		{
			var match = pattern.Match(input);

			groups = (match.Success)
				? match.Groups
				: _emptyMatch;
			
			return match.Success;
		}
	}
}