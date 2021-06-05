using PhotographyWebAppCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotographyWebAppCore.Repositories
{
    public interface IPhotographerRepository
    {
        Task<Photographer> CreateOne(Photographer photographer);
        Task DelteById(int id);
        Task<List<Photographer>> GetAll();
        Task<Photographer> GetById(int id);
        Task<Photographer> Update(Photographer photographer);
    }
}