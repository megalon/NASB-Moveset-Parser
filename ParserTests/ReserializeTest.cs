using MovesetParser;
using MovesetParser.BulkSerialize;
using System.Reflection;

namespace ParserTests
{
    [TestClass]
    public class ReserializeTest
    {
        [TestMethod]
        public void Test()
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ParserTests.Moveset_characterBase.txt");
            var streamReader = new StreamReader(stream);
            var inputText = streamReader.ReadToEnd();

            var moveset = Moveset.CreateFromString(inputText);

            var writer = new Writer();
            moveset.WriteSerial(writer);

            Assert.AreEqual(inputText, writer.GetString());
        }
    }
}
