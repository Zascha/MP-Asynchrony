using MP.Asynchrony.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MP.Asynchrony.Database
{
    public abstract class Repository<T> : IRepository<int, T> where T : Entity
    {
        private readonly DbContext _context;

        protected Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<T> GetAll()
        {
            return GetAllAsync().Result;
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.Run(() => { return _context.Set<T>().AsEnumerable(); });
        }

        public T GetById(int id)
        {
            return GetByIdAsync(id).Result;
        }

        public Task<T> GetByIdAsync(int id)
        {
            return Task.Run(() => { return _context.Set<T>().SingleOrDefault(entity => entity.Id == id); });
        }

        public int Create(T entity)
        {
            return CreateAsync(entity).Result;
        }

        public async Task<int> CreateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return await Task.Run(() => { return _context.Set<T>().Add(entity).Id; });
        }

        public void Delete(int id)
        {
            DeleteAsync(id).Wait();
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Run(() => _context.Set<T>().Remove(GetById(id)));
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await Task.Run(() => {
                var entityToUpdate = GetById(entity.Id);
                _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
            });
        }
    }
}
