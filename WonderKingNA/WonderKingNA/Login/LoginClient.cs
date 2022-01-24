using System;
using WonderKingNA.Tools;

namespace WonderKingNA.Login {
    internal class LoginClient {
        private LoginInfo loginInfo;
        private int loginPort;
        private string loginIP;
        private string RegisteredCharacterName;

        public LoginClient() {
            Init();
        }

        private void Init() {
            Settings s = new Settings();

            try {
                this.loginIP = s.GetDatabaseServerIP;
                this.loginPort = s.GetLoginPort;
                this.loginInfo = new LoginInfo();

                Log.ConsoleMessage("[LOGIN_SERVER] \tSUCCESS: Initialized.");
            } catch (Exception e) {
                Log.ConsoleError($"[LOGIN_SERVER] \tERROR: Failed to Initialize.\n\n[ERROR]:\t{e}");
            }
        }
    }
}
