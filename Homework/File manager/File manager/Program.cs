using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Linq;
using System.Xml;

namespace File_manager
{
    class Program
    {
        static void ShowFiles(string path)
        {
            var directory = new DirectoryInfo(path);
            var files = directory.GetDirectories("*");
            foreach (var file in files)
            {
                if (!file.Attributes.HasFlag(FileAttributes.Hidden))
                    Console.WriteLine(file.Name);
            }
        }
        static bool OpenFile(string path)
        {
            var fileInfo = new FileInfo(path);
            if (fileInfo.Length >= 1024)
            {
                Console.WriteLine("Only read files with bytes <= 1024");
                return false;
            }
            var result = File.ReadAllText(path);
            Console.WriteLine(result);
            return true;
        }
        static void Main(string[] args)
        {
            Console.Write("Input path:");
            string path = Console.ReadLine();
            while (true) {
                Console.Write(path + " ");
                string command = Console.ReadLine();
                    if (command == "show")
                    {
                    ShowFiles($"{path}");
                    }else if(command.StartsWith("open"))
                    {
                    string fileName = command.Split(" ").LastOrDefault();
                    if (!OpenFile($"{path}/{fileName}"))
                        break;
                    }else if(command.StartsWith("change path")){
                        path = Console.ReadLine();
                    }
                    else if (command == "back")
                    {
                    path = path.Split(@"\").FirstOrDefault() + @"\";
                    }
                else
                {
                    Console.WriteLine("Enter a valid command");
                }
            }
        }
    }
}
