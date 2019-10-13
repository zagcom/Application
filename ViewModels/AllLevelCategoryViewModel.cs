using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class AllLevelCategoryViewModel
    {
        public IEnumerable<Level1Category> Level1Category { get; set; }
        public IEnumerable<Level2Category> Level2Category { get; set; }
        public IEnumerable<Level3Category> Level3Category { get; set; }
    }
}
