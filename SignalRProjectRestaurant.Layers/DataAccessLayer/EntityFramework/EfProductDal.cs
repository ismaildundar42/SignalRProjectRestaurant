using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductWithCategory()
        {
            var context = new SignalRContext();
            var result = context.tbl_product.Include(x => x.Category).ToList();
            return result;
        }

        public int ProductCount()
        {
            using var context = new SignalRContext();
            return context.tbl_product.Count();
        }

        public int ProductCountByCategoryNameFirin()
        {
            using var context = new SignalRContext();
            return context.tbl_product.Where(x => x.CategoryId == (context.tbl_category.Where(y => y.CategoryName == "Fırın Ürünleri").Select(z => z.CategoryId).FirstOrDefault())).Count();
        }

        public int ProductCountByCategoryNameIcecek()
        {
            using var context = new SignalRContext();
            return context.tbl_product.Where(x => x.CategoryId == (context.tbl_category.Where(y => y.CategoryName == "İçecekler").Select(z => z.CategoryId).FirstOrDefault())).Count();
        }

        public string ProductNameByMaxPrice()
        {
            using var context = new SignalRContext();
            return context.tbl_product.Where(x => x.Price == (context.tbl_product.Max(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();

        }

        public string ProductNameByMinPrice()
        {
            using var context = new SignalRContext();
            return context.tbl_product.Where(x => x.Price == (context.tbl_product.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
        }

        public decimal ProductPriceAvg()
        {
            using var context = new SignalRContext();
            return context.tbl_product.Average(x => x.Price);
        }

        public decimal ProductPriceAvgFirin()
        {
            using var context = new SignalRContext();
            return context.tbl_product.Where(x => x.CategoryId == (context.tbl_category.Where(y => y.CategoryName == "Fırın Ürünleri").Select(z => z.CategoryId).FirstOrDefault())).Average(w=>w.Price);
        }
    }
}
