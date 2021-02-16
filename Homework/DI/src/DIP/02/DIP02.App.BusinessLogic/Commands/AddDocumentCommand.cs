using System;
using DIP02.App.BusinessLogic.Commands.Abstractions;
using DIP02.App.Domain;

namespace DIP02.App.BusinessLogic.Commands
{
    public class AddDocumentCommand : AbstractCommand
    {
        public override string Name { get; set; } = "add";

        public override void Execute(string[] args)
        {
            var knownArguments = this.ParseArguments(args);
            var doc = new FileDocument();

            if (knownArguments.TryGetValue(CommandArguments.DocumentName, out var docName))
            {
                doc.Name = docName;
            }
            else
            {
                Console.WriteLine($"Please specify document name (e.g. {CommandArguments.DocumentName} <name>)");
                return;
            }

            if (knownArguments.TryGetValue(CommandArguments.Text, out var text))
            {
                doc.Text = text;
            }

            DocumentsManager.AddDocument(doc);
        }
    }
}