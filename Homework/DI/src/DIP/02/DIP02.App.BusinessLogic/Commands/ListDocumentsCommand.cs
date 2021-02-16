using System;
using System.Linq;
using DIP02.App.BusinessLogic.Commands.Abstractions;

namespace DIP02.App.BusinessLogic.Commands
{
    public class ListDocumentsCommand : AbstractCommand
    {
        public override string Name { get; set; } = "list";

        public override void Execute(string[] args)
        {
            var docs = DocumentsManager.Documents
                .Select(doc => doc.Name)
                .ToArray();

            Array.ForEach(docs, Console.WriteLine);
        }
    }
}