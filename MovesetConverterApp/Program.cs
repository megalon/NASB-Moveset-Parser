using JsonConverter;
using MovesetParser;
using MovesetParser.BulkSerialize;

namespace MovesetConverterApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileToLoad = string.Empty;
            bool isDirectory = false;

            if (args.Length > 0)
            {
                var arg0 = args[0];

                if (File.Exists(arg0))
                {
                    fileToLoad = arg0;
                }
                else if (Directory.Exists(arg0))
                {
                    fileToLoad = arg0;
                    isDirectory = true;
                } 
            }

            while (string.IsNullOrEmpty(fileToLoad))
            {
                Console.Write("Input file name or folder to load: ");
                var input = Console.ReadLine().Replace("\"", "");
                if (File.Exists(input))
                {
                    fileToLoad = input;
                    break;
                }
                else if (Directory.Exists(input))
                {
                    fileToLoad = input;
                    isDirectory = true;
                    break;
                }
                Console.WriteLine("\nFile not found. Please try again...");
            }

            Moveset moveset = LoadMoveset(fileToLoad, isDirectory);

            while (true)
            {
                Console.WriteLine();

                Console.WriteLine("What would you like to do?");
                Console.WriteLine("  [1] Export moveset in BulkSerialize format");
                Console.WriteLine("  [2] Export moveset in JSON format");
                Console.WriteLine("  [3] Export moveset in Split JSON format");
                Console.Write("\nSelect an option: ");
                var input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        ExportSerializedMoveset(moveset, fileToLoad); return;
                    case "2":
                        ExportJsonMoveset(moveset, fileToLoad); return;
                    case "3":
                        ExportSplitJsonMOveset(moveset, fileToLoad); return;
                }
            }
        }

        private static Moveset LoadMoveset(string path, bool isDirectory)
        {
            var isBulkSerialized = (!isDirectory && File.ReadLines(path).First() == "BulkSerialize");

            if (isBulkSerialized)
                return Moveset.CreateFromFile(path);
            else if (isDirectory)
                return MovesetSerializer.FromFolder(path);
            else
                return MovesetSerializer.FromJsonFile(path);
        }

        private static void ExportSerializedMoveset(Moveset moveset, string fileName)
        {
            string outputPath = GetOutputPath(fileName, ".txt");

            Console.WriteLine($"Writing moveset to {outputPath}");

            var writer = new Writer();
            moveset.WriteSerial(writer);

            File.WriteAllText(outputPath, writer.GetString());

            Console.WriteLine("Successfully wrote moveset");
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        private static void ExportJsonMoveset(Moveset moveset, string fileName)
        {
            string outputPath = GetOutputPath(fileName, ".json");

            Console.WriteLine($"Writing moveset to {outputPath}");

            var json = MovesetSerializer.ToJsonString(moveset);

            File.WriteAllText(outputPath, json);

            Console.WriteLine("Successfully wrote moveset");
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        private static void ExportSplitJsonMOveset(Moveset moveset, string fileName)
        {
            string outputPath = GetOutputPath(fileName, string.Empty, true);

            Console.WriteLine($"Writing moveset to {outputPath}");

            Directory.CreateDirectory(outputPath);
            foreach (var file in Directory.GetFiles(outputPath))
            {
                if (Path.GetExtension(file) == ".json") File.Delete(file);
            }

            var jsonStrings = MovesetSerializer.ToSplitJsonStrings(moveset);
            Console.WriteLine();

            foreach (var (name, json) in jsonStrings)
            {
                var filePath = Path.Combine(outputPath, $"{name}.json");
                Console.WriteLine($"Writing {filePath}");
                File.WriteAllText(filePath, json);
            }

            Console.WriteLine();
            Console.WriteLine("Successfully wrote moveset");
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        private static string GetOutputPath(string fileName, string extension, bool isFolder = false)
        {
            fileName = Path.GetFileNameWithoutExtension(fileName) + extension;
            Console.Write($"Enter {(isFolder ? "folder path" : "filename")} ({fileName}): ");
            var outputPath = Console.ReadLine();
            if (string.IsNullOrEmpty(outputPath)) outputPath = fileName;
            Console.WriteLine();
            return outputPath;
        }
    }
}
