using Microsoft.EntityFrameworkCore;
using PhotographyWebAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotographyWebAppCore.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly AppDbContext _context;

        public AlbumRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Album>> GetAll()
        {
            //这里进行了联合查询，引用了外键表的对象
            return await _context.Album
                .Include(x=>x.Category)
                .Include(x=>x.Photos)
                .ToListAsync();
        }

        public async Task<Album> GetById(int id)
        {
            Album album = await _context.Album.FindAsync(id);
            return album;
        }

        public async Task<Album> CreateOne(Album album)
        {
            album.CreatedDateTime = DateTime.UtcNow;
            album.LastUpdate = DateTime.UtcNow;
            await _context.Album.AddAsync(album);
            _context.SaveChanges();
            return album;
        }

        public async Task<Album> UpdateOne(Album album)
        {
            Album a = await _context.Album.FindAsync(album.Id);
            a.LastUpdate = DateTime.UtcNow;
            a.Photos = album.Photos;
            a.Title = album.Title;
            a.Description = album.Description;
            a.CoverPhotoId = album.CoverPhotoId;
            a.CategoryId = album.CategoryId;
            _context.SaveChanges();
            return a;
        }

        public async Task DeleteById(int id)
        {
            Album album = await _context.Album.FindAsync(id);
            _context.Album.Remove(album);
            _context.SaveChanges();
        }
    }
}
