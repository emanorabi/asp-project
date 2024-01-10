using app2api.Data.Models;
using app2api.dto;
using Microsoft.AspNetCore.Mvc;

namespace app2api.Repository
{
    public interface IBrandrepository
    {
        Task<IEnumerable<Brand>> GetAll();
        Task<Brand> Add(Brand brand);
        Task<Brand> GetById(int id);
        Task<Brand> Update(Brand brand);
        Task<Brand>Delete(Brand brand);



        //Task<Genre> GetById(byte id);
        //Task<Genre> Add(Genre genre);
        //Genre Update(Genre genre);
        //Genre Delete(Genre genre);
    }
}
