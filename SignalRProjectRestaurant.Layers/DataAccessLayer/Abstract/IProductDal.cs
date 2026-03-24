using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductWithCategory();
        public int ProductCount();
        public int ProductCountByCategoryNameFirin();
        public int ProductCountByCategoryNameIcecek();
        public decimal ProductPriceAvg();
        public string ProductNameByMaxPrice();
        public string ProductNameByMinPrice();
        public decimal ProductPriceAvgFirin();
        public decimal TotalPriceByIcecekCategory();
        List<Product> GetFirst9Product();
    }
}
