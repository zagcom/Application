using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Level3CategoryRepository : ILevel3CategoryRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<Level3CategoryRepository> logger;

        public Level3CategoryRepository(AppDbContext context, ILogger<Level3CategoryRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public Level3Category Add(Level3Category level3category)
        {
            context.Level3Categories.Add(level3category);
            context.SaveChanges();
            return level3category;
        }

        public Level3Category Delete(int id)
        {
            Level3Category level3category = context.Level3Categories.Find(id);
            if (level3category != null)
            {
                context.Level3Categories.Remove(level3category);
                context.SaveChanges();
            }
            return level3category;
        }

        public IEnumerable<Level3Category> GetAllCategory()
        {
            return context.Level3Categories;
        }

        public Level3Category GetCategory(int Id)
        {
            
            return context.Level3Categories.Find(Id);
        }

        public Level3Category Update(Level3Category level3categoryChanges)
        {
            var level3category = context.Level3Categories.Attach(level3categoryChanges);
            level3category.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return level3categoryChanges;
        }
    }
}
