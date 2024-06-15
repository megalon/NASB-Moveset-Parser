using MovesetParser;
using MovesetParser.BulkSerialize;
using System.Reflection;

namespace ParserTests
{
    [TestClass]
    public class DeserializeTests
    {
        private const int INT_COUNT = 3522;
        private const int FLOAT_COUNT = 77;
        private const int FLOAT_IDX_COUNT = 1025;
        private const int STRING_COUNT = 172;
        private const int STRING_IDX_COUNT = 622;
        private const int STATE_COUNT = 28;

        [TestMethod]
        public void StreamTest()
        {
            var reader = new Reader(Assembly.GetExecutingAssembly().GetManifestResourceStream("ParserTests.char_flex.txt"));

            Assert.AreEqual(INT_COUNT, reader.IntCount);
            Assert.AreEqual(FLOAT_COUNT, reader.FloatCount);
            Assert.AreEqual(FLOAT_IDX_COUNT, reader.FloatIdxCount);
            Assert.AreEqual(STRING_COUNT, reader.StringCount);
            Assert.AreEqual(STRING_IDX_COUNT, reader.StringIdxCount);
        }

        [TestMethod]
        public void StringTest()
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ParserTests.char_flex.txt");
            var streamReader = new StreamReader(stream);
            var inputText = streamReader.ReadToEnd();
            var reader = new Reader(inputText);

            Assert.AreEqual(INT_COUNT, reader.IntCount);
            Assert.AreEqual(FLOAT_COUNT, reader.FloatCount);
            Assert.AreEqual(FLOAT_IDX_COUNT, reader.FloatIdxCount);
            Assert.AreEqual(STRING_COUNT, reader.StringCount);
            Assert.AreEqual(STRING_IDX_COUNT, reader.StringIdxCount);
        }

        [TestMethod]
        public void StatesCountTest()
        {
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ParserTests.char_flex.txt");
            var moveset = Moveset.CreateFromStream(stream);

            Assert.AreEqual(STATE_COUNT, moveset.States.Length);
        }
    }
}