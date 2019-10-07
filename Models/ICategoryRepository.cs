using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface ICategoryRepository
    {
        Category GetCategory(int Id);
        IEnumerable<Category> GetAllCategory();
        Category Add(Category category);
        Category Update(Category categoryChanges);
        Category Delete(int id);
    }
}
