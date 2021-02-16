namespace DIP02.App.Domain
{
    public abstract class Document : IDocument
    {
        public string Name { get; set; }

        public string Text { get; set; }
    }
}