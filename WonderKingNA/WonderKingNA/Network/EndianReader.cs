using System;
using System.Runtime.InteropServices;
using System.Text;
using WonderKingNA.Tools;

namespace WonderKingNA.Network {
    internal class EndianReader {
        private static readonly string CODEPAGE = "Windows-1252";
        private static readonly short UBYTE = 0xFF;

        private int index = 0; // read index of the byte array
        private byte[] buf;

        public EndianReader(byte[] buf) {
            this.buf = buf;
        }

        public int GetPosition() {
            return index;
        }

        public int Available() {
            return buf.Length - index;
        }

        public int Length() {
            return buf.Length;
        }

        public string toString() {
            return ByteArray.toHex(buf);
        }

        /**
         * @return copy of the buffer
         */
        public byte[] CopyBufferArray() { // I think i fixed it??
            byte[] dest = new byte[Convert.ToByte(buf)];
            Array.Copy(buf, dest, dest.Length);
            Log.ConsoleWarning("Copying Buffer Array EndianReader.cs LINE 36"); // for debugging
            return dest;
        }

        /**
         * @return signed byte (int8)
         */
        public byte ReadByte() {
            return (byte)ReadByte(index++);
        }

        public int ReadByte(int i) {
            return (((int)buf[i]) & UBYTE);
        }

        /**
         * @return signed short (int16)
         */
        public short ReadShort() {
            return (short)(ReadByte(index++) + (ReadByte(index++) << 8));
        }

        /**
         * @return signed int (int32)
         */
        public int ReadInt() {
            return ReadInt(index);
        }

        public int ReadInt(int i) {
            int ret = 0;
            for (int b = 0; b < UBYTE; b++) {
                ret += ReadByte(i + b) << (b * 8);
                index++;
            }
            return ret;
        }

        /**
         * @return unsigned int (int32)
         */
        public long ReadUnsignedInt() {
            return Convert.ToUInt32(ReadInt());
        }

        /**
         * @param index position in the buffer to read from
         * @return unsigned int (int32)
         */
        public long ReadUnsignedInt(int index) {
            return  (Convert.ToUInt16(ReadByte(index))
                  + (ReadByte(index + 1) << Convert.ToUInt16(8L))
                  + (ReadByte(index + 2) << Convert.ToUInt16(16L))
                  + (ReadByte(index + 3) << Convert.ToUInt16(24L)));
        }

        //region these don't belong but are necessary for the AES shit; will make sense of it's belonging another time
        public void writeByte(int index, byte value) {
            buf[index] = value;
        }

        /**
         * @param index position in the buffer to write to
         * @param value little-endian int (int32)
         */
        public void WriteInt(int index, int value) {
            buf[index] = ((byte)(value & UBYTE));
            buf[index + 1] = ((byte)((value >> 8) & UBYTE));
            buf[index + 2] = ((byte)((value >> 16) & UBYTE));
            buf[index + 3] = ((byte)((value >> 24) & UBYTE));
        }
        //endregion

        /**
         * @return signed long (int64)
         */
        public long ReadLong() {
            return (ReadByte(index))
                 + (ReadByte(index + 1) << Convert.ToUInt16(8L))
                 + (ReadByte(index + 2) << Convert.ToUInt16(16L))
                 + (ReadByte(index + 3) << Convert.ToUInt16(24L))
                 + (ReadByte(index + 4) << Convert.ToUInt16(32L))
                 + (ReadByte(index + 5) << Convert.ToUInt16(40L))
                 + (ReadByte(index + 6) << Convert.ToUInt16(48L))
                 + (ReadByte(index + 7) << Convert.ToUInt16(56L));
        }

        /**
         * Moves the "cursor" position where certain method calls will start reading from in the buffer
         *
         * @param num index in the buffer
         */
        public void Seek(int num) {
            if (num < 0 || num > buf.Length) {
                throw new ArgumentException("cannot seek position beyond packet length or below 0");
            }
            index = num;
        }

        public void Skip(int num) {
            if (num + index < 0 || num > buf.Length) {
                throw new ArgumentException("cannot skip beyond packet length or below 0");
            }
            index += num;
        }

        public byte[] Read(int num) {
            byte[] dest = new byte[num];
            Array.Copy(buf, index, dest, 0, dest.Length);
            index += num;
            return dest;
        }

        public short[] ReadUnsigned(int num) {
            short[] dest = new short[num];
            for (int i = 0; i < num; i++) {
                dest[i] = ((short)(((short)ReadByte()) & 0xff));
            }
            return dest;
        }

        public String ReadAsciiString(int size) {
            Encoding encoding = Encoding.GetEncoding(CODEPAGE);
            size = Convert.ToInt32(Read(size));
            return new String(Convert.ToChar(size), Convert.ToInt32(encoding));
        }

        public float ReadFloat() {
            return ((float)((int)this.ReadByte() | (int)this.ReadByte() << 8 | (int)this.ReadByte() << 16 | (int)this.ReadByte() << 24));
        }
    }
}