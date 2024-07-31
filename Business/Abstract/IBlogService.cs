using Core.Helper.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService
    {
        IResult Add(Blog blog);
        IResult Delete(int id);
        IResult Update(int id, Blog blog);
        IDataResult<List<Blog>> GetAllBlogs();
        IDataResult<Blog> GetBlog(int id);
    }
}
