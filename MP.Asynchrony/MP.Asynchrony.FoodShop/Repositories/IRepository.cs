using System;
using System.Collections.Generic;
using System.Linq;
namespace MP.Asynchrony.FoodShop.Repositories
{
    public interface IRepository<KeyT, T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(KeyT value);

        void Insert(T item);

        void Delete(T item);

        void Update(T item);
    }
}
