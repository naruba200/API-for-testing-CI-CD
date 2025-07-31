using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;
using ProductsAPI.Services;
namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll() => _service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _service.GetById(id);
            if (product == null) return NotFound();
            return product;
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _service.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            if (id != product.Id) return BadRequest();
            if (_service.GetById(id) == null) return NotFound();

            _service.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.GetById(id) == null) return NotFound();
            _service.Delete(id);
            return NoContent();
        }
    }
}
