using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class BudgetCategory
    {
        public int Id { get; set; }
        public Category CategoryLevel1 { get; set; }
        public Category CategoryLevel2 { get; set; }
        public Category CategoryLevel3 { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }
    }
}
