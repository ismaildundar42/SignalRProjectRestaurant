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
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(SignalRContext context) : base(context)
        {
        }

        public void changeStatusToFalse(int id)
        {
            using var context = new SignalRContext();
            var value = context.tbl_discount.Find(id);
            value.Status = false;
            context.SaveChanges();
        }

        public void changeStatusToTrue(int id)
        {
            using var context = new SignalRContext();
            var value = context.tbl_discount.Find(id);
            value.Status = true;
            context.SaveChanges();
        }

        public List<Discount> GetListByStatusTrue()
        {
            using var context = new SignalRContext();
            var value = context.tbl_discount.Where(x => x.Status == true);
            return value.ToList();
        }
    }
}
