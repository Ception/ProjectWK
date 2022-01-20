using System.Runtime.InteropServices;
using System.Text;

namespace WonderKingNA.Tools {
    internal class INIFile {
        private string filePath;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string val, string key, string filePath);

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string val, int key, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, int key, string def, StringBuilder retVal, int size, string filePath);

        public INIFile(string filePath) {
            this.filePath = filePath;
        }

        public void Write(string section, string key, string value) {
            WritePrivateProfileString(section, key, value.ToLower(), this.filePath);
        }

        public void Write(string section, string key, int value) {
            WritePrivateProfileString(section, key, value.ToString(), this.filePath);
        }

        public string Read(string section, string key) {
            StringBuilder SB = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", SB, 255, this.filePath);
            return SB.ToString();
        }

        public string Read(string section, int key) {
            StringBuilder SB = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key.ToString(), "", SB, 255, this.filePath);
            return SB.ToString();
        }

        public string FilePath {
            get { return this.filePath; }
            set { this.filePath = value; }
        }
    }
}
