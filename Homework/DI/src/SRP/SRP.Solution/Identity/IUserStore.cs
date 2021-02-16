namespace SRP.Solution
{
    public interface IUserStore
    {
        User FindUserByName(string name);

        void AddUser(User user);
    }
}