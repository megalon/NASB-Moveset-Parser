using MovesetParser.Unity;
using System;
using System.Globalization;
using System.IO;

namespace MovesetParser.BulkSerialize
{
    public class Reader
    {
        public int IntCount => _ints.Length;
        public int FloatCount => _floats.Length;
        public int FloatIdxCount => _floatIdx.Length;
        public int StringCount => _strings.Length;
        public int StringIdxCount => _stringIdx.Length;

        internal int NextIntPosition => _nextInt;
        internal int NextFloatPosition => _nextFloat;
        internal int NextStringPosition => _nextString;

        private int _nextInt;
        private int _nextFloat;
        private int _nextString;

        private int[] _ints;
        private float[] _floats;
        private float[] _floatIdx;
        private string[] _strings;
        private int[] _stringIdx;

        public Reader(Stream inputStream) => ReadStream(new StreamReader(inputStream));
        public Reader(string inputString) => ReadStream(new StringReader(inputString));

        private void ReadStream(TextReader reader)
        {
            _nextInt = 0;
            _nextFloat = 0;
            _nextString = 0;
            var header = reader.ReadLine();
            var version = reader.ReadLine();

            if (header == null || version == null)
            {
                Console.WriteLine("Invalid BulkSerialize format");
                _ints = new int[0];
                _floats = new float[0];
                _floatIdx = new float[0];
                _strings = new string[0];
                _stringIdx = new int[0];
                reader.Close();
                return;
            }

            var intDataSize = 0;
            var floatDataSize = 0;
            var floatIdxDataSize = 0;
            var stringDataSize = 0;
            var stringIdxDataSize = 0;

            int.TryParse(reader.ReadLine(), out intDataSize);
            int.TryParse(reader.ReadLine(), out floatDataSize);
            int.TryParse(reader.ReadLine(), out floatIdxDataSize);
            int.TryParse(reader.ReadLine(), out stringDataSize);
            int.TryParse(reader.ReadLine(), out stringIdxDataSize);

            _ints = new int[intDataSize];
            _floats = new float[floatDataSize];
            _floatIdx = new float[floatIdxDataSize];
            _strings = new string[stringDataSize];
            _stringIdx = new int[stringIdxDataSize];

            for (int i = 0; i < intDataSize; i++)
            {
                if (int.TryParse(reader.ReadLine(), out var nextInt))
                    _ints[i] = nextInt;
                else
                    _ints[i] = 0;
            }

            for (int j = 0; j < floatDataSize; j++)
            {
                if (float.TryParse(reader.ReadLine(), NumberStyles.Any, NumberFormatInfo.InvariantInfo, out var nextFloat))
                    _floats[j] = nextFloat;
                else
                    _floats[j] = 0f;
            }

            for (int k = 0; k < floatIdxDataSize; k++)
            {
                if (int.TryParse(reader.ReadLine(), out var nextFloatIdx))
                    _floatIdx[k] = _floats[nextFloatIdx];
                else
                    _floatIdx[k] = 0f;
            }

            for (int l = 0; l < stringDataSize; l++)
            {
                _strings[l] = ReLinebreak(reader.ReadLine());
            }

            for (int m = 0; m < stringIdxDataSize; m++)
            {
                if (int.TryParse(reader.ReadLine(), out var nextStringIdx))
                    _stringIdx[m] = nextStringIdx;
                else
                    _stringIdx[m] = 0;
            }

            reader.Close();
        }

        public void ResetRead()
        {
            _nextInt = 0;
            _nextFloat = 0;
            _nextString = 0;
        }

        public int GetNextInt() => _ints[_nextInt++];

        public int PeekNextInt() => _ints[_nextInt];

        public float GetNextFloat() => _floatIdx[_nextFloat++];

        public float PeekNextFloat() => _floatIdx[_nextFloat];

        public Vector2 GetNextVector2()
        {
            Vector2 zero = Vector2.zero;
            zero.x = GetNextFloat();
            zero.y = GetNextFloat();
            return zero;
        }

        public Vector3 GetNextVector3()
        {
            Vector3 zero = Vector3.zero;
            zero.x = GetNextFloat();
            zero.y = GetNextFloat();
            zero.z = GetNextFloat();
            return zero;
        }

        public string GetNextString() => _strings[_stringIdx[_nextString++]];

        public string PeekNextString() => _strings[_stringIdx[_nextString]];

        private string ReLinebreak(string s) => s.Replace("|", "\n");
    }
}
