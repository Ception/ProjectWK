using System;

namespace WonderKingNA.Network {
    internal class EndianReader {
        private static readonly String CodePage = "Windows-1252";
        private static readonly short UByte = 0xFF;

        private int index = 0; // read index of the byte array
        private byte[] buf;

        public EndianReader(byte[] buf) {
            this.buf = buf;
        }

        public int getPosition() {
            return index;
        }

        public int available() {
            return buf.Length - index;
        }

        public int length() {
            return buf.Length;
        }

        public String toString() {
            return ByteArray.toHex(buf);
        }

        public String toAsciiString() {
            return new String(buf, Charset.forName(CodePage));
        }

        /**
         * @return copy of the buffer
         */
        public byte[] array() {
            return Array.Copy(buf, buf.Length);
        }

        /**
         * @return signed byte (int8)
         */
        public byte readByte() {
            return (byte)readByte(index++);
        }

        public int readByte(int i) {
            return (((int)buf[i]) & UByte);
        }

        /**
         * @return signed short (int16)
         */
        public short readShort() {
            return (short)(readByte(index++) + (readByte(index++) << 8));
        }

        /**
         * @return signed int (int32)
         */
        public int readInt() {
            return readInt(index);
        }

        public int readInt(int i) {
            int ret = 0;
            for (int b = 0; b < UByte; b++) {
                ret += readByte(i + b) << (b * 8);
                index++;
            }
            return ret;
        }

        /**
         * @return unsigned int (int32)
         */
        public long readUnsignedInt() {
            return ulong(readInt());
        }

        /**
         * @param index position in the buffer to read from
         * @return unsigned int (int32)
         */
        public long readUnsignedInt(int index) {
            return (ulong)((readByte(index))
                            + (readByte(index + 1) << 8L)
                            + (readByte(index + 2) << 16L)
                            + (readByte(index + 3) << 24L));
        }

        //region these don't belong but are necessary for the AES shit; will make sense of it's belonging another time
        public void writeByte(int index, byte value) {
            buf[index] = value;
        }

        /**
         * @param index position in the buffer to write to
         * @param value little-endian int (int32)
         */
        public void writeInt(int index, int value) {
            buf[index] = ((byte)(value & UByte));
            buf[index + 1] = ((byte)((value >>> 8) & UByte));
            buf[index + 2] = ((byte)((value >>> 16) & UByte));
            buf[index + 3] = ((byte)((value >>> 24) & UByte));
        }
        //endregion

        /**
         * @return signed long (int64)
         */
        public long readLong() {
            return (readByte(index))
                    + (readByte(index + 1) << 8L)
                    + (readByte(index + 2) << 16L)
                    + (readByte(index + 3) << 24L)
                    + (((long)readByte(index + 4)) << 32L)
                    + (((long)readByte(index + 5)) << 40L)
                    + (((long)readByte(index + 6)) << 48L)
                    + (((long)readByte(index + 7)) << 56L);
        }

        /**
         * Moves the "cursor" position where certain method calls will start reading from in the buffer
         *
         * @param num index in the buffer
         */
        public void seek(int num) {
            if (num < 0 || num > buf.Length) {
                throw new ArgumentException("cannot seek position beyond packet length or below 0");
            }
            index = num;
        }

        public void skip(int num) {
            if (num + index < 0 || num > buf.Length) {
                throw new ArgumentException("cannot skip beyond packet length or below 0");
            }
            index += num;
        }

        public byte[] read(int num) {
            byte[] dest = new byte[num];
            Array.Copy(buf, index, dest, 0, dest.Length);
            index += num;
            return dest;
        }

        public short[] readUnsigned(int num) {
            short[] dest = new short[num];
            for (int i = 0; i < num; i++) {
                dest[i] = (short)(((short)readByte()) & 0xff);
            }
            return dest;
        }

        public String readAsciiString(int size) {
            return new String(read(size), Charset.forName(CodePage));
        }

        public float readFloat() {
            return ((float)((int)this.readByte() | (int)this.readByte() << 8 | (int)this.readByte() << 16 | (int)this.readByte() << 24));
        }
    }
}