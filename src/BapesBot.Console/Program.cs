using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using BapesBot.Service.CommandManager;
using BapesBot.Service.Commands;
using BapesBot.Service.Counter;
using BapesBot.Service.Settings;
using BapesBot.Service.SoundEffectManager;
using BapesBot.Service.SoundEffects;
using BapesBot.Service.TwitchBot;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TwitchLib.Client;
using TwitchLib.Client.Interfaces;

namespace BapesBot.Console
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var serviceCollection = ConfigureServiceCollection(new ServiceCollection());
                var twitchBot = serviceCollection.GetRequiredService<ITwitchBot>();
                var twitchSettings = serviceCollection.GetRequiredService<ISettingsService>().GeTwitchSettings();

                await twitchBot.Connect(twitchSettings.Username, twitchSettings.AccessToken);

                await Task.Delay(Timeout.Infinite);
            }
            catch (Exception exception)
            {
                System.Console.WriteLine($"Error Occurred: {exception.Message}");
            }
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
                .RegisterAllTypes<Command>(new[] {typeof(Command).Assembly}, ServiceLifetime.Scoped)
                .AddSingleton<IList<Command>>(s => s.GetServices<Command>().ToList())

                // Sound Effects Manager
                .AddSingleton<SoundEffectManager>()

                // Sound Effects
                .RegisterAllTypes<SoundEffect>(new[] {typeof(SoundEffect).Assembly}, ServiceLifetime.Scoped)
                .AddSingleton<IList<SoundEffect>>(s => s.GetServices<SoundEffect>().ToList())

                // Twitch
                .AddSingleton<ITwitchClient, TwitchClient>()
                .AddSingleton<ITwitchBot, TwitchBot>()

                // Counter
                .AddSingleton<ICounterService, CounterService>()

                // Settings
                .AddSingleton(configuration)
                .AddSingleton<ISettingsService, SettingsService>()
                .BuildServiceProvider();
        }
    }

    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///     Register all types that are subclass of the type specified.
        /// </summary>
        /// <param name="services">Collection to add to.</param>
        /// <param name="assemblies">Assemblies to parse.</param>
        /// <param name="lifetime">Lifetime of the service.</param>
        /// <typeparam name="T">Base type of subclasses to register.</typeparam>
        public static IServiceCollection RegisterAllTypes<T>(this IServiceCollection services,
            IEnumerable<Assembly> assemblies,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            var typesFromAssemblies =
                assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.GetTypeInfo().IsSubclassOf(typeof(T))));
            foreach (var type in typesFromAssemblies)
                services.Add(new ServiceDescriptor(typeof(T), type, lifetime));

            return services;
        }
    }
}