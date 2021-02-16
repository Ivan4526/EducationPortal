using System;
using DIP02.App.BusinessLogic.Commands.Abstractions;

namespace DIP02.App.BusinessLogic.Commands
{
    public class DeleteDocumentCommand : AbstractCommand
    {
        public override string Name { get; set; } = "del";

        public override void Execute(string[] args)
        {
            var knownArguments = this.ParseArguments(args);

            if (knownArguments.TryGetValue(CommandArguments.DocumentName, out var docName))
            {
                DocumentsManager.DeleteDocument(docName);
            }
            else
            {
                Console.WriteLine($"Please specify document name (e.g. {CommandArguments.DocumentName} <name>)");
            }
        }
    }
}