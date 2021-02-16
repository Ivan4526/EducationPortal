namespace DRY.Solution
{
    public abstract class BaseViewModel
    {
        private string name;
        public virtual string Name
        {
            get => this.name;
            set => this.name = value.Trim(' ').ToUpperInvariant();
        }
    }
}