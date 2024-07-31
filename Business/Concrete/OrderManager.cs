using Business.Abstract;
using Core.Helper.Result.Abstract;
using Core.Helper.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager(IOrderDal orderDal) : IOrderService
    {
        private readonly IOrderDal _orderDal = orderDal;

        public IResult Add(Order order)
        {
            if (order != null)
            {
                _orderDal.Add(order);

                return new SuccessResult("Order added successfully");
            }
            else
                return new ErrorResult("Order is null");
        }

        public IResult Delete(int id)
        {
            Order deletedOrder = _orderDal.GetAll(o => o.IsDeleted == false).SingleOrDefault(o => o.Id == id);

            if (deletedOrder != null)
            {
                deletedOrder.IsDeleted = true;
                _orderDal.Delete(deletedOrder);
                return new SuccessResult("Order deleted successfully");
            }
            return new ErrorResult("Order was not found");
        }

        public IDataResult<List<Order>> GetAllOrders()
        {
            var orders = _orderDal.GetAll(o => o.IsDeleted == false);

            if (orders.Count != 0)
                return new SuccessDataResult<List<Order>>(orders, "Orders loaded");
            else
                return new ErrorDataResult<List<Order>>(orders, "List of orders is empty");
        }

        public IDataResult<Order> GetOrder(int id)
        {
            Order getOrder = _orderDal.Get(o => o.Id == id);

            if (getOrder != null)
                return new SuccessDataResult<Order>(getOrder, "Order loaded");
            else
                return new ErrorDataResult<Order>(getOrder, "Order was not found");
        }

        public IResult Update(Order order)
        {
            Order updateOrder = _orderDal.Get(o => o.Id == order.Id);

            if (updateOrder != null)
            {
                updateOrder = order;

                _orderDal.Update(updateOrder);

                return new SuccessResult("Order updated successfully");
            }
            else
                return new ErrorResult("Order was not found");
        }
    }
}
