using System.Linq;
using OCP.Solution.Domain;
using OCP.Solution.Specification;

namespace OCP.Solution
{
    public class UserManager
    {
        private readonly IUserStore userStore = new UserStore();

        public User[] GetUsers(ISpecification<User> spec) =>
            this.userStore.Users
                .Where(spec.IsSatisfiedBy)
                .ToArray();
    }
}