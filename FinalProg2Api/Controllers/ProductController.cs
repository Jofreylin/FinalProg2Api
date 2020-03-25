using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using Persistence;
using Service;

namespace FinalProg2Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        

        public ProductController(IProductService productService)
        {
            _productService = productService;
            
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
           // return _producContext.Product;
           return Ok(_productService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_productService.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product model)
        {
            
            return Ok(_productService.Add(model));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Product model)
        {

            return Ok(_productService.Update(model));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(_productService.Delete(id));
        }

    }
}
