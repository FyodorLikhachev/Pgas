using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Likhachev.Pgas.Core.Abstractions
{
    public interface IRepository<T> where T : Entity
    {
        T GetById (int id);
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetList (ISpecification<T> spec = null);
        T Create (T entity);
        void Update (T entity);
        Task UpdateAsync(T entity);
        void Delete (int id);
    }
}
