using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BaseUserManager : IBaseUserService
    {
        IBaseUserDAL _baseUserDAL;

        public BaseUserManager(IBaseUserDAL baseUserDAL)
        {
            _baseUserDAL = baseUserDAL;
        }

        public void TAdd(BaseUser t)
        {
            _baseUserDAL.Insert(t);
        }

        public void TDelete(BaseUser t)
        {
            throw new NotImplementedException();
        }

        public BaseUser TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<BaseUser> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(BaseUser t)
        {
            throw new NotImplementedException();
        }
    }
}
