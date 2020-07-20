using System;
using System.Collections.Generic;
using System.Text;

namespace Likhachev.Pgas.Core.Abstractions
{
    public interface IRepository<T> where T : Entity
    {
        T GetById (int id);
        IEnumerable<T> GetList (ISpecification<T> spec = null);
        T Create (T entity);
        void Update (T entity);
        void Delete (T entity);
    }
}
