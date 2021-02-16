namespace DRY.Solution.ViewModels
{
    public class CustomerViewModel
    {
        private string name;
        public string Name
        {
            get => this.name;
            set => this.name = value.AdjustName();
        }
    }
}