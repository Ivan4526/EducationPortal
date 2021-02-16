namespace DIP02.App.BusinessLogic.Commands.Abstractions
{
    public interface ICommand
    {
        void Execute(string[] args);
    }
}