using BussinesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product TGetbyId(int id)
        {
            return _productDal.GetbyId(id);
        }

        public List<Product> TGetListAll()
        {
            return _productDal.GetListAll();
        }

        public List<Product> TGetProductWithCategory()
        {
            return _productDal.GetProductWithCategory();
        }

        public int TProductCount()
        {
            return _productDal.ProductCount();
        }

        public int TProductCountByCategoryNameFirin()
        {
            return _productDal.ProductCountByCategoryNameFirin();
        }

        public int TProductCountByCategoryNameIcecek()
        {
            return _productDal.ProductCountByCategoryNameIcecek();
        }

        public string TProductNameByMaxPrice()
        {
            return _productDal.ProductNameByMaxPrice();
        }

        public string TProductNameByMinPrice()
        {
            return _productDal.ProductNameByMinPrice();
        }

        public decimal TProductPriceAvg()
        {
            return _productDal.ProductPriceAvg();
        }

        public decimal TProductPriceAvgFirin()
        {
            return _productDal.ProductPriceAvgFirin();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
