using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveCategoryCount()
        {
            using var context = new SignalRContext();
            return context.tbl_category.Where(x=>x.CategoryStatus==true).Count();
        }

        public int CategoryCount()
        {
            using var context = new SignalRContext();
            return context.tbl_category.Count();
        }

        public int PassiveCategoryCount()
        {
            using var context = new SignalRContext();
            return context.tbl_category.Where(x => x.CategoryStatus == false).Count();
        }
    }
}
