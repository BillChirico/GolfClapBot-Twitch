using System.Threading.Tasks;
using TwitchLib.Client.Events;

namespace GolfClapBot.Service.CommandManager
{
    public interface ICommandManager
    {
        Task MessageReceived(object sender, OnMessageReceivedArgs message);
    }
}