using System;
using System.IO;

namespace PqSave
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                PrintUsage();
                return;
            }

            try
            {
                Run(args);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error reading files");
                Console.WriteLine(ex.Message);
            }
        }

        private static void Run(string[] args)
        {
            char mode = '\0';
            string key = null;
            string keyfile = null;
            string inputPath = null;
            string outputPath = null;
            string[] scripts = new string[args.Length];
            int fileCount = 0;
            int scriptCount = 0;

            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i];
                switch (arg)
                {
                    case "d":
                    case "e":
                    case "x":
                    case "i":
                    case "s":
                        mode = arg[0];
                        break;
                    case "-k":
                    case "--key":
                        i++;
                        key = args[i];
                        break;
                    case "--keyfile":
                        i++;
                        keyfile = args[i];
                        break;
                    default:
                        if (fileCount == 0)
                        {
                            inputPath = arg;
                            fileCount++;
                        }
                        else if (fileCount == 1)
                        {
                            outputPath = arg;
                            fileCount++;
                        }
                        else
                        {
                            scripts[scriptCount++] = arg;
                        }
                        break;
                }
            }

            if (keyfile != null)
            {
                foreach (var line in File.ReadLines(keyfile))
                {
                    if (line.Length == 16)
                    {
                        key = line;
                    }
                }
            }
            if (inputPath == null || outputPath == null)
            {
                PrintUsage();
                return;
            }

            switch (mode)
            {
                case 'd':
                    var encSave = File.ReadAllBytes(inputPath);
                    if (key != null)
                        Encryption.key = key;
                    File.WriteAllBytes(outputPath, Encryption.DecryptSave(encSave));
                    break;
                case 'e':
                    var decSave = File.ReadAllBytes(inputPath);
                    File.WriteAllBytes(outputPath, Encryption.EncryptSave(decSave));
                    break;
                case 'x':
                    var savex = new SaveManager(File.ReadAllBytes(inputPath));
                    var output = Json.Serialize(savex);
                    File.WriteAllText(outputPath, output);
                    break;
                case 'i':
                    string import = File.ReadAllText(inputPath);
                    SaveManager savei = Json.DeSerialize(import);
                    File.WriteAllBytes(outputPath, savei.Export());
                    break;
                case 's':
                    var save = new SaveManager(File.ReadAllBytes(inputPath));

                    for (int i = 0; i < scriptCount; i++)
                    {
                        Scripting.RunScript(save.SerializeData, scripts[i]);
                    }

                    File.WriteAllBytes(outputPath, save.Export());
                    break;
                default:
                    PrintUsage();
                    return;
            }

        }

        private static void PrintUsage()
        {
            Console.WriteLine("Usage: pqsave mode [option arg]... input output [script1 (In script mode only)] [script2]...");
            Console.WriteLine("  modes:");
            Console.WriteLine("    d Decrypt save");
            Console.WriteLine("    e Encrypt save");
            Console.WriteLine("    x Export save to JSON");
            Console.WriteLine("    i Import save from JSON");
            Console.WriteLine("    s Script - Run scripts on an encrypted save");
            Console.WriteLine("  options:");
            Console.WriteLine("    -k,--key Set key, default is the key of switch version");
            Console.WriteLine("             When you use '--keyfile', use the key in file first");
            Console.WriteLine("    --keyfile From file import key");
        }
    }
}
