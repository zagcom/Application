using Application.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class CreateBudgetCategoryViewModel
    {
        public IEnumerable<Level1Category> Level1Categories { get; set; }
        public IEnumerable<Level2Category> Level2Categories { get; set; }
        public IEnumerable<Level3Category> Level3Categories { get; set; }
        public int Level1CategoryId { get; set; }
        public int Level2CategoryId { get; set; }
        public int Level3CategoryId { get; set; }   
        public string Name { get; set; }

    }
}
