using BotTwitchCSharp;
using TwitchLib.Client.Models;

public class Bot {

    //https://twitchtokengenerator.com/
    ConnectionCredentials creds = new ConnectionCredentials(TwitchInfo.ChannelName, TwitchInfo.ConnectionString);

    public void Connect() {
        throw new NotImplementedException();       
    }

    internal void Disconnect() {
        throw new NotImplementedException();
    }
}