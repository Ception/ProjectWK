using System;
using WonderKingNA.Login;
using WonderKingNA.Network;
using WonderKingNA.Tools;

namespace WonderKingNA {
    internal class WonderKingWorker {
        private int connectionsAllowed;
        private int channelsUp;

        public void Run() {
            new Settings();
            new AES();
            new Database();
            new LoginServer();

            Settings s = new Settings();
            this.connectionsAllowed = s.GetGameAconnectionsAllowed;
            this.channelsUp = s.GetNumberOfChannels;
            Log.ConsoleMessage($"[GAME_SERVER] \tTotal Connections Allowed: {connectionsAllowed}");
            Log.ConsoleMessage($"[GAME_SERVER] \tTotal Active Channels: {channelsUp}");

            Console.ReadKey();
        }
    }
}