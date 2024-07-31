using Core.Helper.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderToProductService
    {
        IResult Add(OrderToProduct connection);
        IResult Delete(int id);
        IResult Update(int id, OrderToProduct connection);
        IDataResult<List<OrderToProduct>> GetAllConnections();
        IDataResult<OrderToProduct> GetConnection(int id);
    }
}
