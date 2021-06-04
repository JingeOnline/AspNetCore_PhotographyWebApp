using PhotographyWebAppCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotographyWebAppCore.Repositories
{
    public interface IAlbumRepository
    {
        Task<Album> CreateOne(Album album);
        Task DeleteById_DeletePhotos(int id);
        Task DeleteById_LeavePhotos(int id);
        Task<List<Album>> GetAll();
        Task<Album> GetById(int id);
        Task<Album> UpdateOne(Album album);
    }
}