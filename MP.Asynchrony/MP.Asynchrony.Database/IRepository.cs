using MP.Asynchrony.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MP.Asynchrony.Database
{
    public interface IRepository<TKey, T> where T: Entity
    {
        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        T GetById(TKey id);

        Task<T> GetByIdAsync(TKey id);

        TKey Create(T entity);

        Task<TKey> CreateAsync(T entity);

        void Update(T entity);

        Task UpdateAsync(T entity);

        void Delete(TKey id);

        Task DeleteAsync(TKey id);
    }
}
