using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace CSV
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfFields = Console.ReadLine();
            string[] fields = nameOfFields.Split(',');
            var personList = PersonList.GetListPerson();
            StringBuilder builder = new StringBuilder();
            foreach (var person in personList)
            {
                for (int q = 0; q < fields.Length; q++)
                {
                    builder.Append($"{person[fields[q]]}\n");
                }
            }
            string filePath = @"D:\test.csv";
            File.WriteAllText(filePath, builder.ToString());

        }
    }
}
