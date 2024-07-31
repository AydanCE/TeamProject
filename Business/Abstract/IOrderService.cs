using Core.Helper.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IResult Add(Order order);
        IResult Delete(int id);
        IResult Update(Order order);
        IDataResult<List<Order>> GetAllOrders();
        IDataResult<Order> GetOrder(int id);
    }
}
