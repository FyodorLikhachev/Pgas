using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Likhachev.Pgas.Core.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Likhachev.Pgas.Data
{
    public class EFRepository<T> : IRepository<T>
        where T : Entity
    {
        private readonly DbContext _db = new PgasContext();

        public EFRepository() {}

        public T GetById (int id) => _db.Set<T>().FirstOrDefault(e => e.Id == id);
        public IEnumerable<T> GetList(ISpecification<T> spec) => _db.Set<T>().Where(spec?.Criteria).ToList();
        public T Create(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public void Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }
    }
}
