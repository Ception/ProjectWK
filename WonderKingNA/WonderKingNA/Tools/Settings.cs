using System;

namespace WonderKingNA.Tools {
    internal class Settings {

        private const string databaseServer =   "localhost";
        private const string databaseName =     "wonderkingna";
        private const string databaseUsername = "root";
        private const string databasePassword = "root";
        private const string serverIP =         "localhost";
        private const int loginServerPort =     10001;
        private const int gameServerPort =      10002;

        INIFile ini = new INIFile(@".\settings.ini");

        public Settings() {
            try {
                ini.Write("DATABASE", "Server_IP", databaseServer);
                ini.Write("DATABASE", "Name", databaseName);
                ini.Write("DATABASE", "Username", databaseUsername);
                ini.Write("DATABASE", "Password", databasePassword);
                ini.Write("GAME", "Server_IP", serverIP);
                ini.Write("GAME", "Login_Port", loginServerPort);
                ini.Write("GAME", "Game_Port", gameServerPort);

                Log.ConsoleMessage("[SETTINGS] Initialized.");
            } catch (Exception ex) {
                Log.ConsoleError($"[SETTINGS] Failed To Initialize. Error:\n\n\t{ex.ToString()}\n\n\t");
            }
        }

        public string GetDatabaseServerIP {
            get {
                return ini.Read("DATABASE", "Server_IP");
            }
        }

        public string GetDatabaseName {
            get {
                return ini.Read("DATABASE", "Name");
            }
        }

        public string GetDatabaseUsername {
            get {
                return ini.Read("DATABASE", "Username");
            }
        }

        public string GetDatabasePassword {
            get {
                return ini.Read("DATABASE", "Password");
            }
        }

        public string GetServerIP {
            get {
                return ini.Read("GAME", "Server_IP");
            }
        }

        public int GetLoginPort {
            get {
                return Convert.ToInt32(ini.Read("GAME", "Login_Port"));
            }
        }

        public int GetGamePort {
            get {
                return Convert.ToInt32(ini.Read("GAME", "Game_Port"));
            }
        }
    }
}
