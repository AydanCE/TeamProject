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
    public class OrderToProductManager(IOrderToProductDal connectionDal) : IOrderToProductService
    {
        private readonly IOrderToProductDal _connectionDal = connectionDal;

        public IResult Add(OrderDetail connection)
        {
            if (connection != null)
            {
                _connectionDal.Add(connection);

                return new SuccessResult("Connection added successfully");
            }
            else
                return new ErrorResult("Connection is null");
        }

        public IResult Delete(int id)
        {
            OrderDetail deletedConnection = _connectionDal.GetAll(c => c.IsDeleted == false).SingleOrDefault(c => c.Id == id);

            if (deletedConnection != null)
            {
                deletedConnection.IsDeleted = true;
                _connectionDal.Delete(deletedConnection);
                return new SuccessResult("Connection deleted successfully");
            }
            return new ErrorResult("Connection was not found");
        }

        public IDataResult<List<OrderDetail>> GetAllConnections()
        {
            var connections = _connectionDal.GetAll(c => c.IsDeleted == false);

            if (connections.Count != 0)
                return new SuccessDataResult<List<OrderDetail>>(connections, "Connections loaded");
            else
                return new ErrorDataResult<List<OrderDetail>>(connections, "List of connections is empty");
        }

        public IDataResult<OrderDetail> GetConnection(int id)
        {
            OrderDetail getConnection = _connectionDal.Get(c => c.Id == id);

            if (getConnection != null)
                return new SuccessDataResult<OrderDetail>(getConnection, "Connection loaded");
            else
                return new ErrorDataResult<OrderDetail>(getConnection, "Connection was not found");
        }

        public IResult Update(OrderDetail connection)
        {
            OrderDetail updateOrderToProduct = _connectionDal.Get(c => c.Id == connection.Id);

            if (updateOrderToProduct != null)
            {
                updateOrderToProduct = connection;

                _connectionDal.Update(updateOrderToProduct);

                return new SuccessResult("OrderToProduct updated successfully");
            }
            else
                return new ErrorResult("OrderToProduct was not found");
        }
    }
}
