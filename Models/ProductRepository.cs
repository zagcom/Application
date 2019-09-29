using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Product Add(Product employee)
        {
            context.Products.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Product Delete(string id)
        {
            Product product = context.Products.Find(id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return product;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return context.Products;
        }

        public Product GetProduct(string Id)
        {
            return context.Products.Find(Id);
        }

        public Product Update(Product productChanges)
        {
            var product = context.Products.Attach(productChanges);
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return productChanges;
        }
    }
}
