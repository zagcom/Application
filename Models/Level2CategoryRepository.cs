using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Level2CategoryRepository : ILevel2CategoryRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<Level2CategoryRepository> logger;

        public Level2CategoryRepository(AppDbContext context, ILogger<Level2CategoryRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public Level2Category Add(Level2Category level2category)
        {
            context.Level2Categories.Add(level2category);
            context.SaveChanges();
            return level2category;
        }

        public Level2Category Delete(int id)
        {
            Level2Category level2category = context.Level2Categories.Find(id);
            if (level2category != null)
            {
                context.Level2Categories.Remove(level2category);
                context.SaveChanges();
            }
            return level2category;
        }

        public IEnumerable<Level2Category> GetAllCategory()
        {
            return context.Level2Categories;
        }

        public Level2Category GetCategory(int Id)
        {
            
            return context.Level2Categories.Find(Id);
        }

        public Level2Category Update(Level2Category level2categoryChanges)
        {
            var level2category = context.Level2Categories.Attach(level2categoryChanges);
            level2category.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return level2categoryChanges;
        }
    }
}
