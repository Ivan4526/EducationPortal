namespace DRY.Problem
{
    public class ProductViewModel
    {
        private string name;
        public string Name
        {
            get => this.name;
            set => this.name = value.Trim(' ').ToUpperInvariant();
        }
    }
}