using Telegram.Bot;
using Telegram.Bot.Types;

namespace Afk4Events.TelegramBot.Bot.BotCommands.Implementations
{
	public class EventInfoBotCommand : AbstractBotCommand
	{
		private string _eventName { get; }

		public EventInfoBotCommand(ITelegramBotClient client, Chat chat, string eventName)
			: base(client, chat)
		{
			_eventName = eventName;
		}

		protected override void Implementation()
		{
			_client.SendTextMessageAsync(
				_chat.Id,
				$"Info for ${_eventName}"
			);
		}
	}
}