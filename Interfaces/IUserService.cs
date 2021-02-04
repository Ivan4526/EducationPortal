using Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUserService
    {
        Task CreateUser(User entity);
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<User>> GetAllUsers(Expression<Func<User, bool>> predicate);
        Task<User> GetUser(Expression<Func<User, bool>> predicate);
        Task<User> GetUser(int id);
        Task UpdateUser(User entity);
        Task DeleteUser(int id);
    }
}
