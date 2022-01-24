using System;
using WonderKingNA.Login;
using WonderKingNA.Network;
using WonderKingNA.Tools;

namespace WonderKingNA {
    internal class WonderKingWorker {
        private int connectionsAllowed;

        public void Run() {
            new Settings();
            new AES();
            new Database();
            new LoginServer();

            Settings s = new Settings();
            this.connectionsAllowed = s.GetGameAconnectionsAllowed;
            Log.ConsoleMessage($"[GAME_SERVER] \tTotal Connections Allowed: {connectionsAllowed}");

            Console.ReadKey();
        }
    }
}