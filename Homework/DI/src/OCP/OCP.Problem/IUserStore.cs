using System.Collections.Generic;
using OCP.Problem.Domain;

namespace OCP.Problem
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