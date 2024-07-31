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
    public class BlogManager(IBlogDal blogDal) : IBlogService
    {
        private readonly IBlogDal _blogDal = blogDal;

        public IResult Add(Blog blog)
        {
            if (blog != null)
            {
                _blogDal.Add(blog);

                return new SuccessResult("Blog added successfully");
            }
            else
                return new ErrorResult("Blog is null");
        }

        public IResult Delete(int id)
        {
            Blog deletedBlog = _blogDal.GetAll(b => b.IsDeleted == false).SingleOrDefault(p => p.Id == id);

            if (deletedBlog != null)
            {
                deletedBlog.IsDeleted = true;
                _blogDal.Delete(deletedBlog);
                return new SuccessResult("Blog deleted successfully");
            }
            return new ErrorResult("Blog was not found");
        }

        public IDataResult<List<Blog>> GetAllBlogs()
        {
            var blogs = _blogDal.GetAll(b => b.IsDeleted == false);

            if (blogs.Count != 0)
                return new SuccessDataResult<List<Blog>>(blogs, "Blogs loaded");
            else
                return new ErrorDataResult<List<Blog>>(blogs, "List of blogs is empty");
        }

        public IDataResult<Blog> GetBlog(int id)
        {
            Blog getBlog = _blogDal.Get(b => b.Id == id);

            if (getBlog != null)
                return new SuccessDataResult<Blog>(getBlog, "Blog loaded");
            else
                return new ErrorDataResult<Blog>(getBlog, "Blog was not found");
        }

        public IResult Update(Blog blog)
        {
            Blog updateBlog = _blogDal.Get(b => b.Id == blog.Id);

            if (updateBlog != null)
            {
                updateBlog = blog;

                _blogDal.Update(updateBlog);

                return new SuccessResult("Blog updated successfully");
            }
            else
                return new ErrorResult("Blog was not found");
        }
    }
}
