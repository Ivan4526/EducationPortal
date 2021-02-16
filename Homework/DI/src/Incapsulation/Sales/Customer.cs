namespace Sales
{
    public class Customer
    {
        private string firstName = string.Empty;
        private string lastName = string.Empty;

        internal int Id { get; set; }

        internal string FullName => $"{this.FirstName} {this.LastName}".Trim(' ');

        public string FirstName
        {
            get => this.firstName;
            set => this.firstName = this.AdjustName(value);
        }

        public string LastName
        {
            get => this.lastName;
            set => this.lastName = this.AdjustName(value);
        }

        public override string ToString() => this.FullName;

        protected virtual string AdjustName(string name)
        {
            return name?.Trim(' ');
        }
    }
}