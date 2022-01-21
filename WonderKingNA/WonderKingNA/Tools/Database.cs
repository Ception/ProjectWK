using MySql.Data.MySqlClient;
using System;

namespace WonderKingNA.Tools {
    internal class Database {

        private MySqlConnection conn;
        private string server;
        private string databaseName;
        private string username;
        private string password;
        private string connectionString;

        public Database() {
            Init();
        }

        private void Init() {
            Settings s = new Settings();

            this.server = s.GetDatabaseServerIP;
            this.databaseName = s.GetDatabaseName;
            this.username = s.GetDatabaseUsername;
            this.password = s.GetDatabasePassword;

            this.connectionString =   $"SERVER={server};"
                                    + $"DATABASE={databaseName};"
                                    + $"UID={username};"
                                    + $"PASSWORD={password};";

            conn = new MySqlConnection(connectionString);
            OpenConnection();
        }

        private bool OpenConnection() {
            try {
                conn.Open();
                return true;
            } catch(MySqlException ex) {
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number) { //test
                    case 0:
                        Log.ConsoleError("[DATABASE] \tERROR: Cannot Connect to Database Server.");
                        break;
                    case 1045:
                        Log.ConsoleError("[DATABASE] \tERROR: Wrong Username/Password.");
                        break;
                }
                return false;
            } finally {
                bool isOpen = Convert.ToBoolean(conn.State);
                if (isOpen) {
                    Log.ConsoleMessage("[DATABASE] \tSUCCESS: Initialized.");
                }
            }
        }
    }
}
