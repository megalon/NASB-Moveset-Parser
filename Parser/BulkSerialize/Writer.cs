using MovesetParser.Unity;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MovesetParser.BulkSerialize
{
    public class Writer
    {
        private int _floatCount;

        private int _stringCount;

        private List<int> _ints;

        private List<float> _floats;

        private List<int> _floatIdx;

        private List<string> _strings;

        private List<int> _stringIdx;

        public Writer()
        {
            _floatCount = 0;
            _stringCount = 0;
            _ints = new List<int>();
            _floats = new List<float>();
            _floatIdx = new List<int>();
            _strings = new List<string>();
            _stringIdx = new List<int>();
        }

        public void AddString(string newString)
        {
            if (newString == null)
            {
                AddString(string.Empty);
                return;
            }
            var index = _strings.IndexOf(newString);
            if (index == -1)
            {
                _stringIdx.Add(_stringCount++);
                _strings.Add(newString);
            }
            else
            {
                _stringIdx.Add(index);
            }
        }

        public void AddInt(int newInt)
        {
            _ints.Add(newInt);
        }

        public void AddFloat(float newFloat)
        {
            var index = _floats.IndexOf(newFloat);
            if (index == -1)
            {
                _floatIdx.Add(_floatCount++);
                _floats.Add(newFloat);
            }
            else
            {
                _floatIdx.Add(index);
            }
        }

        public void AddVector2(Vector2 newVector2)
        {
            AddFloat(newVector2.x);
            AddFloat(newVector2.y);
        }

        public void AddVector3(Vector3 newVector3)
        {
            AddFloat(newVector3.x);
            AddFloat(newVector3.y);
            AddFloat(newVector3.z);
        }

        public void AddBool(bool newBool)
        {
            AddInt(newBool ? 7 : 0);
        }

        public string GetString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("BulkSerialize");
            stringBuilder.Append('\n');
            stringBuilder.Append("VERSION_0");
            stringBuilder.Append('\n');

            var intCount = _ints.Count;
            var floatCount = _floats.Count;
            var floatIdxCount = _floatIdx.Count;
            var stringCount = _strings.Count;
            var stringIdxCount = _stringIdx.Count;

            stringBuilder.Append(intCount);
            stringBuilder.Append('\n');
            stringBuilder.Append(floatCount);
            stringBuilder.Append('\n');
            stringBuilder.Append(floatIdxCount);
            stringBuilder.Append('\n');
            stringBuilder.Append(stringCount);
            stringBuilder.Append('\n');
            stringBuilder.Append(stringIdxCount);
            stringBuilder.Append('\n');

            for (int i = 0; i < intCount; i++)
            {
                stringBuilder.Append(_ints[i]);
                stringBuilder.Append('\n');
            }

            for (int j = 0; j < floatCount; j++)
            {
                stringBuilder.Append(_floats[j].ToString("R", NumberFormatInfo.InvariantInfo));
                stringBuilder.Append('\n');
            }

            for (int k = 0; k < floatIdxCount; k++)
            {
                stringBuilder.Append(_floatIdx[k]);
                stringBuilder.Append('\n');
            }

            for (int l = 0; l < stringCount; l++)
            {
                stringBuilder.Append(UnLinebreak(_strings[l]));
                stringBuilder.Append('\n');
            }

            for (int m = 0; m < stringIdxCount; m++)
            {
                stringBuilder.Append(_stringIdx[m]);
                stringBuilder.Append('\n');
            }

            return stringBuilder.ToString();
        }

        private string UnLinebreak(string s)
        {
            return s.Replace('\n', '|');
        }
    }
}
