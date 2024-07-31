using Core.Helper.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRegionService
    {
        IResult Add(Region region);
        IResult Delete(int id);
        IResult Update(int id, Region region);
        IDataResult<List<Region>> GetAllRegions();
        IDataResult<Region> GetRegion(int id);
    }
}
