using System;
using System.Collections.Generic;

namespace ShopingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value == string.Empty || value == null || value == " ")
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Products
        {
            get
            {
                return this.products;
            }
        }

        public void Buy(Product product)
        {

            if (this.money >= product.Cost)
            {
                products.Add(product);
                Console.WriteLine($"{this.name} bought {product.Name}");
                this.money -= product.Cost;
            }
            else
            {
                Console.WriteLine($"{this.name} can't afford {product.Name}");
            }

        }
    }
}
