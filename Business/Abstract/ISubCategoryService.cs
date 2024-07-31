using Core.Helper.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISubCategoryService
    {
        IResult Add(SubCategory subCategory);
        IResult Delete(int id);
        IResult Update(int id, SubCategory subCategory);
        IDataResult<List<SubCategory>> GetAllSubCategories();
        IDataResult<SubCategory> GetSubCategory(int id);
    }
}
