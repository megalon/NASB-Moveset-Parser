using JsonConverter.Converters;
using MovesetParser;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Diagnostics;

namespace JsonConverter
{
    public static class MovesetSerializer
    {
        private static readonly JsonSerializer serializer = new JsonSerializer()
        {
            Formatting = Formatting.Indented,
            Converters =
            {
                new CheckThingConverter(),
                new FloatSourceConverter(),
                new JumpConverter(),
                new ObjectSourceConverter(),
                new StateActionConverter(),
                new Vector3Converter(),
                new StringEnumConverter()
            }
        };

        public static string ToJsonString(Moveset moveset)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            using var stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, moveset);

            stopwatch.Stop();
            Console.WriteLine($"Serialized moveset to JSON in {stopwatch.ElapsedMilliseconds} ms.");
            return stringWriter.ToString();
        }

        public static (string name, string json)[] ToSplitJsonStrings(Moveset moveset)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var results = new (string, string)[moveset.States.Length];

            for(int i = 0; i < moveset.States.Length; i++)
            {
                using var stringWriter = new StringWriter();
                var state = moveset.States[i];
                var stateName = state.Id;
                serializer.Serialize(stringWriter, state);
                results[i] = (stateName, stringWriter.ToString());
            }

            stopwatch.Stop();
            Console.WriteLine($"Serialized moveset to split JSON in {stopwatch.ElapsedMilliseconds} ms.");
            return results;
        }

        public static Moveset FromJsonString(string json)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            using var stringReader = new StringReader(json);
            using var jsonReader = new JsonTextReader(stringReader);
            var moveset = serializer.Deserialize<Moveset>(jsonReader);

            stopwatch.Stop();
            Console.WriteLine($"Deserialized moveset from JSON in {stopwatch.ElapsedMilliseconds} ms.");
            return moveset;
        }

        public static Moveset FromJsonFile(string filePath)
        {
            return FromJsonString(File.ReadAllText(filePath));
        }

        public static Moveset FromSplitJsonStrings(string[] jsons)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var moveset = new Moveset
            {
                States = new IdState[jsons.Length]
            };

            for (int i = 0; i < jsons.Length; i++)
            {
                using var stringReader = new StringReader(jsons[i]);
                using var jsonReader = new JsonTextReader(stringReader);
                var state = serializer.Deserialize<IdState>(jsonReader);

                moveset.States[i] = state;
            }

            stopwatch.Stop();
            Console.WriteLine($"Deserialized moveset from split JSON in {stopwatch.ElapsedMilliseconds} ms.");
            return moveset;
        }

        public static Moveset FromFolder(string directory)
        {
            var files = Directory.GetFiles(directory).Where(x => Path.GetExtension(x).Equals(".json", StringComparison.CurrentCultureIgnoreCase)).ToArray();
            var allJsons = new string[files.Length];

            for (int i = 0; i < files.Length; i++)
            {
                allJsons[i] = File.ReadAllText(files[i]);
            }

            return FromSplitJsonStrings(allJsons);
        }
    }
}
