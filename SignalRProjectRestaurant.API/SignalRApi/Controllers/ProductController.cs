using AutoMapper;
using BussinesLayer.Abstract;
using DataAccessLayer.Context;
using DtoLayer.ProductDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       private readonly IProductService _productService;
       private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var result = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(result);
        }
        [HttpGet("ProductDrinkCount")]
        public IActionResult ProductDrinkCount()
        {
            return Ok(_productService.TProductCountByCategoryNameIcecek());
        }
        [HttpGet("ProductFirinCount")]
        public IActionResult ProductFirinCount()
        {
            return Ok(_productService.TProductCountByCategoryNameFirin());
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TProductCount());
        }
        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            return Ok(_productService.TProductPriceAvg());
        }

        [HttpGet("ProductNameByMaxPrice")]
        public IActionResult ProductNameByMaxPrice()
        {
            return Ok(_productService.TProductNameByMaxPrice());
        }

        [HttpGet("ProductNameByMinPrice")]
        public IActionResult ProductNameByMinPrice()
        {
            return Ok(_productService.TProductNameByMinPrice());
        }
        [HttpGet("ProductPriceAvgFirin")]
        public IActionResult ProductPriceAvgFirin()
        {
            return Ok(_productService.TProductPriceAvgFirin());
        }
        [HttpGet("TotalPriceByIcecekCategory")]
        public IActionResult TotalPriceByIcecekCategory()
        {
            return Ok(_productService.TTotalPriceByIcecekCategory());
        }
        [HttpGet("GetFirst9Product")]
        public IActionResult GetFirst9Product()
        {
            var value = _productService.TGetFirst9Product();
            return Ok(value);
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        { 
            var context = new SignalRContext();
            var result = context.tbl_product.Include(x => x.Category).Select(y => new ResultProductWithCategory
            {
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ProductId = y.ProductId,
                ProductName = y.ProductName,
                ProductStatus = y.ProductStatus,
                CategoryName = y.Category.CategoryName
            });
            return Ok(result.ToList());
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(product);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var deger = _productService.TGetbyId(id);
            _productService.TDelete(deger);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var product = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(product);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var deger = _productService.TGetbyId(id);
            return Ok(deger);
        }
    }
}
