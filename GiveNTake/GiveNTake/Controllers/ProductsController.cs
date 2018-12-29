using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GiveNTake.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GiveNTake.Controllers {
    [Route("api/[controller]")]
    public class ProductsController : Controller {
        private GiveNTakeContext _context;
        private static readonly IMapper _productsMapper;

        static ProductsController() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductDTO>()
                    .ForMember(dto => dto.City, opt => opt.MapFrom(product => product.City))
                    .ForMember(dto => dto.Category, opt => opt.MapFrom(product => product.Category.ParentCategory.Name))
                    .ForMember(dto => dto.Subcategory, opt => opt.MapFrom(product => product.Category.Name));

                cfg.CreateMap<City, CityDTO>()
                    .ForMember(dto => dto.CityId, opt => opt.MapFrom(city => city.CityId));
            });
            _productsMapper = config.CreateMapper();
        }

        public ProductsController(GiveNTakeContext context) {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> GetProduct() {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}", Name = nameof(GetProduct))]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id) {
            var product = await _context.Products
                .Include(p => p.Category)
                .ThenInclude(c => c.ParentCategory)
                .SingleOrDefaultAsync(p => p.ProductId == id);
            if (product == null) {
                return NotFound();
            }
            return Ok(_productsMapper.Map<ProductDTO>(product));
        }

        // POST api/values
        [HttpPost]
        public void AddNewProduct([FromBody]NewProductDTO newProduct) {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
