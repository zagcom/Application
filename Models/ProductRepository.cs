using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ProductRepository> logger;

        public ProductRepository(AppDbContext context, ILogger<ProductRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public Product Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
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
            var model = context.Products.Include(p => p.BudgetCategory).ToList();
            return model;
        }

        public Product GetProduct(string Id)
        {
            

            return context.Products.Find(Id);
        }

        public Product Update(Product productChanges)
        {
            var product = context.Products.Attach(productChanges);
            product.State = EntityState.Modified;
            context.SaveChanges();
            return productChanges;
        }
    }
}
