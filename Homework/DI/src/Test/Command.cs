public interface ICommand
{
    void Eexcute();

    bool CanExecute { get; }

    Command Clone();
}

public class Command
{
    public string Name { get; set; }

    public void Execute() { }

    public bool CanExecute => true;

    public Command Clone() => new Command { Name = this.Name };
}