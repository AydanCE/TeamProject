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
        IResult Add(ProductDetail connection);
        IResult Delete(int id);
        IResult Update(ProductDetail connection);
        IDataResult<List<ProductDetail>> GetAllConnections();
        IDataResult<ProductDetail> GetConnection(int id);
    }
}
