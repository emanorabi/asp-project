using app2api.Data;
using app2api.Data.Models;
using app2api.dto;
using app2api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app2api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandrepository _repo;
        public BrandsController(IBrandrepository repo)
        {
            _repo = repo;
        }
        //public BrandsController(AppDbContext db) {
        //    _db = db;
        //}
        //private readonly AppDbContext _db;
        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            return Ok(await _repo.GetAll());

        }
        [HttpPost]
        public async Task<IActionResult> AddBrand([FromForm] mdlBrand mdl)
        {
            using var stream = new MemoryStream();
            await mdl.LogoImage.CopyToAsync(stream);
            var brand = new Brand
            {
               Name = mdl.Name,
                LogoImage = stream.ToArray()
            };
            await _repo.Add(brand);
            
            return Ok(brand);

            }




        [HttpGet("{id}")]
        public async Task<IActionResult> Getonebrand(int id)
        {
            var bars = await _repo.GetById(id);
            if (bars == null)
            {
                return NotFound($"brand Id {id} not exists ");
            }
            return Ok(bars);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Updatebrand (int id, [FromForm] mdlBrand mdl)
        {
            var brand = await _repo.GetById(id);
            if (brand == null)
            {
                return NotFound($"  item id {id} not exists !");
            }
            if (mdl.LogoImage != null)
            {
                using var stream = new MemoryStream();
                await mdl.LogoImage.CopyToAsync(stream);
                brand.LogoImage = stream.ToArray();
            }
            brand.Name = mdl.Name;
            _repo.Update(brand);

            return Ok(brand);
            }






        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletebrand(int id)
        {
            var bars = await _repo.GetById(id);
            if (bars == null)
            {
                return NotFound($"brand Id {id} not exists ");
            }
            _repo.Delete(bars);
            return Ok(bars);

        }

    }
}
