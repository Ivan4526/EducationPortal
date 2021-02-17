using Interfaces;
using Microsoft.Data.SqlClient;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ADORepository<T> : IRepository<T> where T : BaseEntity
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        string sqlExpression;
        public async Task Create(T entity)
        {
            var type = typeof(T);
            var name = type.GetProperty("Name");
            var password = type.GetProperty("Password");
            sqlExpression = $"insert into Users (Name, Password) values ('{name.GetValue(entity)}', '{password.GetValue(entity)}')";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
              await connection.OpenAsync();
              SqlCommand command = new SqlCommand(sqlExpression, connection);
              command.ExecuteNonQuery();
           }
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> Read(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Read(int id)
        {
            int userId = 0;
            string sqlExpression = $"select * from Users where id = {id}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) 
                {
                    while (reader.Read()) 
                    {
                       userId = (int)reader.GetValue(0);
                    }
                }
                else
                    return null;
                reader.Close();
            }

            User user = new User { Id = userId };
            return user as T;
        }

        public Task<IEnumerable<T>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> ReadAll(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
