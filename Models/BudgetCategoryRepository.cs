using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class BudgetCategoryRepository : IBudgetCategoryRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<BudgetCategoryRepository> logger;

        public BudgetCategoryRepository(AppDbContext context, ILogger<BudgetCategoryRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public BudgetCategory Add(BudgetCategory budgetCategory)
        {
            context.BudgetCategories.Add(budgetCategory);
            context.SaveChanges();
            return budgetCategory;
        }

        public BudgetCategory Delete(int id)
        {
            BudgetCategory budgetCategory = context.BudgetCategories.Find(id);
            if (budgetCategory != null)
            {
                context.BudgetCategories.Remove(budgetCategory);
                context.SaveChanges();
            }
            return budgetCategory;
        }

        public IEnumerable<BudgetCategory> GetAllBudgetCategory()
        {
            return context.BudgetCategories;
        }

        public BudgetCategory GetBudgetCategory(int Id)
        {
            return context.BudgetCategories.Find(Id);
        }

        public BudgetCategory Update(BudgetCategory budgetCategoryChanges)
        {
            var category = context.BudgetCategories.Attach(budgetCategoryChanges);
            category.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return budgetCategoryChanges;
        }
    }
}
