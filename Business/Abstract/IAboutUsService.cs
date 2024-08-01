using Core.Helper.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutUsService
    {
        IResult Add(AboutUs page);
        IResult Delete(int id);
        IResult Update(AboutUs page);
        IDataResult<List<AboutUs>> GetAllPages();
        IDataResult<AboutUs> GetPage(int id);
    }
}
