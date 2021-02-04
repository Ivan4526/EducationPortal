using Interfaces;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        IRepository<User> repository;
        IPasswordHasher hasher;

        public UserService(IRepository<User> repository, IPasswordHasher hasher)
        {
            this.repository = repository;
            this.hasher = hasher;
        }

        public async Task CreateUser(User user)
        {
            user.Password = hasher.ComputeHash(user.Password);
            await repository.Create(user);
        }

        public async Task DeleteUser(int id)
        {
            await repository.Delete(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await repository.ReadAll();
        }

        public async Task<IEnumerable<User>> GetAllUsers(Expression<Func<User, bool>> predicate)
        {
            return await repository.ReadAll();
        }

        public async Task<User> GetUser(Expression<Func<User, bool>> predicate)
        {
            return await repository.Read(predicate);
        }

        public async Task<User> GetUser(int id)
        {
            return await repository.Read(id);
        }

        public async Task UpdateUser(User user)
        {
            await repository.Update(user);
        }
    }
}
