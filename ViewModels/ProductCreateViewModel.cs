using Application.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ProductCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        public string EAN { get; set; }
        [Required]
        public Unit? Unit { get; set; }
        public float Qty { get; set; }
        public IFormFile Photo { get; set; }
    }
}
