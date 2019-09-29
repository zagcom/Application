﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Name = "Oranżada Fantazja Czerwona 330ml",
                    Unit = Unit.Each,
                    Qty = 1,
                    EAN = "5902294001518"
                },
                new Product
                {
                    Name = "Oranżada Fantazja Orange 330ml",
                    Unit = Unit.Each,
                    Qty = 1,
                    EAN = "5902294004960"
                }
            );
        }
    }
}
