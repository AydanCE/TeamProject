using Core.Helper.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(int id);
        IResult Update(int id, User user);
        IDataResult<List<User>> GetAllUsers();
        IDataResult<User> GetUser(int id);
    }
}
