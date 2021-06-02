using PhotographyWebAppCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotographyWebAppCore.Repositories
{
    public interface IPhotoRepository
    {
        Task<Photo> CreateOne(Photo photo);
        Task DeleteById(int id);
        Task<List<Photo>> GetAll();
        Task<Photo> GetById(int id);
        Task<Photo> UpdateOne(Photo photo);
        Task<List<Photo>> CreateMultiple(List<Photo> photos);
        Task UpdateMultiple(List<Photo> photos);
    }
}