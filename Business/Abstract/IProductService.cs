using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Helper.Result.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult Add(Product product);
        IResult Delete(int id);
        IResult Update(Product product);
        IDataResult<List<Product>> GetAllProducts();
        IDataResult<Product> GetProduct(int id);
    }
}
