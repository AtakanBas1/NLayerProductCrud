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
    public class ProductManager : IProductService
    {
        IProductDAL _productDAL;

        public ProductManager(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public void TAdd(Product t)
        {
            _productDAL.Insert(t);
        }

        public void TDelete(Product t)
        {
            _productDAL.Delete(t);
        }

        public Product TGetById(int id)
        {
            return _productDAL.GetById(id);
        }

        public List<Product> TGetListAll()
        {
            return _productDAL.GetListAll();
        }

        public void TUpdate(Product t)
        {
            _productDAL.Update(t);
        }
    }
}