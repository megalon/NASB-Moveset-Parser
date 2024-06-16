using MovesetParser;
using MovesetParser.BulkSerialize;
using System.Reflection;

namespace ParserTests
{
    [TestClass]
    public class DeserializeTests
    {
        private const int INT_COUNT = 26981;
        private const int FLOAT_COUNT = 48;
        private const int FLOAT_IDX_COUNT = 3136;
        private const int STRING_COUNT = 599;
        private const int STRING_IDX_COUNT = 3030;
        private const int STATE_COUNT = 255;

        [TestMethod]
        public void StreamTest()
        {
            var reader = new Reader(Assembly.GetExecutingAssembly().GetManifestResourceStream("ParserTests.Moveset_characterBase.txt"));

            Assert.AreEqual(INT_COUNT, reader.IntCount);
            Assert.AreEqual(FLOAT_COUNT, reader.FloatCount);
            Assert.AreEqual(FLOAT_IDX_COUNT, reader.FloatIdxCount);
            Assert.AreEqual(STRING_COUNT, reader.StringCount);
            Assert.AreEqual(STRING_IDX_COUNT, reader.StringIdxCount);
        }

        [TestMethod]
        public void StringTest()
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ParserTests.Moveset_characterBase.txt");
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
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ParserTests.Moveset_characterBase.txt");
            var moveset = Moveset.CreateFromStream(stream);

            Assert.AreEqual(STATE_COUNT, moveset.States.Length);
        }
    }
}