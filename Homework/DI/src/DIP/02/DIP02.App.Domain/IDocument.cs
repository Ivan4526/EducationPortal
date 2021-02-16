namespace DIP02.App.Domain
{
    public interface IDocument
    {
        string Name { get; set; }

        string Text { get; set; }
    }
}