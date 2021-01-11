using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public void AddUser(User user)
        {
            user.Password = hasher.ComputeHash(user.Password);
            repository.Create(user);
        }
        public IEnumerable<User> GetAllUsers()
        {
            return repository.ReadAll();
        }
        public User GetUser(Func<User, bool> predicate)
        {
            return repository.ReadAll().FirstOrDefault(predicate);
        }
        public void UpdateUser(User user)
        {
            repository.Update(user);
        }
        public void DeleteUser(User user)
        {
            repository.Delete(user); 
        }
    }
}
