using app2api.Data;
using app2api.Data.Models;
using app2api.dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app2api.Repository
{


    public class BrandRepository : IBrandrepository
    {
        public BrandRepository(AppDbContext db)
        {
            _db = db;
        }
        private readonly AppDbContext _db;

        public async Task<IEnumerable<Brand>> GetAll()
        {
            return await _db.Brands.ToListAsync();
        }

        public async Task<Brand> Add(Brand brand)
        {
            await _db.AddAsync(brand);
            _db.SaveChanges();

            return brand;

        }

        public async Task<Brand> GetById(int id)
        {
            return await _db.Brands.SingleOrDefaultAsync(b => b.Id == id);

        }

        public async Task<Brand> Update(Brand brand)
        {
            _db.Update(brand);
            _db.SaveChanges();

            return brand;
        }

        public async Task<Brand> Delete(Brand brand)
        {
            
            _db.Remove(brand);
            _db.SaveChanges();
            return brand;
        }
    }
}
