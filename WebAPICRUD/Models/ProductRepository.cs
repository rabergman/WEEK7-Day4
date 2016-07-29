using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPICRUD.Models
{
    public class ProductRepository : IProductRepository
    {
        List<Product> products = new List<Product>();
        private int _nextId = 1;

        public ProductRepository()
        {
            Add(new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1.5M, InStock = true });
            Add(new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M, InStock = true });
            Add(new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M, InStock = false });
            Add(new Product { Id = 4, Name = "Screwdriver", Category = "Hardware", Price = 6.99M, InStock = true });
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public Product Get(int id)
        {
            return products.Find(p => p.Id == id);
        }

        public Product Add(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            item.Id = _nextId++;
            products.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            products.RemoveAll(p => p.Id == id);
        }

        public bool Update(Product item)
        {
            if (item == null)
                throw new ArgumentNullException();

            int index = products.FindIndex(p => p.Id == item.Id);
            if (index == -1)
                return false;

            products.RemoveAt(index);
            products.Add(item);
            return true;
        }
    }
}