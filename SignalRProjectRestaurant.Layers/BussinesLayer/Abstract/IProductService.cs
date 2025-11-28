using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        public List<Product> TGetProductWithCategory();
        public int TProductCount();
        public int TProductCountByCategoryNameFirin();
        public int TProductCountByCategoryNameIcecek();
        public decimal TProductPriceAvg();
        public string TProductNameByMaxPrice();
        public string TProductNameByMinPrice();
        public decimal TProductPriceAvgFirin();

    }
}
