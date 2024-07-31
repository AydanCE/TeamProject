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
    public class ProductManager(IProductDal productDal) : IProductService
    {
        private readonly IProductDal _productDal = productDal;

        public IResult Add(Product product)
        {
            if (product != null)
            {
                _productDal.Add(product);

                return new SuccessResult("Product added successfully");
            }
            else
                return new ErrorResult("Product is null");
        }

        public IResult Delete(int id)
        {
            Product deletedProduct = _productDal.GetAll(p => p.IsDeleted == false).SingleOrDefault(p => p.Id == id);

            if (deletedProduct != null) 
            { 
                deletedProduct.IsDeleted = true;
                _productDal.Delete(deletedProduct);
                return new SuccessResult("Product deleted successfully");
            }
            return new ErrorResult("Product was not found");
        }

        public IDataResult<List<Product>> GetAllProducts()
        {
            var products = _productDal.GetAll(p => p.IsDeleted == false);

            if (products.Count != 0)
                return new SuccessDataResult<List<Product>>(products, "Products loaded");
            else
                return new ErrorDataResult<List<Product>>(products, "List of products is empty");
        }

        public IDataResult<Product> GetProduct(int id)
        {
            Product getProduct = _productDal.Get(p => p.Id == id);

            if (getProduct != null)
                return new SuccessDataResult<Product>(getProduct, "Product loaded");
            else
                return new ErrorDataResult<Product>(getProduct, "Product was not found");
        }

        public IResult Update(Product product)
        {
            Product updateProduct = _productDal.Get(p => p.Id == product.Id);

            if (updateProduct != null)
            {
                updateProduct = product;

                _productDal.Update(updateProduct);

                return new SuccessResult("Product updated successfully");
            }
            else
                return new ErrorResult("Product was not found");
        }
    }
}
