using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<CategoryRepository> logger;

        public CategoryRepository(AppDbContext context, ILogger<CategoryRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public Category Add(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return category;
        }

        public Category Delete(int id)
        {
            Category category = context.Categories.Find(id);
            if (category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
            return category;
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return context.Categories;
        }

        public Category GetCategory(int Id)
        {
            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical Log");

            return context.Categories.Find(Id);
        }

        public Category Update(Category categoryChanges)
        {
            var category = context.Categories.Attach(categoryChanges);
            category.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return categoryChanges;
        }
    }
}
