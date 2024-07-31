using Core.Helper.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(Category category);
        IResult Delete(int id);
        IResult Update(int id, Category category);
        IDataResult<List<Category>> GetAllCategories();
        IDataResult<Category> GetCategory(int id);
    }
}
