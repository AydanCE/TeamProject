using Core.Helper.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPrivacyPolicyService
    {
        IResult Add(PrivacyPolicy page);
        IResult Delete(int id);
        IResult Update(PrivacyPolicy page);
        IDataResult<List<PrivacyPolicy>> GetAllPages();
        IDataResult<PrivacyPolicy> GetPage(int id);
    }
}
