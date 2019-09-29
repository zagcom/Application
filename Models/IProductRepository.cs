﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface IProductRepository
    {
        Product GetProduct(int Id);
        IEnumerable<Product> GetAllProduct();
        Product Add(Product employee);
        Product Update(Product employeeChanges);
        Product Delete(int id);
    }
}
