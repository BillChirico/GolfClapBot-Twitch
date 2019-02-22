using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TwitchLib.Client;
using TwitchLib.Client.Interfaces;

namespace TwitchTitleUpdater.Console
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            ConfigureServiceCollection(new ServiceCollection());

            await Task.Delay(Timeout.Infinite);
        }

        private static void ConfigureServiceCollection(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ITwitchClient, TwitchClient>();
        }
    }
}