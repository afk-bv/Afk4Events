using System;
using System.Collections.Generic;
using Afk4Events.TelegramBot.Bot;
using Serilog;

namespace Afk4Events.TelegramBot
{
	/*
	   ───▐▀▄──────▄▀▌───▄▄▄▄▄▄▄─────────────
	   ───▌▒▒▀▄▄▄▄▀▒▒▐▄▀▀▒██▒██▒▀▀▄──────────
	   ──▐▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▀▄────────
	   ──▌▒▒▒▒▒▒▒▒▒▒▒▒▒▄▒▒▒▒▒▒▒▒▒▒▒▒▒▀▄──────
	   ▀█▒▒█▌▒▒█▒▒▐█▒▒▀▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▌─────
	   ▀▌▒▒▒▒▒▀▒▀▒▒▒▒▒▀▀▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▐───▄▄
	   ▐▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▌▄█▒█
	   ▐▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▐▒█▀─
	   ▐▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▐▀───
	   ▐▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▌────
	   ─▌▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▐─────
	   ─▐▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▌─────
	   ──▌▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▐──────
	   ──▐▄▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▄▌──────
	   ────▀▄▄▀▀▀▀▄▄▀▀▀▀▀▀▄▄▀▀▀▀▀▀▄▄▀────────
	 */
	class Program
	{
		/// <summary>
		/// Entrypoint
		/// </summary>
		static void Main(string[] args)
		{
			EnvironmentCheck();
			ConfigureLogging();
			
			var bot = RunBot();
			
			Log.Information("Bot started. Press any key to quit.");
			Console.ReadLine();
			
			bot.Stop();
			Log.Information("Exiting.");
		}

		private static void EnvironmentCheck()
		{
			foreach(var requiredVariable in new List<string>() {"AFK4EVENTS_BOT_TOKEN", "AFK4EVENTS_API_LOCATION"})
			{
				if(string.IsNullOrEmpty(requiredVariable))
				{
					Log.Information(
						$"Required environment variable ${requiredVariable} not defined. Please supply this variable."
					);
				}
			}
		}
		
		/// <summary>
		/// Configure App Logging
		/// </summary>
		private static void ConfigureLogging()
		{
			// Configure Logging
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Information()
				.WriteTo.Console()
				.CreateLogger();
		}

		private static EventsBot RunBot()
		{
			EventsBot bot = new EventsBot(new EventsBotOptions(
				Environment.GetEnvironmentVariable("AFK4EVENTS_BOT_TOKEN"),
				Environment.GetEnvironmentVariable("AFK4EVENTS_API_LOCATION")));
			
			bot.RunAsync();

			return bot;
		}
		
	}
}