using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class BudgetCategory
    {
        public int Id { get; set; }
        public Level1Category Level1Category { get; set; }
        public int Level1CategoryId { get; set; }
        public Level2Category Level2Category { get; set; }
        public int Level2CategoryId { get; set; }
        public Level3Category Level3Category { get; set; }
        public int Level3CategoryId { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }
    }
}
