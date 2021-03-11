using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IValidator<T> where T : class
    {
        bool Validate(T entity);
    }
}
