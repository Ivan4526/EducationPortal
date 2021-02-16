using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DIP02.App.Data
{
    public class FileSystemProvider
    {
        private readonly string baseDirectory =
            Path.Combine(
                Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
                "data");

        public FileSystemProvider()
        {
            if (!Directory.Exists(this.baseDirectory))
            {
                Directory.CreateDirectory(this.baseDirectory);
            }
        }

        public void SaveToFile(string filename, string text)
        {
            var filePath = Path.Combine(this.baseDirectory, filename);

            File.WriteAllText(filePath, text);
        }

        public bool TryReadFile(string filename, out string text)
        {
            var filePath = Path.Combine(this.baseDirectory, filename);
            var fileExists = File.Exists(filePath);

            text = fileExists
                ? File.ReadAllText(filePath)
                : null;

            return fileExists;
        }

        public void DeleteFile(string filename)
        {
            var filePath = Path.Combine(this.baseDirectory, filename);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public IEnumerable<string> EnumerateFiles()
        {
            return Directory.EnumerateFiles(this.baseDirectory)
                .Select(Path.GetFileNameWithoutExtension)
                .AsEnumerable();
        }
    }
}