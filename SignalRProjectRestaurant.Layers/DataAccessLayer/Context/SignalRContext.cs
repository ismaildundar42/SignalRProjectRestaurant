using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class SignalRContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-496IBCH\\SQLEXPRESS;initial catalog=DbSignalR;integrated security=true;trustservercertificate=true");
        }
        public DbSet<About> tbl_about { get; set; }
        public DbSet<Booking> tbl_booking { get; set; }
        public DbSet<Category> tbl_category { get; set; }
        public DbSet<Contact> tbl_contact { get; set; }
        public DbSet<Discount> tbl_discount { get; set; }
        public DbSet<Feature> tbl_feature { get; set; }
        public DbSet<Product> tbl_product { get; set; }
        public DbSet<SocialMedia> tbl_socialMedia { get; set; }
        public DbSet<Testimonial> tbl_testimonial { get; set; }
        public DbSet<Order> tbl_order { get; set; }
        public DbSet<OrderDetail> tbl_orderDetail { get; set; }
        public DbSet<MoneyCase> tbl_moneyCase { get; set; }
        public DbSet<MenuTable> tbl_menuTable { get; set; }
        public DbSet<Slider> tbl_slider { get; set; }
        public DbSet<Basket> tbl_basket { get; set; }
        public DbSet<Notification> tbl_notification { get; set; }
    }
}
