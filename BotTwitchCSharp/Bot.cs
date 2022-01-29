using BotTwitchCSharp;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
public class Bot {

    //https://twitchtokengenerator.com/
    ConnectionCredentials creds = new ConnectionCredentials(TwitchInfo.ChannelName, TwitchInfo.ConnectionString);
    TwitchClient client;

    internal void Connect(bool isLogging) {
        client = new TwitchClient();
        client.Initialize(creds, TwitchInfo.ChannelName);
        //client.OnMessageSent += RepeatMessage;
        if(isLogging){
            client.OnLog += Client_OnLog;
            //client.OnJoinedChannel += Client_OnJoinedChannel;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnMessageReceived += Client_OnMessageSent;
        }
        client.Connect();       
    }

    internal void Disconnect() {
        client.Disconnect();
    }

    private void Client_OnLog(object sender, OnLogArgs e){
        Console.WriteLine($"{e.DateTime.ToString()}: {e.BotUsername} - {e.Data}");
    }
    /*private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
    {
        client.SendMessage(e.Channel, "Olá");
    }*/

    private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
    {
        if (e.ChatMessage.Message.Contains("mestre") || e.ChatMessage.Message.Contains("Mestre"))
            client.SendMessage(e.ChatMessage.Channel, "Chamaram o Gatão do Jordão @MetroDaVania", false);
            
    }   
    public void Client_OnMessageSent(object sender, OnMessageReceivedArgs f) {
        client.SendMessage(f.ChatMessage.Channel, "Hello", false);
    } 
}