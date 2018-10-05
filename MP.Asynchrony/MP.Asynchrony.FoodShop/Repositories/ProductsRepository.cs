using MP.Asynchrony.FoodShop.Models;

namespace MP.Asynchrony.FoodShop.Repositories
{
    public class ProductsRepository : Repository<Product>
    {
        public ProductsRepository() : base(Data.Products) { }
    }
}
