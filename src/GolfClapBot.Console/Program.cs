using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using GolfClapBot.Service.CommandManager;
using GolfClapBot.Service.Commands;
using GolfClapBot.Service.Counter;
using GolfClapBot.Service.Settings;
using GolfClapBot.Service.SoundEffectManager;
using GolfClapBot.Service.SoundEffects;
using GolfClapBot.Service.TwitchApi;
using GolfClapBot.Service.TwitchApiHelper;
using GolfClapBot.Service.TwitchBot;
using GolfClapBot.Service.VariableManager;
using GolfClapBot.Service.VariableManager.Variables;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TwitchLib.Client;
using TwitchLib.Client.Interfaces;

namespace GolfClapBot.Console
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
                .RegisterAllSubClassTypes<Command>(new[] {typeof(Command).Assembly}, ServiceLifetime.Scoped)
                .AddSingleton<IList<Command>>(s => s.GetServices<Command>().ToList())

                // Sound Effects Manager
                .AddSingleton<SoundEffectManager>()

                // Sound Effects
                .RegisterAllSubClassTypes<SoundEffect>(new[] {typeof(SoundEffect).Assembly}, ServiceLifetime.Scoped)
                .AddSingleton<IList<SoundEffect>>(s => s.GetServices<SoundEffect>().ToList())

                // Twitch
                .AddSingleton<ITwitchClient, TwitchClient>()
                .AddSingleton<ITwitchBot, TwitchBot>()

                // Twitch Api
                .AddSingleton<TwitchApiFactory>()
                .AddSingleton(provider => provider.GetRequiredService<TwitchApiFactory>().Create())

                // Helpers
                .AddSingleton<ITwitchApiHelper, TwitchApiHelper>()

                // Variable Manager
                .AddSingleton<IVariableManager, VariableManager>()

                // Variables
                .RegisterAllSubClassTypes<Variable>(new[] {typeof(Variable).Assembly}, ServiceLifetime.Singleton)
                .AddSingleton<IList<Variable>>(s => s.GetServices<Variable>().ToList())

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
        public static IServiceCollection RegisterAllSubClassTypes<T>(this IServiceCollection services,
            IEnumerable<Assembly> assemblies,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            var typesFromAssemblies =
                assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.GetTypeInfo().IsSubclassOf(typeof(T))));

            foreach (var type in typesFromAssemblies)
                services.Add(new ServiceDescriptor(typeof(T), type, lifetime));

            return services;
        }

        /// <summary>
        ///     Register all types that are an interface of the type specified.
        /// </summary>
        /// <param name="services">Collection to add to.</param>
        /// <param name="assemblies">Assemblies to parse.</param>
        /// <param name="lifetime">Lifetime of the service.</param>
        /// <typeparam name="T">Base type of interface to register.</typeparam>
        public static IServiceCollection RegisterAllInterfaceTypes<T>(this IServiceCollection services,
            IEnumerable<Assembly> assemblies,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            var typesFromAssemblies =
                assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces().Contains(typeof(T))));

            foreach (var type in typesFromAssemblies)
                services.Add(new ServiceDescriptor(typeof(T), type, lifetime));

            return services;
        }
    }
}