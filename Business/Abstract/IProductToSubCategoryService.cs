using Core.Helper.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductToSubCategoryService
    {
        IResult Add(ProductToSubCategory connection);
        IResult Delete(int id);
        IResult Update(int id, ProductToSubCategory connection);
        IDataResult<List<ProductToSubCategory>> GetAllConnections();
        IDataResult<ProductToSubCategory> GetConnection(int id);
    }
}
