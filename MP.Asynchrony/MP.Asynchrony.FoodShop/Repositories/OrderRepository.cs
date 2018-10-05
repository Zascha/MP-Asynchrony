using MP.Asynchrony.FoodShop.Models;

namespace MP.Asynchrony.FoodShop.Repositories
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository() : base(Data.Orders) { }
    }
}
