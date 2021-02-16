namespace Membership
{
    public interface IUser
    {
    }

    public interface IUser<T> : IUser
    {
        T Id { get; set; }
    }
}