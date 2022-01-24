using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace WonderKingNA.Network.Handlers {
    internal unsafe class PacketHandler {
        public byte[] Buffer = null;

        public Socket socket;

        public BinaryReader binaryReader;

        public short Index = 0;

        private bool Lengthed = false;

        public PacketHandler() {
            this.Buffer = new byte[4];
        }

        public PacketHandler(byte[] buffer) {
            Index = 0;
            Buffer = buffer;
        }

        public PacketHandler(Enum Header, int len) {
            Index = 2;
            Buffer = new byte[len];
            AddHeader(Header);
        }

        public PacketHandler(int len) {
            Index = 2;
            Buffer = new byte[len];
        }

        public void SkipBytes(short num) { Index += num; }

        public void SkipByte() { Index++; }

        public void AddLength() {
            if (!Lengthed) {
                if (Index > Buffer.Length)
                    throw new OverflowException("Packet too small");
                fixed (byte* raw = Buffer)
                    *((short*)(raw)) = Index;
                Lengthed = true;
            }
        }

        public void AddBytes(params byte[] bytes) {
            if (bytes.Length > 0) {
                Array.Copy(bytes, 0, Buffer, Index, bytes.Length);
                Index += (short)bytes.Length;
            }
        }

        public void AddByteTimes(byte b, int times) {
            if (times + Index > Buffer.Length)
                throw new OverflowException("Packet OverFlow");
            for (int i = 0; i < times; i++)
                Buffer[Index++] = b;
        }

        public void AddByte(byte b) {
            Buffer[Index] = b;
            Index++;
        }

        public void AddFloat(float i) {
            fixed (byte* raw = Buffer)
                *((float*)(raw + Index)) = i;
            Index += 4;
        }

        public void AddUInt16(ushort i) {
            fixed (byte* raw = Buffer)
                *((ushort*)(raw + Index)) = i;
            Index += 2;
        }

        public void AddInt16(short i) {
            fixed (byte* raw = Buffer)
                *((short*)(raw + Index)) = i;
            Index += 2;
        }

        public void AddUInt32(uint i) {
            fixed (byte* raw = Buffer)
                *((uint*)(raw + Index)) = i;
            Index += 4;
        }

        public void AddInt32(int i) {
            fixed (byte* raw = Buffer)
                *((int*)(raw + Index)) = i;
            Index += 4;
        }

        public void AddUInt64(ulong i) {
            fixed (byte* raw = Buffer)
                *((ulong*)(raw + Index)) = i;
            Index += 8;
        }

        public void AddInt64(long i) {
            fixed (byte* raw = Buffer)
                *((long*)(raw + Index)) = i;
            Index += 8;
        }

        public void AddString(string s) {
            for (int i = 0; i < s.Length; i++) {
                if (s[i] < (char)0xff)
                    Buffer[Index++] = (byte)s[i];
                else
                    Buffer[Index++] = (byte)(s[i] + 0x10);
            }
        }

        public void AddString(string s, int size) {
            for (int i = 0; i < s.Length; i++) {
                if (s[i] < (char)0xff)
                    Buffer[Index++] = (byte)s[i];
                else
                    Buffer[Index++] = (byte)(s[i] + 0x10);
            }
            AddByteTimes(0x00, size - s.Length);
        }

        public byte[] GetBytes(short num) {
            if (Index + num > Buffer.Length)
                throw new OverflowException("Packet OverFlow");
            byte[] buffer = new byte[num];
            Array.Copy(Buffer, Index, buffer, 0, num);
            Index += num;
            return buffer;
        }

        public byte GetByte() {
            Index++;
            if (Index <= Buffer.Length)
                return Buffer[Index - 1];
            else
                throw new OverflowException("Packet OverFlow");
        }

        public float GetFloat() {
            Index += 4;
            if (Index <= Buffer.Length)
                fixed (byte* raw = Buffer)
                    return *((float*)(raw + Index - 4));
            else
                throw new OverflowException("Packet OverFlow");
        }

        public short GetInt16() {
            Index += 2;
            if (Index <= Buffer.Length)
                fixed (byte* raw = Buffer)
                    return *((short*)(raw + Index - 2));
            else
                throw new OverflowException("Packet OverFlow");
        }

        public ushort GetUInt16() {
            Index += 2;
            if (Index <= Buffer.Length)
                fixed (byte* raw = Buffer)
                    return *((ushort*)(raw + Index - 2));
            else
                throw new OverflowException("Packet OverFlow");
        }

        public int GetInt32() {
            Index += 4;
            if (Index <= Buffer.Length)
                fixed (byte* raw = Buffer)
                    return *((int*)(raw + Index - 4));
            else
                throw new OverflowException("Packet OverFlow");
        }

        public uint GetUInt32() {
            Index += 4;
            if (Index <= Buffer.Length)
                fixed (byte* raw = Buffer)
                    return *((uint*)(raw + Index - 4));
            else
                throw new OverflowException("Packet OverFlow");
        }

        public long GetInt64() {
            Index += 8;
            if (Index <= Buffer.Length)
                fixed (byte* raw = Buffer)
                    return *((long*)(raw + Index - 8));
            else
                throw new OverflowException("Packet OverFlow");
        }

        public ulong GetUInt64() {
            Index += 8;
            if (Index <= Buffer.Length)
                fixed (byte* raw = Buffer)
                    return *((ulong*)(raw + Index - 8));
            else
                throw new OverflowException("Packet OverFlow");
        }

        public string GetString(short size) {
            string str = null;
            fixed (byte* ptr = Buffer) {
                str = new String((sbyte*)ptr + Index);
                if (str.Length > size)
                    str = str.Remove(size);
                Index += size;
            }
            return str;
        }

        public string GetString() {
            byte size = GetByte();
            string str = null;
            fixed (byte* ptr = Buffer) {
                str = new String((sbyte*)ptr + Index);
                Index += size;
            }
            return str;
        }

        public string ReadString(int charCount) {
            string arg_1A_0 = Encoding.ASCII.GetString(this.GetBytes((short)charCount));
            char[] separator = new char[1];
            return arg_1A_0;
        }

        public override string ToString() { if (Buffer.Length != Index) return BitConverter.ToString(Buffer, Index).Replace('-', ' '); else return ""; }

        public string ToASCII() { return ASCIIEncoding.ASCII.GetString(Buffer); }

        public void Crypto(int pos) {
            int len = Buffer.Length - pos;
            for (int i = 0; i < len; i++) {
                int index = i + pos;
                Buffer[index] = (byte)(Buffer[index] ^ (i ^ (3 * (0xFE - i))));
            }
        }

        internal void AddHeader(Enum header) {
            AddInt16((short)(int)(object)header);
        }

        internal void AddEnum16(Enum message) {
            AddInt16((short)(int)(object)message);
        }

        internal void AddEnum8(Enum message) {
            AddByte((byte)(int)(object)message);
        }

        internal void AddEnum32(Enum message) {
            AddInt32((int)(object)message);
        }

        public void SendPacket(PacketHandler packet) {
            if (socket.Connected) {
                packet.AddLength();

                SocketError err;
                socket.BeginSend(packet.Buffer, 0, packet.Index, SocketFlags.None, out err, OnSend, null);
                if (err != SocketError.Success)
                    socket.Close();
            }
        }

        public void Dispose() {
            this.Dispose(true);
        }

        public void Dispose(bool disposing) {
            if (disposing) {
                this.Buffer = null;
            }
        }

        private void OnSend(IAsyncResult result) {
            SocketError err;
            socket.EndSend(result, out err);
        }
    }
}
