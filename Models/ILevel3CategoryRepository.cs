using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface ILevel3CategoryRepository
    {
        Level3Category GetCategory(int Id);
        IEnumerable<Level3Category> GetAllCategory();
        Level3Category Add(Level3Category level3category);
        Level3Category Update(Level3Category level3categoryChanges);
        Level3Category Delete(int id);
    }
}
