using System;
using System.Threading;
using Telegram.Bot;

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
        static void Main(string[] args)
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AFK4EVENTS_BOT_TOKEN")))
            {
                Console.WriteLine("Required environment variable AFK4EVENTS_BOT_TOKEN not defined. Please edit config.env");
                Environment.Exit(1);
            }
            var testBot = new TelegramBotClient(Environment.GetEnvironmentVariable("AFK4EVENTS_BOT_TOKEN"));
            var me = testBot.GetMeAsync().Result;

            Console.Write($"Hello World, I am user {me.Id} and my name is {me.FirstName}");
            testBot.OnMessage += (sender, eventargs) =>
            {
                if (eventargs.Message != null)
                {
                    Console.WriteLine($"Received a message in chat.");
                    testBot.SendTextMessageAsync(
                        eventargs.Message.Chat,
                        $"You said:\n{eventargs.Message.Text}");
                }
            };

            testBot.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }
    }
}
