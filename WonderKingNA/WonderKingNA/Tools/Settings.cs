using System;
using System.Collections.Generic;
using System.IO;

namespace WonderKingNA.Tools {
    internal class Settings {

        private const string filePath =         @".\settings.ini";
        private const string databaseServer =   "localhost";
        private const string databaseName =     "wonderkingna";
        private const string databaseUsername = "root";
        private const string databasePassword = "root";
        private const string serverIP =         "localhost";
        private const int loginServerPort =     10001;
        private const int gameServerPort =      10002;

        public Settings() {
            // If file is empty, THEN initilize.
            if (new FileInfo(filePath).Length == 0 || !File.Exists(filePath)) {
                Init();
            }
        }

        private INIFile ini = new INIFile(filePath);

        private void Init() {
            List<string> onlyAllowedWords = new List<string> {  "DATABASE", 
                                                                "Server_IP",
                                                                "Name",
                                                                "Username",
                                                                "Password",
                                                                "GAME",
                                                                "Login_Port",
                                                                "Game_Port" };

            ini.Write("DATABASE", "Server_IP", databaseServer);
            ini.Write("DATABASE", "Name", databaseName);
            ini.Write("DATABASE", "Username", databaseUsername);
            ini.Write("DATABASE", "Password", databasePassword);
            ini.Write("GAME", "Server_IP", serverIP);
            ini.Write("GAME", "Login_Port", loginServerPort);
            ini.Write("GAME", "Game_Port", gameServerPort);
        }

        public string GetDatabaseServerIP {
            get { return ini.Read("DATABASE", "Server_IP"); }
        }

        public string GetDatabaseName {
            get { return ini.Read("DATABASE", "Name"); }
        }

        public string GetDatabaseUsername {
            get { return ini.Read("DATABASE", "Username"); }
        }

        public string GetDatabasePassword {
            get { return ini.Read("DATABASE", "Password"); }
        }

        public string GetServerIP {
            get { return ini.Read("GAME", "Server_IP"); }
        }

        public int GetLoginPort {
            get { return Convert.ToInt32(ini.Read("GAME", "Login_Port")); }
        }

        public int GetGamePort {
            get { return Convert.ToInt32(ini.Read("GAME", "Game_Port")); }
        }
    }
}
