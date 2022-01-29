using BotTwitchCSharp;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Client.Extensions;

public class Bot {

    //https://twitchtokengenerator.com/
    ConnectionCredentials creds = new ConnectionCredentials(TwitchInfo.ChannelName, TwitchInfo.ConnectionString);
    TwitchClient client;

    internal void Connect(bool isLogging) {
        client = new TwitchClient();
        client.Initialize(creds, TwitchInfo.ChannelName);
            
        if(isLogging){
            client.OnLog += Client_OnLog;
            client.OnMessageReceived += Client_OnMessageReceived;
        }
        client.Connect();       
    }

    internal void Disconnect() {
        client.Disconnect();
    }

    private void Client_OnLog(object sender, OnLogArgs e){
        Console.WriteLine($"{e.DateTime.ToString()}: {e.BotUsername} - {e.Data}");
    }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            if (e.ChatMessage.Message.Contains("mestre") || e.ChatMessage.Message.Contains("Mestre"))
                //client.TimeoutUser(e.ChatMessage.Channel, e.ChatMessage.Username, TimeSpan.FromMinutes(2), "Oi Gatão!");
                client.SendMessage(e.ChatMessage.Channel, "Chamaram o Gatão do Jordão @MetroDaVania", false);
        }
}