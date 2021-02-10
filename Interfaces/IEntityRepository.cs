using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IEntityRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task SaveChanges();
    }
}
