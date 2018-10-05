using System;

namespace MP.Asynchrony.FoodShop.Models
{
    public class Product : Entity
    {
        public Product(string title, decimal price)
        {
            Id = title.GetHashCode();
            Title = title;
            Price = price;
        }

        public string Title { get;}

        public decimal Price { get; }

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
            if (obj == null || !(obj is Product))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            Product item = (Product)obj;

            if (item.IsDefault() || IsDefault())
                return false;

            return Equals(item);
        }

        public override string ToString()
        {
            return $"{Title} ({Price} y.e)";
        }

        #endregion

        #region Private methods

        private bool IsDefault()
        {
            return string.IsNullOrEmpty(Title) && Price == default(decimal);
        }

        #endregion
    }
}
