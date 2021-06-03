using PhotographyWebAppCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotographyWebAppCore.Repositories
{
    public interface IAlbumRepository
    {
        Task<Album> CreateOne(Album album);
        Task DeleteById(int id);
        Task<List<Album>> GetAll();
        Task<Album> GetById(int id);
        Task<Album> UpdateOne(Album album);
    }
}