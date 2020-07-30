using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Likhachev.Pgas.Data
{
    using Core.Abstractions;
    using System.Threading.Tasks;

    public class EFRepository<T> : IRepository<T>
        where T : Entity, new()
    {
        protected readonly PgasContext _db = new PgasContext();

        public EFRepository() {}

        public T GetById (int id) => _db.Set<T>().FirstOrDefault(e => e.Id == id);
        public async Task<T> GetByIdAsync(int id) => await _db.Set<T>().FirstOrDefaultAsync(e => e.Id == id);

        public IEnumerable<T> GetList(ISpecification<T> spec) => _db.Set<T>().Where(spec?.Criteria).ToList();
        public T Create(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public void Update(T entity)
        {
            _db.Entry(_db.Set<T>().FirstOrDefault(x => x.Id == entity.Id)).CurrentValues.SetValues(entity);
            _db.SaveChanges();
        }

        public async Task UpdateAsync(T entity) 
        {
            _db.Entry(await _db.Set<T>().FirstOrDefaultAsync(x => x.Id == entity.Id)).CurrentValues.SetValues(entity);
            await _db.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            T t = new T();
            t.SetId(id);
            _db.Set<T>().Attach(t);
            _db.Set<T>().Remove(t);
            _db.SaveChanges();
        }

    }
}
