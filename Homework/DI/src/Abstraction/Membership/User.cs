namespace Membership
{
    public abstract class User<T> : IUser<T>
    {
        public abstract T Id { get; set; }
    }

    public abstract class ApplicationUser : User<int>
    {
        public abstract string Name { get; set; }
    }

    public class MyAppUser : ApplicationUser
    {
        public override int Id { get; set; }

        public override string Name { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}