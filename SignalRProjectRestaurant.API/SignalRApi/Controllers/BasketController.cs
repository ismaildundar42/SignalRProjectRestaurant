using BussinesLayer.Abstract;
using DataAccessLayer.Context;
using DtoLayer.BasketDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly SignalRContext _signalRContext;

        public BasketController(IBasketService basketService, SignalRContext signalRContext)
        {
            _basketService = basketService;
            _signalRContext = signalRContext;
        }
        [HttpGet]
        public IActionResult GetBasketByMenuTableNumber(int id)
        {
            return Ok(_basketService.TGetBasketByMenuTableNumber(id));
        }
        [HttpGet("GetBasketWithProductName")]
        public IActionResult GetBasketWithProductName(int id)
        {
            using var context = new SignalRContext();
            var values = context.tbl_basket.Include(x=>x.Product).Where(y=>y.MenuTableId == id).Select(z => new ResultBasketWithProduct
            {
                BasketId = z.BasketId,
                Price = z.Price,
                Count = z.Count,
                TotalPrice = z.TotalPrice,
                ProductId = z.ProductId,
                MenuTableId = z.MenuTableId,
                ProductName = z.Product.ProductName
            }).ToList();

            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            _basketService.TAdd(new Basket()
            {
                ProductId = createBasketDto.ProductId,
                Count = 1,
                MenuTableId = 16,
                Price = _signalRContext.tbl_product.Where(x => x.ProductId == createBasketDto.ProductId).Select(y => y.Price).FirstOrDefault(),
                TotalPrice = createBasketDto.TotalPrice
            });

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetbyId(id);
            _basketService.TDelete(value);
            return Ok("Başarılı bir şekilde silindi");
        }
    }
}
