using PhotographyWebAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PhotographyWebAppCore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<List<PhotoCategory>> GetAll()
        {
            return await _context.PhotoCategory.Include(x=>x.CoverPhoto)
                .Include(x=>x.Albums).ThenInclude(y=>y.CoverPhoto)
                .OrderByDescending(x=>x.Id).ToListAsync();
        }

        public async Task<PhotoCategory> GetById(int id)
        {
            return await _context.PhotoCategory.Include(x => x.CoverPhoto).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PhotoCategory> CreateOne(PhotoCategory photoCategory)
        {
            await _context.PhotoCategory.AddAsync(photoCategory);
            _context.SaveChanges();
            return photoCategory;
        }

        public async Task<PhotoCategory> UpdateOne(PhotoCategory photoCategory)
        {
            PhotoCategory category = await _context.PhotoCategory.FindAsync(photoCategory.Id);
            category.Name = photoCategory.Name;
            category.Description = photoCategory.Description;
            category.CoverPhotoId = photoCategory.CoverPhotoId;
            _context.SaveChanges();
            return category;
        }

        public async Task DeleteById(int id)
        {
            PhotoCategory category = await _context.PhotoCategory.FindAsync(id);
            _context.PhotoCategory.Remove(category);
            _context.SaveChanges();
        }
    }
}
