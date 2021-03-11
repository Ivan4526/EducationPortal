using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public class EntityRepository<T> : IRepository<T> where T : BaseEntity
    {
        private Context context;
        private DbSet<T> entities;
        private readonly ILogger logger;
        public EntityRepository(Context context, ILogger<EntityRepository<T>> logger)
        {
            this.context = context;
            entities = context.Set<T>();
            this.logger = logger;
        }
        public Task Create(T entity)
        {
            return Task.Run(() => {
                  try
                  {
                      entities.Add(entity);
                  }catch(Exception e)
                  {
                      logger.LogError(e.Message);
                  }
            });
        }
        public Task CreateRange(IEnumerable<T> entityList)
        {
            return Task.Run(() =>
            {
                try { 
                    entities.AddRange(entityList); 
                }
                catch(Exception e)
                {
                    logger.LogError(e.Message);
                }
                
            });
        }

        public Task Delete(int id)
        {
            throw new NotSupportedException();
        }

        public Task Delete(T entity)
        {
            return Task.Run(() => {
                try
                {
                    entities.Remove(entity);
                }catch(Exception e)
                {
                    logger.LogError(e.Message);
                }
            });
        }

        public Task<T> Read(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return Task.Run(() =>
                {
                    return entities.FirstOrDefault(predicate);
                });
            }catch(Exception e)
            {
                logger.LogError(e.Message);
                return Task.FromException<T>(e);
            }
        }
        public Task<T> Read(Expression<Func<T, bool>> predicate, string includeProperty)
        {
            try
            {
                return Task.Run(() =>
                {
                    return entities.Include(includeProperty).FirstOrDefault(predicate);
                });
            }catch(Exception e)
            {
                logger.LogError(e.Message);
                return Task.FromException<T>(e);
            }
        }

        public Task<T> Read(int id)
        {
            try
            {
                return Task.Run(() =>
                {
                    return entities.FirstOrDefault(x => x.Id == id);
                });
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return Task.FromException<T>(e);
            }

        }

        public Task<IEnumerable<T>> ReadAll()
        {
            try
            {
                var task = Task.Run(() =>
                {
                    return entities.AsEnumerable();
                });
                return task;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return Task.FromException<IEnumerable<T>>(e);
            }
        }

        public Task<IEnumerable<T>> ReadAll(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return Task.Run(() =>
                {
                    return entities.Where(predicate).AsEnumerable();
                });
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return Task.FromException<IEnumerable<T>>(e);
            }
        }

        public Task<IEnumerable<T>> PagingReadAll(int page)
        {
            try
            {
                int pageSize = 3;
                return Task.Run(() =>
                {
                    var pagingResult = entities.Skip((page - 1) * pageSize).Take(pageSize).AsEnumerable();
                    return pagingResult;
                });
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return Task.FromException<IEnumerable<T>>(e);
            }
        }
        public Task<IEnumerable<T>> PagingReadAll(int page, string includeProperty)
        {
            try
            {
                int pageSize = 3;
                return Task.Run(() =>
                {
                    var pagingResult = entities.Include(includeProperty).Skip((page - 1) * pageSize).Take(pageSize).AsEnumerable();
                    return pagingResult;
                });
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return Task.FromException<IEnumerable<T>>(e);
            }
        }
        public Task<IEnumerable<T>> PagingReadAll(Expression<Func<T, bool>> predicate, int page)
        {
            try
            {
                int pageSize = 3;
                return Task.Run(() =>
                {
                    var pagingResult = entities.Where(predicate).Skip((page - 1) * pageSize).Take(pageSize).AsEnumerable();
                    return pagingResult;
                });
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return Task.FromException<IEnumerable<T>>(e);
            }
        }
        public Task<IEnumerable<T>> PagingReadAll(Expression<Func<T, bool>> predicate, int page, string includeProperty)
        {
            try
            {
                int pageSize = 3;
                return Task.Run(() =>
                {
                    var pagingResult = entities.Include(includeProperty).Where(predicate).Skip((page - 1) * pageSize).Take(pageSize).AsEnumerable();
                    return pagingResult;
                });
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return Task.FromException<IEnumerable<T>>(e);
            }
        }

        public Task Update(T entity)
        {
            try
            {
                return Task.Run(() =>
                {
                    entities.Update(entity);
                });
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return Task.FromException<T>(e);
            }
        }
        public Task SaveChanges()
        {
            try
            {
                return Task.Run(() =>
                {
                    context.SaveChanges();
                });
            }catch(Exception e)
            {
                logger.LogError(e.Message);
                return Task.FromException<T>(e);
            }
        }
    }
}
