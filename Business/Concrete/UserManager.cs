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
    public class UserManager(IUserDal userDal) : IUserService
    {
        private readonly IUserDal _userDal = userDal;

        public IResult Add(User user)
        {
            if (user != null)
            {
                _userDal.Add(user);

                return new SuccessResult("User added successfully");
            }
            else
                return new ErrorResult("User is null");
        }

        public IResult Delete(int id)
        {
            User deletedUser = _userDal.GetAll(u => u.IsDeleted == false).SingleOrDefault(u => u.Id == id);

            if (deletedUser != null)
            {
                deletedUser.IsDeleted = true;
                _userDal.Delete(deletedUser);
                return new SuccessResult("User deleted successfully");
            }
            return new ErrorResult("User was not found");
        }

        public IDataResult<List<User>> GetAllUsers()
        {
            var users = _userDal.GetAll(u => u.IsDeleted == false);

            if (users.Count != 0)
                return new SuccessDataResult<List<User>>(users, "Users loaded");
            else
                return new ErrorDataResult<List<User>>(users, "List of users is empty");
        }

        public IDataResult<User> GetUser(int id)
        {
            User getUser = _userDal.Get(u => u.Id == id);

            if (getUser != null)
                return new SuccessDataResult<User>(getUser, "User loaded");
            else
                return new ErrorDataResult<User>(getUser, "User was not found");
        }

        public IResult Update(int id, User user)
        {
            User updateUser = _userDal.Get(u => u.Id == id);

            if (updateUser != null)
            {
                updateUser = user;

                _userDal.Update(updateUser);

                return new SuccessResult("User updated successfully");
            }
            else
                return new ErrorResult("User was not found");
        }
    }
}
