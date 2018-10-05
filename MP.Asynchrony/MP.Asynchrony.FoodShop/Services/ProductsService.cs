using MP.Asynchrony.FoodShop.Models;
using MP.Asynchrony.FoodShop.Repositories;
using System.Collections.Generic;

namespace MP.Asynchrony.FoodShop.Services
{
    public class ProductsService
    {
        private readonly ProductsRepository _repository;

        public ProductsService()
        {
            _repository = new ProductsRepository();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAll();
        }
    }
}
