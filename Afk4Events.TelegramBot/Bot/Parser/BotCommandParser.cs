using System.Text.RegularExpressions;
using Afk4Events.TelegramBot.Bot.BotCommands;
using Afk4Events.TelegramBot.Bot.BotCommands.Implementations;
using Afk4Events.TelegramBot.Lib;
using Optional;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Afk4Events.TelegramBot.Bot.Parser
{
	/// <summary>
	/// The Bot Command Parser takes raw input strings from the Telegram chat
	/// and attempts to convert these into some command.
	/// </summary>
	public class BotCommandParser : ICommandParser
	{
		private const string HelpPattern       = @"^\/events-help\s*$";
		private const string ListEventsPattern = @"^\/events-list\s*$";
		private const string EventInfoPattern  = @"^\/events-info \""(?<eventTitle>.+)\""\s*$";

		private readonly Regex HelpExpression       = new Regex(HelpPattern,       RegexOptions.Compiled);
		private readonly Regex ListEventsExpression = new Regex(ListEventsPattern, RegexOptions.Compiled);
		private readonly Regex EventInfoExpression  = new Regex(EventInfoPattern,  RegexOptions.Compiled);

		private ITelegramBotClient _client { get; }

		public BotCommandParser(ITelegramBotClient client)
		{
			_client = client;
		}

		public Option<AbstractBotCommand> Parse(string input, Chat chat)
		{
			if(HelpExpression.Match(input).Success)
			{
				return Option.Some((AbstractBotCommand) (new HelpBotCommand(_client, chat)));
			}

			if(ListEventsExpression.Match(input).Success)
			{
				return Option.Some((AbstractBotCommand) (new ListEventsBotCommands(_client, chat)));
			}

			if(EventInfoExpression.MatchGroups(input, out GroupCollection groups))
			{
				return Option.Some((AbstractBotCommand) (new EventInfoBotCommand(_client,
					chat,
					groups["eventTitle"].Value
				)));
			}

			return Option.None<AbstractBotCommand>();
		}
	}
}
