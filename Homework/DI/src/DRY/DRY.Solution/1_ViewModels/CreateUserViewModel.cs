namespace DRY.Solution.ViewModels
{
    public class CreateUserViewModel
    {
        private string name;
        public string Name
        {
            get => this.name;
            set => this.name = value.AdjustName();
        }
    }
}