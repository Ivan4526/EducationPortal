namespace SRP.Solution
{
    public class UserManager
    {
        private readonly IUserStore store;

        public UserManager(IUserStore store)
        {
            this.store = store;
        }

        public Result CreateUser(User user)
        {
            var userExists = this.store.FindUserByName(user.Name) != null;

            if (userExists)
            {
                return Result.Failed(error: $"The name {user.Name} is already taken");
            }

            this.store.AddUser(user);

            return Result.Success;
        }
    }
}