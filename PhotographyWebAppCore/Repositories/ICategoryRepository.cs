using PhotographyWebAppCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotographyWebAppCore.Repositories
{
    public interface ICategoryRepository
    {
        Task<PhotoCategory> CreateOne(PhotoCategory photoCategory);
        void DeleteOne(PhotoCategory photoCategory);
        Task<List<PhotoCategory>> GetAll();
        Task<PhotoCategory> UpdateOne(PhotoCategory photoCategory);
    }
}