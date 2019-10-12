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
        public List<Category> CategoryLevel1List { get; set; }
        public List<Category> CategoryLevel2List { get; set; }
        public List<Category> CategoryLevel3List { get; set; }

      

    }
}
