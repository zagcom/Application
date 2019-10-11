using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface IBudgetCategoryRepository
    {
        BudgetCategory GetBudgetCategory(int Id);
        IEnumerable<BudgetCategory> GetAllBudgetCategory();
        BudgetCategory Add(BudgetCategory budgetCategory);
        BudgetCategory Update(BudgetCategory budgetCategoryChanges);
        BudgetCategory Delete(int id);
    }
}
