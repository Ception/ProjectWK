using System;
using System.Net;
using System.Net.Sockets;
using WonderKingNA.Tools;

namespace WonderKingNA.Login {
    internal class LoginServer {
        private string loginIP;
        private int loginPort;
        private int loginConnections;
        private LoginInfo loginInfo;
        private Socket loginSocket;

        public LoginServer() {
            Init();
        }

        private void Init() {
            Settings s = new Settings();

            try {
                this.loginIP = s.GetServerIP;
                this.loginPort = s.GetLoginPort;
                this.loginConnections = s.GetGameAconnectionsAllowed;
                this.loginInfo = new LoginInfo();
                this.loginSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.loginSocket.NoDelay = true;
                this.loginSocket.Bind(new IPEndPoint(IPAddress.Parse(loginIP), loginPort));
                this.loginSocket.Listen(loginConnections);
                this.loginSocket.BeginAccept(OnClientConnect, null);

                Log.ConsoleMessage("[LOGIN_SERVER] \tSUCCESS: Initialized.");
            } catch (Exception ex) {
                Log.ConsoleError("[LOGIN_SERVER_ERROR] \tFailed to Initialize.");
                Log.ConsoleError($"[LOGIN_SERVER_ERROR] \t{ex}");
                return;
            }
        }

        private void OnClientConnect(IAsyncResult result) {
            Socket socket = loginSocket.EndAccept(result);
            loginSocket.BeginAccept(OnClientConnect, null);
        }
    }
}
