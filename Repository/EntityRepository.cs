using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Repository
{
    public class EntityRepository<T> : IEntityRepository<T> where T : BaseEntity
    {
        private readonly Context context;
        private DbSet<T> entities;
        public EntityRepository(Context context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public async Task Create(T entity)
        {
            await entities.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(T entity)
        {
             entities.Remove(entity);
        }

        public async Task<T> Read(Expression<Func<T, bool>> predicate)
        {
            return await entities.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> Read(int id)
        {
            return await entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> ReadAll()
        {
            return await Task.FromResult(entities);
        }

        public async Task<IEnumerable<T>> ReadAll(Expression<Func<T, bool>> predicate)
        {
            return entities.Where(predicate);
        }

        public async Task Update(T entity)
        {
            context.SaveChanges();
        }
        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }
    }
}
