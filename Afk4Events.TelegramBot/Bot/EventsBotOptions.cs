namespace Afk4Events.TelegramBot.Bot
{
	/// <summary>
	/// Options Object for the Events Bot.
	/// Contains all required fields in order to run the bot.
	/// </summary>
	public class EventsBotOptions
	{
		/// <summary>
		/// Telegram API Key from @BotFather
		/// </summary>
		public string BotKey { get; }

		/// <summary>
		/// Location of the Afk4Events API
		/// </summary>
		public string ApiLocation { get; }

		public EventsBotOptions(string botKey, string apiLocation)
		{
			BotKey      = botKey;
			ApiLocation = apiLocation;
		}
	}
}