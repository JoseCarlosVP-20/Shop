
namespace Shop.Web.Controllers.API
{
using Microsoft.AspNetCore.Mvc;
    using Shop.Web.Data;
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    [Route("api/[Controller]")]
    public class ProductsController: Controller
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProduts()
        {
            return Ok(this.productRepository.GetAll());
        }
    }
}
