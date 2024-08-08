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
        IResult Add(OrderDetail connection);
        IResult Delete(int id);
        IResult Update(OrderDetail connection);
        IDataResult<List<OrderDetail>> GetAllConnections();
        IDataResult<OrderDetail> GetConnection(int id);
    }
}
