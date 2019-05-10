using Afk4Events.TelegramBot.Bot.BotCommands;
using Optional;
using Telegram.Bot.Types;

namespace Afk4Events.TelegramBot.Bot.Parser
{
	public interface ICommandParser
	{
		Option<AbstractBotCommand> Parse(string input, Chat chat);
	}
}