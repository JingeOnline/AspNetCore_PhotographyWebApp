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
                .OrderByDescending(x=>x.Id)
                .ToListAsync();
        }

        public async Task<Album> GetById(int id)
        {
            Album album = await _context.Album.Include(x => x.Photos).FirstOrDefaultAsync(x => x.Id == id);
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

        public async Task DeleteById_LeavePhotos(int id)
        {
            //由于Photo对象中拥有AlbumId作为外键，所以删除Album之前，必须清除这种外键依赖的关系。
            //此处使用导航属性来清除外键依赖关系
            Album album = await _context.Album.Include(x => x.Photos).FirstOrDefaultAsync(y=>y.Id==id);
            album.Photos.Clear();

            _context.Album.Remove(album);
            _context.SaveChanges();
        }

        //真正的配置级联删除参考以下文档
        //https://docs.microsoft.com/zh-cn/ef/core/saving/cascade-delete
        //这种方式一旦配置想不级联删除都不行，所以此处使用手动删除
        public async Task DeleteById_DeletePhotos(int id)
        {
            Album album = await _context.Album.Include(x => x.Photos).FirstOrDefaultAsync(y => y.Id == id);
            List<Photo> photos = album.Photos;
            _context.Photo.RemoveRange(photos);
            //_context.SaveChanges();

            _context.Album.Remove(album);
            _context.SaveChanges();
        }
    }
}
