using MP.Asynchrony.FoodShop.Models;
using System.Collections.Generic;

namespace MP.Asynchrony.FoodShop
{
    internal static class Data
    {
        internal static List<Product> Products { get; set; } = new List<Product>
        {
            new Product("Tea", 2),
            new Product("Latte", 10),
            new Product("Capuchino", 7),
            new Product("Americano", 5),
            new Product("Cookee", 3),
            new Product("Cupcake", 5)
        };

        internal static List<Order> Orders { get; set; } = new List<Order>();
    }
}
