using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface ILevel1CategoryRepository
    {
        Level1Category GetCategory(int Id);
        IEnumerable<Level1Category> GetAllCategory();
        Level1Category Add(Level1Category level1category);
        Level1Category Update(Level1Category level1categoryChanges);
        Level1Category Delete(int id);
    }
}
