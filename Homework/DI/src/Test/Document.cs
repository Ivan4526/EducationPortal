using System;
using System.IO;

public interface IDocument
{
    string Text { get; set; }

    void Save(string filename);
}

public class Document : IDocument
{
    public string Text { get; set; }

    public void Save(string filename) => File.WriteAllText(filename, this.Text);
}

public class FileDocument : IDocument
{
    public string FileName { get; set; }

    public string Text { get; set; }

    public void Save() => File.WriteAllText(this.FileName, this.Text);

    public void Save(string filename) => this.Save();
}

public class InMemoryDocument : IDocument
{
    public string Text { get; set; }

    public void Save(string filename) => throw new NotSupportedException();
}