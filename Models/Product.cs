using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Product
    {
        public string id { get; set; }
        [Required]
        public string Name { get; set; }
        public string EAN { get; set; }
        [Required]
        public Unit? Unit { get; set; }
        public float Qty { get; set; }
        public string PhotoPath { get; set; }
    }
}
