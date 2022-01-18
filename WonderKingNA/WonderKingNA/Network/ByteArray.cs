using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WonderKingNA.Network {
    internal class ByteArray {
        private ByteArray() {
        }

        private static readonly char[] HEX_ARRAY = "0123456789ABCDEF".ToCharArray();

        public static int[] asUnsigned(byte[] b) {
            int[] s = new int[b.Length];
            for (int i = 0; i < b.Length; i++) {
                s[i] = b[i] & 0xFF;
            }
            return s;
        }

        public static byte[] getBytesInt16(int i) {
            byte[] b = new byte[2];
            b[0] = (byte)(i & 0xFF);
            b[1] = (byte)((i >> 8) & 0xFF);
            return b;
        }

        /**
         * Reads bytes sequentially in little-endian format.
         */
        public static int toUnsignedShort(byte[] bytes) {
            if (bytes == null) {
                throw new NullReferenceException("array cannot be null");
            } else if (bytes.Length != 2) {
                throw new ArgumentOutOfRangeException("array is too short or too long (" + bytes.Length + ")");
            }
            return (bytes[0] & 0xFF) + ((bytes[1] & 0xFF) << 8);
        }

        /**
         * Reads bytes sequentially in big-endian format
         */
        public static long toBEUnsignedInt(byte[] bytes) {
            if (bytes == null) {
                throw new NullReferenceException("array cannot be null");
            } else if (bytes.Length != 4) {
                throw new ArgumentOutOfRangeException("array is too short or too long (" + bytes.Length + ")");
            }
            ulong result = (ulong)((bytes[3] & 0xFF)
                    + ((bytes[2] & 0xFF) << 8)
                    + ((bytes[1] & 0xFF) << 16)
                    + ((bytes[0] & 0xFF) << 24));
            return (long)result;
        }

        /**
         * Reads an array of bytes and returns them as a concatenated String of hexadecimals separated by spaces.
         */
        public static String toHex(byte[] bytes) {
            if (bytes == null) {
                throw new NullReferenceException("array cannot be null");
            } else if (bytes.Length == 0) {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes) {
                int v = b & 0xFF;
                sb
                        .Append(HEX_ARRAY[v >> 4])
                        .Append(HEX_ARRAY[v & 0x0F])
                        .Append(" ");
            }
            sb.Length -= 1;
            return sb.ToString();
        }
    }
}
