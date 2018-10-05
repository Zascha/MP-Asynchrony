using MP.Asynchrony.Common.OutputManagers;
using MP.Asynchrony.Common.SafeExecuteManagers;
using MP.Asynchrony.FoodShop.Models;
using MP.Asynchrony.FoodShop.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP.Asynchrony.FoodShop.Client
{
    public partial class UIClient : Form
    {
        private WinFormOutputManager _outputManager;
        private ISafeExecuteManager _safeExecuteManager;
        private OrderService _orderService;
        private ProductsService _productsService;

        private Order _order;

        private object lockObject = new object();

        public UIClient()
        {
            InitializeComponent();

            _outputManager = new WinFormOutputManager { OutSource = errorLabel };
            _safeExecuteManager = new SafeExecuteManager(_outputManager);
            _orderService = new OrderService();
            _productsService = new ProductsService();

            productsListBox.DataSource = _productsService.GetAllProducts();
            _order = new Order();
        }
        
        private void orderButton_Click(object sender, EventArgs e)
        {
            var item = (Product)productsListBox.SelectedItem;
            AddOrIncrementOrderProducts(item);

            _safeExecuteManager.ExecuteWithExceptionHandling(() =>
            {
                _orderService.UpdateOrderAsync(_order)
                             .ContinueWith(prev => RefreshOrderData(), 
                                           new CancellationTokenSource().Token,
                                           TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.NotOnFaulted,
                                           TaskScheduler.FromCurrentSynchronizationContext());
            });
        }

        private void removeFromOrderButton_Click(object sender, EventArgs e)
        {
            var item = (Product)productsListBox.SelectedItem;

            if (item == null)
                _outputManager.DisplayMessage("Some invalid selected product.");

            _order.Products.Remove(item);

            _safeExecuteManager.ExecuteWithExceptionHandling(() =>
            {
                _orderService.UpdateOrderAsync(_order)
                             .ContinueWith(prev => RefreshOrderData(),
                                           new CancellationTokenSource().Token,
                                           TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.NotOnFaulted,
                                           TaskScheduler.FromCurrentSynchronizationContext());
            });
        }

        #region Private methods

        private void AddOrIncrementOrderProducts(Product product)
        {
            if (product == null)
                _outputManager.DisplayMessage("Some invalid selected product.");

            lock(lockObject)
            {
                if (!_order.Products.Keys.Contains(product))
                {
                    _order.Products.Add(product, 0);
                }

                _order.Products[product]++;
            }
        }

        private void RefreshOrderData()
        {
            totalCountLabel.Text = _order.TotalPrice.ToString();

            orderListBox.DataSource = null;
            orderListBox.Items.Clear();

            orderSource.DataSource = _order.Products.Select(item => $"{item.Key.Title} - {item.Value} items.").ToList();

            orderListBox.DataSource = orderSource;
        }

        #endregion
    }
}
