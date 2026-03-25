using BussinesLayer.Abstract;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IBasketService _basketService;
        private readonly IMenuTableService _menuTableService;
        private readonly SignalRContext _context;

        public OrderController(IOrderService orderService, IOrderDetailService orderDetailService, IBasketService basketService, IMenuTableService menuTableService, SignalRContext context)
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _basketService = basketService;
            _menuTableService = menuTableService;
            _context = context;
        }

        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            return Ok(_orderService.TTotalOrderCount());
        }
        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            return Ok(_orderService.TActiveOrderCount());
        }
        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice()
        {
            return Ok(_orderService.TLastOrderPrice());
        }
        [HttpGet("TodayTotalPrice")]
        public IActionResult TodayTotalPrice()
        {
            return Ok(_orderService.TTodayTotalPrice());
        }

        [HttpPost("CreateOrderFromBasket")]
        public IActionResult CreateOrderFromBasket(int menuTableId)
        {
            // Sepetteki ürünleri getir
            var basketItems = _context.tbl_basket
                .Include(x => x.Product)
                .Include(x => x.MenuTable)
                .Where(x => x.MenuTableId == menuTableId)
                .ToList();

            if (!basketItems.Any())
            {
                return BadRequest("Sepette ürün yok");
            }

            // Masa bilgisini al
            var menuTable = _menuTableService.TGetbyId(menuTableId);
            if (menuTable == null)
            {
                return NotFound("Masa bulunamadı");
            }

            // Toplam fiyatı hesapla
            decimal totalPrice = basketItems.Sum(x => x.TotalPrice);

            // Order oluştur
            var order = new Order
            {
                TableNumber = menuTable.Name,
                Description = "Müşteri Siparişi",
                Date = DateOnly.FromDateTime(DateTime.Now),
                TotalPrice = totalPrice
            };

            _orderService.TAdd(order);

            // OrderDetail'leri oluştur
            foreach (var basketItem in basketItems)
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = basketItem.ProductId,
                    Count = basketItem.Count,
                    UnitPrice = basketItem.Price,
                    TotalPrice = basketItem.TotalPrice,
                    OrderId = order.OrderId
                };
                _orderDetailService.TAdd(orderDetail);
            }

            // Sepeti temizle
            foreach (var basketItem in basketItems)
            {
                _basketService.TDelete(basketItem);
            }

            // Masa durumunu boşa çek
            menuTable.Status = false;
            _menuTableService.TUpdate(menuTable);

            return Ok(new { message = "Sipariş başarıyla oluşturuldu", orderId = order.OrderId });
        }
    }
}
