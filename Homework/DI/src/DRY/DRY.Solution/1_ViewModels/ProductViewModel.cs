namespace DRY.Solution.ViewModels
{
    public class ProductViewModel
    {
        private string name;
        public string Name
        {
            get => this.name;
            set => this.name = value.AdjustName();
        }
    }
}