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
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new SignalRContext();
            return context.tbl_order.Where(x=>x.Description=="Aktif").Count();
        }

        public decimal LastOrderPrice()
        {
            using var context = new SignalRContext();
            return context.tbl_order.OrderByDescending(x=>x.OrderId).Take(1).Select(y=>y.TotalPrice).FirstOrDefault();
        }

        public decimal TodayTotalPrice()
        {
            using var context = new SignalRContext();

            // DateTime.Now'dan sadece tarih kısmını (saatsiz) almak için en doğru yöntem:
            return context.tbl_order
                          .Where(x => x.Date == DateOnly.FromDateTime(DateTime.Now))
                          .Sum(y => y.TotalPrice);
        }

        public int TotalOrderCount()
        {
            using var context = new SignalRContext();
            return context.tbl_order.Count();
        }
    }
}
