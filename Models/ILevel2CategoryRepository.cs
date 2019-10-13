using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface ILevel2CategoryRepository
    {
        Level2Category GetCategory(int Id);
        IEnumerable<Level2Category> GetAllCategory();
        Level2Category Add(Level2Category level2category);
        Level2Category Update(Level2Category level2categoryChanges);
        Level2Category Delete(int id);
    }
}
