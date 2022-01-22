using System;
using System.IO;

namespace WonderKingNA.Network {
    internal class FileCrypto {

        public FileCrypto() {
            Init();
        }

        public static void Init() {

        }

        private static void Magic_XOR(byte[] dat, int fileSize) {
            for (int i = 0; i < fileSize; ++i) {
                dat[i] = (byte)(dat[i] ^ 197); // 0xC5
            }
        }

        private static void DecryptFile(string file, Boolean force) {
            byte[] buf = File.ReadAllBytes(file);
            if (!force && !NeedsDecode(buf)) {
                Console.WriteLine($"Nothing changed with file [{file}].");
                return;
            }

            Magic_XOR(buf, buf.Length);
            FileStream fs = File.Open(file, FileMode.Open, FileAccess.ReadWrite);
            try {
                fs.Write(buf);
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                return;
            }
            fs.Flush();
            Console.WriteLine($"Updated file [{file}].");
        }

        private static void PrintDecryptedFile(string file, string location, Boolean force) {
            byte[] buf = File.ReadAllBytes(file);
            if (!force && !NeedsDecode(buf)) {
                Console.WriteLine($"Nothing changed with file [{file}].");
                return;
            }

            Magic_XOR(buf, buf.Length);
            FileStream fs = File.OpenWrite(location);
            try {
                fs.Write(buf);
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                return;
            }
            fs.Flush();
            Console.WriteLine($"Updated file [{file}].");
        }

        private static Boolean NeedsDecode(byte[] buf) {
            long magic = 0;
            foreach (byte b in buf) {
                if ((b & 0xff) == 0xff) magic++;
            }
            return (magic / (float)buf.Length) > 0.3; // 0.3
        }
    }
}
