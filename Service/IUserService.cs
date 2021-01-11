using Models;
using System;
using System.Collections.Generic;

namespace Service
{
    public interface IUserService
    {
        void AddUser(User entity);
        IEnumerable<User> GetAllUsers();
        User GetUser(Func<User, bool> predicate);
        void UpdateUser(User entity);
        void DeleteUser(User entity);
    }
}
