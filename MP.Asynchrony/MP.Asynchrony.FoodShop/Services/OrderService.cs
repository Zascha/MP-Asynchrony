using MP.Asynchrony.FoodShop.Models;
using MP.Asynchrony.FoodShop.Repositories;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MP.Asynchrony.FoodShop.Services
{
    public class OrderService
    {
        private readonly OrderRepository _repository;

        public OrderService()
        {
            _repository = new OrderRepository();
        }

        public void CreateOrder()
        {
            var order = new Order();

            _repository.Insert(order);
        }

        public void UpdateOrder(Order order)
        {
            UpdateOrderAsync(order).Wait();
            CountOrderTotalCount(order);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            await Task.Run(() => _repository.Update(order))
                      .ContinueWith(prev => RecountOrderTotalSumAsync(order), 
                                    new CancellationTokenSource().Token,
                                    TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.NotOnFaulted,
                                    TaskScheduler.Current);
        }

        public void CountOrderTotalCount(Order order)
        {
            RecountOrderTotalSumAsync(order).Wait();
        }

        public async Task RecountOrderTotalSumAsync(Order order)
        {
            var sum = order.Products.Sum(item => item.Key.Price * item.Value);

            await Task.Run(() => { order.TotalPrice = sum; });
        }
    }
}
