using Core.Helper.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFaqService
    {
        IResult Add(Faq page);
        IResult Delete(int id);
        IResult Update(Faq page);
        IDataResult<List<Faq>> GetAllPages();
        IDataResult<Faq> GetPage(int id);
    }
}
