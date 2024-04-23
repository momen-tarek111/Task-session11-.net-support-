using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project3.Database;
using Project3.Models;
using Project3.Models.DTO;

namespace Project3.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ApplicationDbContext _db,IMapper _mp) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductDTO>))]
       
        public IActionResult getProduct()
        {
            var products = _db.Products.Include(m => m.company)/*.Select(m => new ProductDTO
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description,
                Price = m.Price,
                CompanyId = m.CompanyId,
                company = m.company
            })*/.ToList();
            return Ok(_mp.Map<List<ProductDTO>>(products));
        }
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult getProduct(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var products = _db.Products.Include(m => m.company).SingleOrDefault(p => p.Id == id);
            if (products == null)
            {
                return NotFound();
            }
            /*var productDTO = new ProductDTO {
                Id = products.Id,
                Name = products.Name,
                Description = products.Description,
                Price = products.Price,
                CompanyId = products.CompanyId,
                company = products.company
            };*/
            return Ok(_mp.Map<ProductDTO>(products));
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult deleteProduct(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var products = _db.Products.Include(m => m.company).SingleOrDefault(p => p.Id == id);
            if (products == null)
            {
                return NotFound();
            }
            _db.Remove(products);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult addProduct(ProductDTO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            /*var products = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CompanyId = product.CompanyId,
                EnableSize = true,
                Quantity = 10,
            };*/
            var products= _mp.Map<Controllers.ProductController>(product);
            products.EnableSize = true;
            products.Quantity = 10;
            _db.Add(products);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult updateProduct(ProductDTO productDTO)
        {
            if (!ModelState.IsValid&& productDTO.Id<=0)
            {
                return BadRequest();
            }
            var product = _db.Products.Include(m => m.company).FirstOrDefault(p => p.Id == productDTO.Id);
            /*if (product == null)
                return NotFound();
            product.Name = productDTO.Name;
            product.Description = productDTO.Description;
            product.Price = productDTO.Price;
            product.CompanyId = productDTO.CompanyId;*/
            /*var product = new Product();*/
            _mp.Map<ProductDTO, Controllers.ProductController>(productDTO, product);
            _db.SaveChanges();
            return Ok();
        }
    }
}
