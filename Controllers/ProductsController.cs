using app2api.Data.Models;
using app2api.Data;
using app2api.dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using app2api.Repository;

namespace app2api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }
        //public BrandsController(AppDbContext db) {
        //    _db = db;
        //}
        //private readonly AppDbContext _db;
        [HttpGet]
        public async Task<IActionResult> GetAllproduct()
        {
            return Ok(await _repo.GetAll());

        }
        [HttpPost]
        public async Task<IActionResult> AddBrand([FromForm] mdlProduct mdl)
        {
            
            var product = new Product
            {
                Name = mdl.Name,
                Price = mdl.Price,
                Description = mdl.Description,
                BrandId = mdl.BrandId,
            };
            await _repo.Add(product);

            return Ok(product);

        }




        [HttpGet("{id}")]
        public async Task<IActionResult> Getoneproduct(int id)
        {
            var pro = await _repo.GetById(id);
            if (pro == null)
            {
                return NotFound($"product Id {id} not exists ");
            }
            return Ok(pro);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Updateproduct(int id, [FromForm] mdlProduct mdl)
        {
            var product = await _repo.GetById(id);
            if (product == null)
            {
                return NotFound($" product id {id} not exists !");
            }

            
            product.Name = mdl.Name;
            product.Price = mdl.Price;
            product.Description = mdl.Description;
            product.BrandId = mdl.BrandId;  

            await _repo.Update(product);

            return Ok(product);
        }






        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteproduct(int id)
        {
            var pro = await _repo.GetById(id);
            if (pro == null)
            {
                return NotFound($"product Id {id} not exists ");
            }
            _repo.Delete(pro);
            return Ok(pro);


        }
        [HttpGet("ProductsWithBrand/{idBrand}")]
        public async Task<IActionResult> AllProductWithBrand(int idBrand)
        {
            var pros = await _repo.GetProduct(idBrand);
            return Ok(pros);
        }



    }
}
