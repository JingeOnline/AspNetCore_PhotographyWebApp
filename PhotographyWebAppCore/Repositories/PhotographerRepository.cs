using PhotographyWebAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PhotographyWebAppCore.Repositories
{
    public class PhotographerRepository : IPhotographerRepository
    {
        private readonly AppDbContext _context;
        public PhotographerRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<List<Photographer>> GetAll()
        {
            List<Photographer> photographers = await _context.Photographer
                .Include(x => x.Avatar)
                .Include(x=>x.Photos)
                .OrderByDescending(x=>x.Id)
                .ToListAsync();
            return photographers;
        }

        public async Task<Photographer> GetById(int id)
        {
            Photographer photographer = await _context.Photographer.Include(x => x.Avatar).FirstOrDefaultAsync(x => x.Id == id);

            return photographer;
        }

        public async Task<Photographer> CreateOne(Photographer photographer)
        {
            await _context.Photographer.AddAsync(photographer);
            _context.SaveChanges();
            return photographer;
        }

        public async Task<Photographer> Update(Photographer photographer)
        {
            Photographer p = await _context.Photographer.FindAsync(photographer.Id);
            if (p != null)
            {
                p.Name = photographer.Name;
                p.Description = photographer.Description;
                p.AvatarId = photographer.AvatarId;
                _context.SaveChanges();
            }
            return p;
        }

        public async Task DelteById(int id)
        {
            Photographer p = await _context.Photographer.FindAsync(id);
            if (p != null)
            {
                _context.Photographer.Remove(p);
                _context.SaveChanges();
            }
        }
    }
}
