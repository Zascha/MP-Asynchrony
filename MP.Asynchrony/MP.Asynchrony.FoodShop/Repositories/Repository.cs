using MP.Asynchrony.FoodShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MP.Asynchrony.FoodShop.Repositories
{
    public abstract class Repository<T> : IRepository<int, T> where T : Entity
    {
        private List<T> _source;

        protected Repository(IEnumerable<T> source)
        {
            _source = source?.ToList() ?? throw new ArgumentNullException(nameof(source));
        }

        public void Delete(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _source.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return _source;
        }

        public T GetById(int value)
        {
            return _source.SingleOrDefault(item => item.Id.Equals(value));
        }

        public void Insert(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _source.Add(item);
        }

        public void Update(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var itemToUpdate = GetById(item.Id);
            itemToUpdate = item;
        }
    }
}
