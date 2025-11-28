using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        public int TTotalOrderCount();
        public int TActiveOrderCount();
        public decimal TLastOrderPrice();
        public decimal TTodayTotalPrice();

    }
}
