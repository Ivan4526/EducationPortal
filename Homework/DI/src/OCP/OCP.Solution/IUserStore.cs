using System.Collections.Generic;
using OCP.Solution.Domain;

namespace OCP.Solution
{
    public interface IUserStore
    {
        IEnumerable<User> Users { get; }
    }

    public class UserStore : IUserStore
    {
        public IEnumerable<User> Users { get; } = new List<User>();
    }
}