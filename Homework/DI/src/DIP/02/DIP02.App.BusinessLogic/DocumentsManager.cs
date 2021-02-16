using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DIP02.App.Data;
using DIP02.App.Domain;

namespace DIP02.App.BusinessLogic
{
    public static class DocumentsManager
    {
        // default storage
        private static readonly FileSystemProvider FileSystem = new FileSystemProvider();

        public static IEnumerable<IDocument> Documents 
            => new ReadOnlyCollection<IDocument>(GetAllDocuments());

        public static void AddDocument(IDocument document)
        {
            var docFileName = $"{document.Name}{FileDocument.FileExtension}";

            FileSystem.SaveToFile(docFileName, document.Text);
        }

        public static IDocument GetDocument(string name)
        {
            var docFileName = $"{name}{FileDocument.FileExtension}";
            var fileExists = FileSystem.TryReadFile(docFileName, out var text);

            if (!fileExists) return null;

            return new FileDocument
            {
                Name = name,
                Text = text
            };
        }

        public static void DeleteDocument(string name)
        {
            var docFileName = $"{name}{FileDocument.FileExtension}";

            FileSystem.DeleteFile(docFileName);
        }

        private static IList<IDocument> GetAllDocuments()
        {
            return FileSystem.EnumerateFiles().Select(name => new FileDocument
            {
                Name = name
            })
            .Cast<IDocument>()
            .ToList();
        }
    }
}