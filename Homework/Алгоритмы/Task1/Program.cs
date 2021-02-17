using System;
using System.Buffers.Text;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Task1
{
    class Program
    {
        static char[] SplitNumbers(string input)//1
        {
            var numbers = input.ToCharArray();
            return numbers;
        }
        static string[] SplitFraction(string input)
        {
            return input.Split(',');
        }
        static int MinNumber(string number)
        {
            int min = 0;
            for (int i = 1; i < number.Length; i++)
                if (number[min] > number[i])
                    min = i;
            return min;
        }
        static int MaxNumber(int number)
        {
            int max = 0;
            while (number > 0)
            {
                if (max < number % 10) max = number % 10;
                number /= 10;
            }
            return max;
        }
        static string FindNumbersInString(string input)
        {
            int number;
            var symbols = input.ToCharArray();
            StringBuilder result = new StringBuilder(20);
            foreach(var symbol in symbols)
            {
                if (Int32.TryParse(symbol.ToString(), out number))
                {
                    result.Append(symbol);
                }
            }
            return result.ToString();
        }
        static DateTime ConvertStringToDateTime(string input)
        {
            return DateTime.Parse(input);
        }
        static string DeserializerUTF8(string input)
        {
            var utf8 = Encoding.UTF8;
            byte[] utfBytes = utf8.GetBytes(input);
            return utf8.GetString(utfBytes, 0, utfBytes.Length);
        }
        static void BubbleSort(int[] nums)
        {
            int temp;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }
        }
        static string[] SetToUpperRegister(string[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                var text = mas[0].Split(new char[] { ' ', '-' });
                string finalText = "";
                for (int q = 0; q < text.Length; q++)
                {
                    finalText = text[q].ToUpper() + " ";
                }
                mas[i] = finalText;
            }
            return mas;
        }
        public static void Compress(string sourceFile, string compressedFile)
        {
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream); // копируем байты из одного потока в другой
                    }
                }
            }
        }
        public static void Decompress(string compressedFile, string targetFile)
        {
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                using (FileStream targetStream = File.Create(targetFile))
                {
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            /////////////
            string input = Console.ReadLine();
            var numbers = SplitNumbers(input);
            foreach (var i in numbers) { Console.WriteLine(i); }
            //////
            string input1 = Console.ReadLine();
            var fractionNumbers = SplitFraction(input1);
            foreach (var i in fractionNumbers) { Console.WriteLine(i); }
            ////////
            string input2 = Console.ReadLine();
            Console.WriteLine("Min: " + MinNumber(input2));
            ////////
            Console.WriteLine("Max: " + MaxNumber(Int32.Parse(input2)));
            ///////
            Console.WriteLine("Type numbers and letters");
            string input3 = Console.ReadLine();
            string result = FindNumbersInString(input3);
            Console.WriteLine(result);
            ////////////
            string date = "2016 21-07";
            Console.WriteLine(ConvertStringToDateTime(date));
            ///////////////
            string[] mas = new string[] { "иван иванов", "светлана иванова-петренко" };
            var newMas = SetToUpperRegister(mas);
            //////////////
            string base64 = "0JXRgdC70Lgg0YLRiyDRh9C40YLQsNC10YjRjCDRjdGC0L7RgiDRgtC10LrRgdGCLCDQt9C90LDRh9C40YIg0LfQsNC00LDQvdC40LUg0LLRi9C / 0L7Qu9C90LXQvdC + INCy0LXRgNC90L4gOik =";
            Console.WriteLine(DeserializerUTF8(base64));
            ///////////////
            Random rand = new Random();
            int[] intNumbers = new int[39];
            for (int i = 0; i < intNumbers.Length; i++)
            {
                intNumbers[i] = rand.Next(0, 101);
            }
            BubbleSort(intNumbers);
            for(int i=0; i<intNumbers.Length; i++)
            {
                Console.WriteLine(intNumbers[i]);
            }
            ///////////////////////
            string sourceFile = "D://test/book.pdf"; 
            string compressedFile = "D://test/book.gz";
            string targetFile = "D://test/book_new.pdf";
            Compress(sourceFile, compressedFile);
            Decompress(compressedFile, targetFile);






        }
    }
}
