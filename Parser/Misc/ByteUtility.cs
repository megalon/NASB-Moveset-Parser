using System;

namespace MovesetParser.Misc
{
    public class ByteUtility
    {
        private static uint[] byteORS = new uint[8] { 1u, 2u, 4u, 8u, 16u, 32u, 64u, 128u };

        public static void Flip(byte[] bytes)
        {
            int num = bytes.Length / 2;
            for (int i = 0; i < num; i++)
            {
                byte b = bytes[i];
                bytes[i] = bytes[bytes.Length - 1 - i];
                bytes[bytes.Length - 1 - i] = b;
            }
        }

        public static void Flip(byte[] bytes, int start, int length)
        {
            int num = length / 2;
            for (int i = 0; i < num; i++)
            {
                byte b = bytes[i + start];
                bytes[i + start] = bytes[start + length - 1 - i];
                bytes[start + length - 1 - i] = b;
            }
        }

        public static byte[] LocalEndianToLittleEndian(byte[] bytes)
        {
            if (!BitConverter.IsLittleEndian)
                Flip(bytes);

            return bytes;
        }

        public static byte[] LittleEndianToLocalEndian(byte[] bytes)
        {
            if (!BitConverter.IsLittleEndian)
                Flip(bytes);

            return bytes;
        }

        public static byte[] LocalEndianToLittleEndian(byte[] bytes, int start, int length)
        {
            if (!BitConverter.IsLittleEndian)
                Flip(bytes, start, length);

            return bytes;
        }

        public static byte[] LittleEndianToLocalEndian(byte[] bytes, int start, int length)
        {
            if (!BitConverter.IsLittleEndian)
                Flip(bytes, start, length);

            return bytes;
        }

        public static byte SetBit(byte b, int bit, bool set)
        {
            if (bit < 0 || bit > 7)
                return b;

            if (set)
                return (byte)(b | byteORS[bit]);

            return (byte)(b & (0xFFu ^ byteORS[bit]));
        }

        public static bool GetBit(byte b, int bit)
        {
            if (bit < 0 || bit > 7)
                return false;

            return (b & byteORS[bit]) != 0;
        }

        public static byte Or(byte a, byte b) => (byte)(a | b);

        public static byte And(byte a, byte b) => (byte)(a & b);

        public static byte Xor(byte a, byte b) => (byte)(a ^ b);

        public static byte Remove(byte b, byte r) => (byte)(b & (0xFFu ^ r));
    }
}
