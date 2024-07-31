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

        public IResult Add(ProductToSubCategory connection)
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
            ProductToSubCategory deletedConnection = _connectionDal.GetAll(c => c.IsDeleted == false).SingleOrDefault(c => c.Id == id);

            if (deletedConnection != null)
            {
                deletedConnection.IsDeleted = true;
                _connectionDal.Delete(deletedConnection);
                return new SuccessResult("Connection deleted successfully");
            }
            return new ErrorResult("Connection was not found");
        }

        public IDataResult<List<ProductToSubCategory>> GetAllConnections()
        {
            var connections = _connectionDal.GetAll(c => c.IsDeleted == false);

            if (connections.Count != 0)
                return new SuccessDataResult<List<ProductToSubCategory>>(connections, "Connections loaded");
            else
                return new ErrorDataResult<List<ProductToSubCategory>>(connections, "List of connections is empty");
        }

        public IDataResult<ProductToSubCategory> GetConnection(int id)
        {
            ProductToSubCategory getConnection = _connectionDal.Get(p => p.Id == id);

            if (getConnection != null)
                return new SuccessDataResult<ProductToSubCategory>(getConnection, "Connection loaded");
            else
                return new ErrorDataResult<ProductToSubCategory>(getConnection, "Connection was not found");
        }

        public IResult Update(int id, ProductToSubCategory connection)
        {
            ProductToSubCategory updateConnection = _connectionDal.Get(c => c.Id == id);

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
