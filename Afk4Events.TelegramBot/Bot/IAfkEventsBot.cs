namespace Afk4Events.TelegramBot.Bot
{
	public interface IAfkEventsBot
	{
		/// <summary>
		/// Start the bot asynchronously
		/// </summary>
		void RunAsync();
		
		/// <summary>
		/// Stop the bot.
		/// </summary>
		void Stop();
	}
}