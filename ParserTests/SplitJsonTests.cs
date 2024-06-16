using JsonConverter;
using MovesetParser;
using MovesetParser.BulkSerialize;
using System.Reflection;

namespace ParserTests
{
    [TestClass]
    public class SplitJsonTests
    {
        [TestMethod]
        public void SerializeTest()
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ParserTests.Moveset_characterBase.txt");
            var streamReader = new StreamReader(stream);
            var inputText = streamReader.ReadToEnd();

            var moveset = Moveset.CreateFromString(inputText);

            var jsonStrings = MovesetSerializer.ToSplitJsonStrings(moveset);

            Assert.AreEqual(jsonStrings.Length, moveset.States.Length);
        }

        [TestMethod]
        public void DeserializeTest()
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ParserTests.Moveset_characterBase.txt");
            var streamReader = new StreamReader(stream);
            var inputText = streamReader.ReadToEnd();

            var movesetIn = Moveset.CreateFromString(inputText);

            var jsonStrings = MovesetSerializer.ToSplitJsonStrings(movesetIn);

            var movesetOut = MovesetSerializer.FromSplitJsonStrings(jsonStrings.Select(x => x.json).ToArray());

            Assert.AreEqual(movesetIn.States.Length, movesetOut.States.Length);
        }

        [TestMethod]
        public void WriteoutTest()
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ParserTests.Moveset_characterBase.txt");
            var streamReader = new StreamReader(stream);
            var inputText = streamReader.ReadToEnd();

            var movesetIn = Moveset.CreateFromString(inputText);

            var jsonStrings = MovesetSerializer.ToSplitJsonStrings(movesetIn);

            var directoryPath = Path.Combine("C:\\Users\\Steven\\Desktop", "Moveset_characterBase");
            Directory.CreateDirectory(directoryPath);

            foreach (var file in Directory.GetFiles(directoryPath))
            {
                if (Path.GetExtension(file) == ".json") File.Delete(file);
            }

            foreach (var (name, json) in jsonStrings)
            {
                var filePath = Path.Combine(directoryPath, $"{name}.json");
                File.WriteAllText(filePath, json);
            }

        }
    }
}
