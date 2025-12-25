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
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        public EfNotificationDal(SignalRContext context) : base(context)
        {
        }

        public List<Notification> GetAllNotificationByFalse()
        {
            using var context = new SignalRContext();
            return context.tbl_notification.Where(x=>x.Status == false).ToList();
        }

        public int NotificationCountByStatusFalse()
        {
            var context = new SignalRContext();
            return context.tbl_notification.Where(x=>x.Status==false).Count();
        }

        public void NotificationStatusChangesFalse(int id)
        {
            using var context = new SignalRContext();
            var value = context.tbl_notification.Find(id);
            value.Status = false;
            context.SaveChanges();
        }

        public void NotificationStatusChangesTrue(int id)
        {
            using var context = new SignalRContext();
            var value = context.tbl_notification.Find(id);
            value.Status = true;
            context.SaveChanges();
        }
    }
}
