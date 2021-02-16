using System;
using System.Text;
using YAGNI.App.Services;

namespace YAGNI.App
{
    internal class Program
    {
        private static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("What city you would like to get the weather for?");
            Console.Write("> ");

            var replaceService = new RussianToEnglishReplaceService();
            var city = replaceService.Replace(ReadLineUtf());

            Console.WriteLine($"The weather in {city} is 15 °C");
        }

        private static string ReadLineUtf()
        {
            ConsoleKeyInfo currentKey;

            var sBuilder = new StringBuilder();
            do
            {
                currentKey = Console.ReadKey();

                if (currentKey.Key != ConsoleKey.Enter)
                    sBuilder.Append(currentKey.KeyChar);

            }
            while (currentKey.Key != ConsoleKey.Enter);

            Console.WriteLine();

            return sBuilder.ToString();
        }
    }
}
