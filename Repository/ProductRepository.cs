using app2api.Data;
using app2api.Data.Models;
using app2api.dto;
using app2api.Migrations;
using Microsoft.EntityFrameworkCore;

namespace app2api.Repository
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(AppDbContext db)
        {
            _db = db;
        }
        private readonly AppDbContext _db;

        public async Task<Product> Add(Product product)
        {
            await _db.AddAsync(product);
            _db.SaveChanges();

            return product;
        }

        public async Task<Product> Delete(Product product)
        {
            _db.Remove(product);
            _db.SaveChanges();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _db.Products.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Product> Update(Product product)
        {
            
            _db.Update(product);
            await _db.SaveChangesAsync();

            return product;
        }
        
        public async Task<IEnumerable<Product>> GetProduct(int idBrand)
        {

            var pro = await _db.Products.Where(b => b.BrandId == idBrand).ToListAsync();
            return pro;


        }
    }
}
