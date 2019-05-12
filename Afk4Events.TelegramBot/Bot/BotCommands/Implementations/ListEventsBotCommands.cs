using Telegram.Bot;
using Telegram.Bot.Types;

namespace Afk4Events.TelegramBot.Bot.BotCommands.Implementations
{
	/// <summary>
	/// The List Events command handles the /event-list command.
	/// This command should print a list of all current registered events!
	/// </summary>
	public class ListEventsBotCommands : AbstractBotCommand
	{
		private static int invocations = 0;

		public ListEventsBotCommands(ITelegramBotClient client, Chat chat) : base(client, chat)
		{
		}

		protected override void Implementation()
		{
			_client.SendTextMessageAsync(
				_chat.Id,
				$"This is an example of the List Events command!\n" +
				$"This command has been invoked {++invocations} times!"
			);
		}
	}
}
