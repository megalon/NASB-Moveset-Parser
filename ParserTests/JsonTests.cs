using JsonConverter;
using MovesetParser;
using MovesetParser.BulkSerialize;
using System.Reflection;

namespace ParserTests
{
    [TestClass]
    public class JsonTests
    {
        [TestMethod]
        public void SerializeTest()
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ParserTests.Moveset_characterBase.txt");
            var streamReader = new StreamReader(stream);
            var inputText = streamReader.ReadToEnd();

            var moveset = Moveset.CreateFromString(inputText);

            var jsonString = MovesetSerializer.ToJsonString(moveset);

            Assert.IsFalse(string.IsNullOrEmpty(jsonString));
        }

        [TestMethod]
        public void DeserializeTest()
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ParserTests.Moveset_characterBase.txt");
            var streamReader = new StreamReader(stream);
            var inputText = streamReader.ReadToEnd();

            var movesetIn = Moveset.CreateFromString(inputText);

            var jsonString = MovesetSerializer.ToJsonString(movesetIn);

            var movesetOut = MovesetSerializer.FromJsonString(jsonString);

            Assert.IsFalse(movesetOut == null);
        }

        [TestMethod]
        public void WriteoutTest()
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ParserTests.Moveset_characterBase.txt");
            var streamReader = new StreamReader(stream);
            var inputText = streamReader.ReadToEnd();

            var movesetIn = Moveset.CreateFromString(inputText);

            var jsonString = MovesetSerializer.ToJsonString(movesetIn);

            var filePath = Path.Combine("C:\\Users\\Steven\\Desktop", "Moveset_characterBase.json");
            File.Delete(filePath);

            File.WriteAllText(filePath, jsonString);
        }
    }
}
