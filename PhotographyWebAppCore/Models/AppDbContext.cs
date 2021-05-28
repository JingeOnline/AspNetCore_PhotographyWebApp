using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotographyWebAppCore.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<PhotoCategory> PhotoCategory { get; set; }
        public DbSet<Photographer> Photographer { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>()
                .Property(x => x.LastUpdate)
                .HasDefaultValueSql("GETUTCDATE()");
            modelBuilder.Entity<Photo>()
                .Property(x => x.LastUpdateDateTime)
                .HasDefaultValueSql("GETUTCDATE()");
            //modelBuilder.Entity<Photo>()
            //    .HasOne(x => x.Photographer)
            //    .WithMany(y => y.Photos);
            //modelBuilder.Entity<Photographer>()
            //    .HasOne(x=>x.Avatar)
            //    .WithOne(y=>y.)
            base.OnModelCreating(modelBuilder);
        }
    }
}
