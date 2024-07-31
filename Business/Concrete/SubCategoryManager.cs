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
    public class SubCategoryManager(ISubCategoryDal subCategoryDal) : ISubCategoryService
    {
        private readonly ISubCategoryDal _subCategoryDal = subCategoryDal;

        public IResult Add(SubCategory subCategory)
        {
            if (subCategory != null)
            {
                _subCategoryDal.Add(subCategory);

                return new SuccessResult("SubCategory added successfully");
            }
            else
                return new ErrorResult("SubCategory is null");
        }

        public IResult Delete(int id)
        {
            SubCategory deletedSubCategory = _subCategoryDal.GetAll(s => s.IsDeleted == false).SingleOrDefault(p => p.Id == id);

            if (deletedSubCategory != null)
            {
                deletedSubCategory.IsDeleted = true;
                _subCategoryDal.Delete(deletedSubCategory);
                return new SuccessResult("SubCategory deleted successfully");
            }
            return new ErrorResult("SubCategory was not found");
        }

        public IDataResult<List<SubCategory>> GetAllSubCategories()
        {
            var subCategories = _subCategoryDal.GetAll(s => s.IsDeleted == false);

            if (subCategories.Count != 0)
                return new SuccessDataResult<List<SubCategory>>(subCategories, "SubCategories loaded");
            else
                return new ErrorDataResult<List<SubCategory>>(subCategories, "List of subCategories is empty");
        }

        public IDataResult<SubCategory> GetSubCategory(int id)
        {
            SubCategory getSubCategory = _subCategoryDal.Get(s => s.Id == id);

            if (getSubCategory != null)
                return new SuccessDataResult<SubCategory>(getSubCategory, "SubCategory loaded");
            else
                return new ErrorDataResult<SubCategory>(getSubCategory, "SubCategory was not found");
        }

        public IResult Update(SubCategory subCategory)
        {
            SubCategory updateSubCategory = _subCategoryDal.Get(s => s.Id == subCategory.Id);

            if (updateSubCategory != null)
            {
                updateSubCategory = subCategory;

                _subCategoryDal.Update(updateSubCategory);

                return new SuccessResult("SubCategory updated successfully");
            }
            else
                return new ErrorResult("SubCategory was not found");
        }
    }
}
