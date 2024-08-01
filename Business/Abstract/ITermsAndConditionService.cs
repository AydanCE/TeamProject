using Core.Helper.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITermsAndConditionService
    {
        IResult Add(TermsAndCondition page);
        IResult Delete(int id);
        IResult Update(TermsAndCondition page);
        IDataResult<List<TermsAndCondition>> GetAllPages();
        IDataResult<TermsAndCondition> GetPage(int id);
    }
}
