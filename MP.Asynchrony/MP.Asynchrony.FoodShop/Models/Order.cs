using System;
using System.Collections.Generic;

namespace MP.Asynchrony.FoodShop.Models
{
    public class Order : Entity
    {
        public Order()
        {
            Id = DateTime.UtcNow.GetHashCode();
        }

        public Dictionary<Product, int> Products { get; set; } = new Dictionary<Product, int>();

        public decimal TotalPrice { get; set; }

        #region Equality methods

        public override int GetHashCode()
        {
            if (!IsDefault())
            {
                return Id;
            }

            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Order))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            Order item = (Order)obj;

            if (item.IsDefault() || IsDefault())
                return false;

            return Equals(item);
        }

        #endregion

        #region Private methods

        private bool IsDefault()
        {
            return Products.Count == 0 && TotalPrice == default(decimal);
        }

        #endregion
    }
}
