using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BapesBot.Service.CommandManager;
using BapesBot.Service.Commands;
using BapesBot.Service.Settings;
using BapesBot.Service.TwitchBot;
using Microsoft.Extensions.DependencyInjection;
using TwitchLib.Client;
using TwitchLib.Client.Interfaces;
using Microsoft.Extensions.Configuration;

namespace BapesBot.Console
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceCollection = ConfigureServiceCollection(new ServiceCollection());
            var twitchBot = serviceCollection.GetRequiredService<ITwitchBot>();
            var twitchSettings = serviceCollection.GetRequiredService<ISettingsService>().GeTwitchSettings();

            await twitchBot.Connect(twitchSettings.Username, twitchSettings.AccessToken);

            await Task.Delay(Timeout.Infinite);
        }

        private static ServiceProvider ConfigureServiceCollection(IServiceCollection serviceCollection)
        {
            // Configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            var configuration = builder.Build();

            return serviceCollection

                // Command Manager
                .AddSingleton<ICommandManager, CommandManager>()

                // Commands
                .AddSingleton<ICommand, HelpCommand>()
                .AddSingleton<IList<ICommand>>(s => s.GetServices<ICommand>().ToList())

                // Twitch
                .AddSingleton<ITwitchClient, TwitchClient>()
                .AddSingleton<ITwitchBot, TwitchBot>()

                // Settings
                .AddSingleton(configuration)
                .AddSingleton<ISettingsService, SettingsService>()

                .BuildServiceProvider();
        }
    }
}