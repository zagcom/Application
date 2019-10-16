using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Purchase
    {
        public string Id { get; set; }
        public Product Product { get; set; }
        public string ProductId { get; set; }
        public BudgetCategory BudgetCategory { get; set; }
        public int BudgetCategoryId { get; set; }
        public float Qty { get; set; }
        public float PricePerUnit { get; set; }
        public float TotalPrice { get; set; }
    }
}
