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
    public class RegionManager(IRegionDal regionDal) : IRegionService
    {
        private readonly IRegionDal _regionDal = regionDal;

        public IResult Add(Region region)
        {
            if (region != null)
            {
                _regionDal.Add(region);

                return new SuccessResult("Region added successfully");
            }
            else
                return new ErrorResult("Region is null");
        }

        public IResult Delete(int id)
        {
            Region deletedRegion = _regionDal.GetAll(r => r.IsDeleted == false).SingleOrDefault(r => r.Id == id);

            if (deletedRegion != null)
            {
                deletedRegion.IsDeleted = true;
                _regionDal.Delete(deletedRegion);
                return new SuccessResult("Region deleted successfully");
            }
            return new ErrorResult("Region was not found");
        }

        public IDataResult<List<Region>> GetAllRegions()
        {
            var regions = _regionDal.GetAll(r => r.IsDeleted == false);

            if (regions.Count != 0)
                return new SuccessDataResult<List<Region>>(regions, "Regions loaded");
            else
                return new ErrorDataResult<List<Region>>(regions, "List of regions is empty");
        }

        public IDataResult<Region> GetRegion(int id)
        {
            Region getRegion = _regionDal.Get(r => r.Id == id);

            if (getRegion != null)
                return new SuccessDataResult<Region>(getRegion, "Region loaded");
            else
                return new ErrorDataResult<Region>(getRegion, "Region was not found");
        }

        public IResult Update(int id, Region region)
        {
            Region updateRegion = _regionDal.Get(r => r.Id == id);

            if (updateRegion != null)
            {
                updateRegion = region;

                _regionDal.Update(updateRegion);

                return new SuccessResult("Region updated successfully");
            }
            else
                return new ErrorResult("Region was not found");
        }
    }
}
