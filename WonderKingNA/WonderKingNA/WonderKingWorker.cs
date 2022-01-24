using System;
using WonderKingNA.Login;
using WonderKingNA.Network;
using WonderKingNA.Tools;

namespace WonderKingNA {
    internal class WonderKingWorker {

        public void Run() {
            new AES();
            new Database();
            new LoginServer();

            Console.ReadKey();
        }
    }
}