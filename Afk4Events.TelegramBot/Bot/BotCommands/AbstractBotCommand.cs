using Telegram.Bot;
using Telegram.Bot.Types;

namespace Afk4Events.TelegramBot.Bot.BotCommands
{
	/// <summary>
	/// The Afk Bot can perform commands supplied by users in a chat.
	/// </summary>
	public abstract class AbstractBotCommand : IBotCommand
	{
		/// <summary>
		/// Telegram Bot Client used to perform this command.
		/// </summary>
		protected ITelegramBotClient _client { get; }

		/// <summary>
		/// Chat this bot belongs to.
		/// </summary>
		protected Chat _chat { get; }

		protected AbstractBotCommand(ITelegramBotClient client, Chat chat)
		{
			_client = client;
			_chat   = chat;
		}

		/// <summary>
		/// Execute this command.
		/// </summary>
		public void Execute()
		{
			Implementation();
		}

		/// <summary>
		/// Template Method implementation.
		/// </summary>
		protected abstract void Implementation();
	}
}