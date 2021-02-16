using System;
using DIP02.App.BusinessLogic.Commands.Abstractions;

namespace DIP02.App.BusinessLogic.Commands
{
    public class GetDocumentCommand : AbstractCommand
    {
        public override string Name { get; set; } = "get";

        public override void Execute(string[] args)
        {
            var knownArguments = this.ParseArguments(args);

            if (knownArguments.TryGetValue(CommandArguments.DocumentName, out var docName))
            {
                var doc = DocumentsManager.GetDocument(docName);

                if (doc == null)
                {
                    Console.WriteLine($"Document {docName} doesn't exist");
                    return;
                }

                Console.WriteLine(doc.Text);
            }
            else
            {
                Console.WriteLine($"Please specify document name (e.g. {CommandArguments.DocumentName} <name>)");
            }
        }
    }
}