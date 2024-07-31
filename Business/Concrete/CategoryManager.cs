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
    public class CategoryManager(ICategoryDal categoryDal) : ICategoryService
    {
        private readonly ICategoryDal _categoryDal = categoryDal;

        public IResult Add(Category Category)
        {
            if (Category != null)
            {
                _categoryDal.Add(Category);

                return new SuccessResult("Category added successfully");
            }
            else
                return new ErrorResult("Category is null");
        }

        public IResult Delete(int id)
        {
            Category deletedCategory = _categoryDal.GetAll(c => c.IsDeleted == false).SingleOrDefault(c => c.Id == id);

            if (deletedCategory != null)
            {
                deletedCategory.IsDeleted = true;
                _categoryDal.Delete(deletedCategory);
                return new SuccessResult("Category deleted successfully");
            }
            return new ErrorResult("Category was not found");
        }

        public IDataResult<List<Category>> GetAllCategories()
        {
            var categories = _categoryDal.GetAll(c => c.IsDeleted == false);

            if (categories.Count != 0)
                return new SuccessDataResult<List<Category>>(categories, "Categories loaded");
            else
                return new ErrorDataResult<List<Category>>(categories, "List of categories is empty");
        }

        public IDataResult<Category> GetCategory(int id)
        {
            Category getCategory = _categoryDal.Get(c => c.Id == id);

            if (getCategory != null)
                return new SuccessDataResult<Category>(getCategory, "Category loaded");
            else
                return new ErrorDataResult<Category>(getCategory, "Category was not found");
        }

        public IResult Update(int id, Category category)
        {
            Category updateCategory = _categoryDal.Get(c => c.Id == id);

            if (updateCategory != null)
            {
                updateCategory = category;

                _categoryDal.Update(updateCategory);

                return new SuccessResult("Category updated successfully");
            }
            else
                return new ErrorResult("Category was not found");
        }
    }
}
