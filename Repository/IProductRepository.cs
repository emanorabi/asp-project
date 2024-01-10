using app2api.Data.Models;

namespace app2api.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> Add(Product product);
        Task<Product> GetById(int id);
        Task<Product> Update(Product product);
        Task<Product> Delete(Product product);
        Task <IEnumerable<Product>> GetProduct(int idBrand);
    }
}
