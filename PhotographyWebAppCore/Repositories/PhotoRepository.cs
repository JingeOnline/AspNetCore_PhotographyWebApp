using PhotographyWebAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PhotographyWebAppCore.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly AppDbContext _context;
        public PhotoRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<List<Photo>> GetAll()
        {
            return await _context.Photo.ToListAsync();
        }

        public async Task<Photo> GetById(int id)
        {
            return await _context.Photo.FindAsync(id);
        }

        public async Task<Photo> CreateOne(Photo photo)
        {
            if (photo.Title == null)
            {
                photo.Title = photo.PhotoFile.FileName;
            }
            photo.UploadDateTime = DateTime.UtcNow;
            photo.LastUpdateDateTime = DateTime.UtcNow;
            await _context.Photo.AddAsync(photo);
            _context.SaveChanges();
            return photo;
        }

        public async Task<List<Photo>> CreateMultiple(List<Photo> photos)
        {
            foreach(Photo photo in photos)
            {
                photo.Title = photo.PhotoFile.FileName;
                photo.UploadDateTime = DateTime.UtcNow;
                photo.LastUpdateDateTime = DateTime.UtcNow;
            }
            await _context.Photo.AddRangeAsync(photos);
            _context.SaveChanges();
            return photos;
        }

        public async Task<Photo> UpdateOne(Photo photo)
        {
            Photo p = await _context.Photo.FindAsync(photo.Id);
            p.Title = photo.Title;
            p.Description = photo.Description;
            p.Photographer = photo.Photographer;
            p.LastUpdateDateTime = DateTime.UtcNow;
            _context.SaveChanges();
            return p;
        }

        public async Task DeleteById(int id)
        {
            Photo photo = await _context.Photo.FindAsync(id);
            _context.Photo.Remove(photo);
            _context.SaveChanges();
        }
    }
}
