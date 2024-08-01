﻿using Business.Abstract;
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
    public class TermsAndConditionManager(ITermsAndConditionDal pageDal) : ITermsAndConditionService
    {
        private readonly ITermsAndConditionDal _pageDal = pageDal;

        public IResult Add(TermsAndCondition page)
        {
            if (page != null)
            {
                _pageDal.Add(page);

                return new SuccessResult("Page added successfully");
            }
            else
                return new ErrorResult("Page is null");
        }

        public IResult Delete(int id)
        {
            TermsAndCondition deletedPage = _pageDal.GetAll(p => p.IsDeleted == false).SingleOrDefault(p => p.Id == id);

            if (deletedPage != null)
            {
                deletedPage.IsDeleted = true;
                _pageDal.Delete(deletedPage);
                return new SuccessResult("Page deleted successfully");
            }
            return new ErrorResult("Page was not found");
        }

        public IDataResult<List<TermsAndCondition>> GetAllPages()
        {
            var pages = _pageDal.GetAll(p => p.IsDeleted == false);

            if (pages.Count != 0)
                return new SuccessDataResult<List<TermsAndCondition>>(pages, "Pages loaded");
            else
                return new ErrorDataResult<List<TermsAndCondition>>(pages, "List of pages is empty");
        }

        public IDataResult<TermsAndCondition> GetPage(int id)
        {
            TermsAndCondition getPage = _pageDal.Get(p => p.Id == id);

            if (getPage != null)
                return new SuccessDataResult<TermsAndCondition>(getPage, "Page loaded");
            else
                return new ErrorDataResult<TermsAndCondition>(getPage, "Page was not found");
        }

        public IResult Update(TermsAndCondition page)
        {
            TermsAndCondition updatePage = _pageDal.Get(p => p.Id == page.Id);

            if (updatePage != null)
            {
                updatePage = page;

                _pageDal.Update(updatePage);

                return new SuccessResult("Page updated successfully");
            }
            else
                return new ErrorResult("Page was not found");
        }
    }
}


