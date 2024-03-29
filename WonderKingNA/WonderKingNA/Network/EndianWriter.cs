﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WonderKingNA.Network.Handlers;

namespace WonderKingNA.Network {
    internal class EndianWriter {
        private static readonly string CODEPAGE = "Windows-1252";
        private int size;
        private MemoryStream ms;

        public EndianWriter() {
            this.size = 32;
        }

        public EndianWriter(int size) {
            ms = new MemoryStream(size);
        }

        public string toString() {
            return ByteArray.toHex(Array());
        }

        public string WriteToAsciiString() { // may have to come back to this
            Encoding enc = Encoding.GetEncoding(CODEPAGE);
            return new string(Convert.ToChar(Array()), Convert.ToInt32(enc));
        }

        public byte[] Array() {
            return ms.ToArray();
        }

        public int Length() {
            return (int)ms.Length;
        }

        public void AddHeader(Enum header) {
            PacketHandler ph = new PacketHandler();
            ph.AddInt16((short)(int)(object)header);
        }

        public void Write(byte[] b) {
            foreach (byte x in b) {
                ms.WriteByte(x);
            }
        }

        public void Write(int b) {
            ms.WriteByte((byte)b);
        }

        public void NCopies(byte value, int copies) {
            for (int i = 0; i < copies; i++) {
                ms.WriteByte(value);
            }
        }

        public void Skip(int b) {
            Write(new byte[b]);
        }

        public void WriteShort(int i) {
            ms.WriteByte((byte)(i & 0xFF));
            ms.WriteByte((byte)((i >> 8) & 0xFF));
        }

        public void WriteInt(int i) {
            ms.WriteByte((byte)(i & 0xFF));
            ms.WriteByte((byte)((i >> 8) & 0xFF));
            ms.WriteByte((byte)((i >> 16) & 0xFF));
            ms.WriteByte((byte)((i >> 24) & 0xFF));
        }

        public void WriteAsciiString(string s) {
            if (s == null) {
                throw new Exception("Can't write a null string to the byte array");
            }
            byte [] b = Encoding.ASCII.GetBytes(CODEPAGE);
            Write(b);
        }

        public void WriteAsciiString(string s, int length) {
            if (s.Length > length) {
                throw new Exception($"name cannot be longer than [{length}] chars.");
            }
            WriteAsciiString(s);
            for (int i = s.Length; i < length; i++) {
                Write(0);
            }
        }

        public void WriteLong(long l) {
            ms.WriteByte((byte)(l & 0xFF));
            ms.WriteByte((byte)((l >> 8) & 0xFF));
            ms.WriteByte((byte)((l >> 16) & 0xFF));
            ms.WriteByte((byte)((l >> 24) & 0xFF));
            ms.WriteByte((byte)((l >> 32) & 0xFF));
            ms.WriteByte((byte)((l >> 40) & 0xFF));
            ms.WriteByte((byte)((l >> 48) & 0xFF));
            ms.WriteByte((byte)((l >> 56) & 0xFF));
        }

        public void WriteFloat(float v) {
            int bits = BitConverter.ToInt32(BitConverter.GetBytes(v), 0);
            ms.WriteByte((byte)(bits & 0xff));
            ms.WriteByte((byte)((bits >> 8) & 0xff));
            ms.WriteByte((byte)((bits >> 16) & 0xff));
            ms.WriteByte((byte)((bits >> 24) & 0xff));
        }
    }
}
