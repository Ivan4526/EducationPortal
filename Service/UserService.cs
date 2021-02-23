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
        IRepository<User> userRepository;
        IRepository<Role> roleRepository;
        IRepository<Course> courseRepository;
        IPasswordHasher hasher;

        public UserService(IRepository<User> userRepository, IRepository<Role> roleRepository, IRepository<Course> courseRepository, IPasswordHasher hasher)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.courseRepository = courseRepository;
            this.hasher = hasher;
        }

        public async Task CreateUser(User user)
        {
            user.RoleId = 1;
            user.Password = hasher.ComputeHash(user.Password);;
            await userRepository.Create(user);
            await userRepository.SaveChanges();
            var role = await roleRepository.Read(r => r.Id == user.RoleId);
            user.Role = role;
        }

        public async Task DeleteUser(int id)
        {
            await userRepository.Delete(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers(Expression<Func<User, bool>> predicate)
        {
            return await userRepository.ReadAll(predicate);
        }

        public async Task<User> GetUser(User userData)
        {
            var user = await userRepository.Read(u => u.Email == userData.Email && u.Password == userData.Password);
            var role = await roleRepository.Read(r => r.Id == user.RoleId);
            user.Courses = user.Courses;//Lazy loading
            user.Role = role;
            return user;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await userRepository.Read(u => u.Id == id);
            var role = await roleRepository.Read(r => r.Id == user.RoleId);
            user.Courses = user.Courses;//Lazy loading
            user.Role = role;
            return user;
        }

        public async Task UpdateUser(User user)
        {
            await userRepository.Update(user);
        }
        public async Task SaveChanges()
        {
            await userRepository.SaveChanges();
        }
    }
}
