using MovesetParser.BulkSerialize;
using System;

namespace MovesetParser
{
    public class ReadException : Exception
    {
        private readonly Reader reader;

        public ReadException(Reader r) : base() => reader = r;

        public ReadException(Reader r, string m) : base(m) => reader = r;

        public ReadException(Reader r, string m, Exception inner) : base(m, inner) => reader = r;

        public override string Message => base.Message + $" at reader int position: {reader.NextIntPosition}, float position: {reader.NextFloatPosition}, string position: {reader.NextStringPosition}";
    }
}
