﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface IProductRepository
    {
        Product GetProduct(string Id);
        IEnumerable<Product> GetAllProduct();
        Product Add(Product product);
        Product Update(Product productChanges);
        Product Delete(string id);
    }
}
