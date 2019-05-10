using System;
using System.Threading;
using System.Threading.Tasks;
using Afk4Events.TelegramBot.Bot.Parser;
using Optional;
using Serilog;
using Telegram.Bot;

namespace Afk4Events.TelegramBot.Bot
{
	/// <summary>
	/// Main Afk4Events Bot class.
	/// Contains data & run logic to asynchronously run the telegram bot.
	/// </summary>
	public class EventsBot : IAfkEventsBot
	{
		/// <summary>
		/// TelegramBotClient implementation used to communicate with the Telegram Bot API.
		/// </summary>
		private Option<ITelegramBotClient> _botClient { get; }

		/// <summary>
		/// Options for this bot instance.
		/// </summary>
		private EventsBotOptions _botOptions { get; }

		/// <summary>
		/// Command Parser used to transform input strings -> Bot commands.
		/// </summary>
		private ICommandParser _parser { get; }

		private AutoResetEvent _cancelled { get; }

		/// <summary>
		/// Create a new EventsBot instance. The bot does not start automatically,
		/// but should instead be invoked with the <see cref="RunAsync"/> method.
		/// </summary>
		/// <param name="botOptions">Required options to use.</param>
		public EventsBot(EventsBotOptions botOptions)
		{
			_botOptions = botOptions;
			_cancelled  = new AutoResetEvent(false);

			try
			{
				var client = new TelegramBotClient(_botOptions.BotKey);
				_parser    = new BotCommandParser(client);
				_botClient = Option.Some<ITelegramBotClient>(client);
			}
			catch(ArgumentException)
			{
				Log.Information(
					$"Supplied Bot Token not valid.");
				_botClient = Option.None<ITelegramBotClient>();
				return;
			}

			Log.Information(
				$"Created bot with API Location ${_botOptions.ApiLocation}"
			);
		}

		/// <summary>
		/// Run the bot asynchronously in a background task.
		/// </summary>
		public void RunAsync()
		{
			_botClient.Match(
				client => { Task.Run(() => Implementation(client)); },
				() => { Log.Warning($"Bot was not initialized."); }
			);
		}

		public void Stop()
		{
			_cancelled.Set();
			Thread.Sleep(1000);
		}

		/// <summary>
		/// Actual bot implementation
		/// </summary>
		private void Implementation(ITelegramBotClient client)
		{
			Log.Information(
				"Started bot, information: {@information}", client.GetMeAsync().Result);

			client.StartReceiving();
			client.OnMessage += (sender, args) =>
			{
				_parser.Parse(args.Message.Text, args.Message.Chat).Match(
					command => command.Execute(),
					() => { }
				);
			};

			// Wait for the user to cancel!
			_cancelled.WaitOne();

			client.StopReceiving();
			Log.Information(
				"Stopped bot, information: {@information}", client.GetMeAsync().Result);
		}
	}
}