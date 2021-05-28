using PhotographyWebAppCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotographyWebAppCore.Repositories
{
    public interface ICategoryRepository
    {
        Task<PhotoCategory> CreateOne(PhotoCategory photoCategory);
        Task DeleteById(int id);
        Task<List<PhotoCategory>> GetAll();
        Task<PhotoCategory> GetById(int id);
        Task<PhotoCategory> UpdateOne(PhotoCategory photoCategory);
    }
}