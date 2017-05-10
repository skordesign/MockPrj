using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MockPrj.Models;
using MockPrj.Repositories;

namespace MockPrj.Controllers
{
    [Route("api/[controller]")]
    [Authorize(ActiveAuthenticationSchemes = "Bearer")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _product;
        private readonly ICategoryRepository _cate;
        private readonly ILogger _logger;
        public ProductsController(IProductRepository product,
        ILogger<ProductsController> logger, ICategoryRepository cate)
        {
            _product = product;
            _logger = logger;
            _cate = cate;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            _logger.LogInformation("GET => All");
            return _product.All();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            _logger.LogInformation(@"GET => {id}", id);
            return _product.Get(id);
        }
         [HttpGet("count/{id}")]
        public IActionResult GetNumberProductOfCategory(int id)
        {
            _logger.LogInformation(@"GET => {id}", id);
            return Ok(_product.GetByCategory(id).ToList().Count);
        }

        [HttpGet("{cateId}/bycate")]
        public IEnumerable<Product> GetByCategory(int cateId)
        {
            _logger.LogInformation(@"GET by Id => {cateId}", cateId);
            return _product.GetByCategory(cateId);
        }
        [HttpPost("addcateId")]
        public IActionResult AddCategoryReturnId([FromBody]Category category)
        {
            _logger.LogInformation("BEGIN => Add Category return Id");
            if (_cate.Add(category))
            {
                _logger.LogInformation("END <= Add Category return Id");
                return Ok(category.Id);
            }
            _logger.LogInformation("FAILED <= Add Category return Id");
            return BadRequest();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            _logger.LogInformation("BEGIN => Add product");
            if (ModelState.IsValid)
            {
                if (_product.Add(product))
                {
                    _logger.LogInformation("END <= Add product");
                    return Ok();
                }
                _logger.LogInformation("FAILED <= Add product");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation("FAILED <= Add product");
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            _logger.LogInformation("BEGIN => Edit product");
            if (ModelState.IsValid)
            {
                _product.Update(product);
                _logger.LogInformation("END <= Edit product");
                return Ok();
            }
            else
            {
                _logger.LogInformation("FAILED <= Edit product");
                return BadRequest();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _logger.LogInformation("BEGIN => Remove product");
                _product.Remove(id);
                _logger.LogInformation("END <= Remove product");
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
