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
    public class ProductToSubCategoryManager(IProductToSubCategoryDal connectionDal) : IProductToSubCategoryService
    {
        private readonly IProductToSubCategoryDal _connectionDal = connectionDal;

        public IResult Add(ProductDetail connection)
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
            ProductDetail deletedConnection = _connectionDal.GetAll(c => c.IsDeleted == false).SingleOrDefault(c => c.Id == id);

            if (deletedConnection != null)
            {
                deletedConnection.IsDeleted = true;
                _connectionDal.Delete(deletedConnection);
                return new SuccessResult("Connection deleted successfully");
            }
            return new ErrorResult("Connection was not found");
        }

        public IDataResult<List<ProductDetail>> GetAllConnections()
        {
            var connections = _connectionDal.GetAll(c => c.IsDeleted == false);

            if (connections.Count != 0)
                return new SuccessDataResult<List<ProductDetail>>(connections, "Connections loaded");
            else
                return new ErrorDataResult<List<ProductDetail>>(connections, "List of connections is empty");
        }

        public IDataResult<ProductDetail> GetConnection(int id)
        {
            ProductDetail getConnection = _connectionDal.Get(p => p.Id == id);

            if (getConnection != null)
                return new SuccessDataResult<ProductDetail>(getConnection, "Connection loaded");
            else
                return new ErrorDataResult<ProductDetail>(getConnection, "Connection was not found");
        }

        public IResult Update(ProductDetail connection)
        {
            ProductDetail updateConnection = _connectionDal.Get(c => c.Id == connection.Id);

            if (updateConnection != null)
            {
                updateConnection = connection;

                _connectionDal.Update(updateConnection);

                return new SuccessResult("Connection updated successfully");
            }
            else
                return new ErrorResult("Connection was not found");
        }
    }
}
