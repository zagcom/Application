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
            throw new NotImplementedException();
        }

        public Product Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProduct()
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int Id)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product employeeChanges)
        {
            throw new NotImplementedException();
        }
    }
}
