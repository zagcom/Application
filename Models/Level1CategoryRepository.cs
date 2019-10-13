using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Level1CategoryRepository : ILevel1CategoryRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<Level1CategoryRepository> logger;

        public Level1CategoryRepository(AppDbContext context, ILogger<Level1CategoryRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public Level1Category Add(Level1Category level1category)
        {
            context.Level1Categories.Add(level1category);
            context.SaveChanges();
            return level1category;
        }

        public Level1Category Delete(int id)
        {
            Level1Category level1category = context.Level1Categories.Find(id);
            if (level1category != null)
            {
                context.Level1Categories.Remove(level1category);
                context.SaveChanges();
            }
            return level1category;
        }

        public IEnumerable<Level1Category> GetAllCategory()
        {
            return context.Level1Categories;
        }

        public Level1Category GetCategory(int Id)
        {
            
            return context.Level1Categories.Find(Id);
        }

        public Level1Category Update(Level1Category level1categoryChanges)
        {
            var level1category = context.Level1Categories.Attach(level1categoryChanges);
            level1category.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return level1categoryChanges;
        }
    }
}
