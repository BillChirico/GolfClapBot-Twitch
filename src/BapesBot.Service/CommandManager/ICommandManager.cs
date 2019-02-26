using TwitchLib.Client.Events;

namespace BapesBot.Service.CommandManager
{
    public interface ICommandManager
    {
        void MessageReceived(object sender, OnMessageReceivedArgs message);
    }
}