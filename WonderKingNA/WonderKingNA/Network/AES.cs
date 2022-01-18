using System;
using WonderKingNA.Tools;

namespace WonderKingNA.Network {
    internal class AES {
        private static readonly byte[] key = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7 };
        private static readonly byte[] encryptionKey = new byte[176];
        private static readonly byte[] decryptionKey = new byte[176];

        public AES() {
            ExpandKey();
            Log.ConsoleMessage("[AES] Cryptography Initialized!");
        }

        private static void ExpandKey() {
            
        }
    }
}
