using ParrotsApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParrotsApplication.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {
                
        }
        public DbSet<Parrot> Parrots { get; set; }
        public DbSet<Species> Species { get; set; }

        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            var species = new List<Species>();
            species.Add(new Species() { Id = 1, Name = "African Gray" });
            species.Add(new Species() { Id = 2, Name = "Indian Blue" });
            species.Add(new Species() { Id = 3, Name = "Cockatiel" });

            modelBuilder.Entity<Species>().HasData(species);

            var parrots = new List<Parrot>();
            parrots.Add(new Parrot() { Id = 1, Name = "Djaro", Size = "Large", NoiseLevel= 3.0, SpeciesId= 1});
            parrots.Add(new Parrot() { Id = 2, Name = "Hamlet", Size = "Medium", NoiseLevel = 4.5, SpeciesId = 2});
            parrots.Add(new Parrot() { Id = 3, Name = "Gizmo", Size = "Large", NoiseLevel = 3.0, SpeciesId = 1 });
            parrots.Add(new Parrot() { Id = 4, Name = "Kiwi", Size = "Medium", NoiseLevel = 4.0, SpeciesId = 2 });
            parrots.Add(new Parrot() { Id = 5, Name = "YumYum", Size = "Small", NoiseLevel = 3.0, SpeciesId = 3 });
            parrots.Add(new Parrot() { Id = 6, Name = "Ginger", Size = "Small", NoiseLevel = 3.0, SpeciesId = 3 });
            parrots.Add(new Parrot() { Id = 7, Name = "Apollo", Size = "Large", NoiseLevel = 3.0, SpeciesId = 1 });

            modelBuilder.Entity<Parrot>().HasData(parrots);

            //Seed the database with videos
            var videos = new List<Video>();
            videos.Add(new Video() { Id = 1, ParrotId = 3, Value = "https://www.youtube.com/shorts/YCVK-aqeAHo" });
            videos.Add(new Video() { Id = 2, ParrotId = 3, Value = "https://www.youtube.com/shorts/QrmWkpblL_U" });
            videos.Add(new Video() { Id = 3, ParrotId = 2, Value = "https://www.youtube.com/shorts/1rLyvVi8nRU" });
            videos.Add(new Video() { Id = 4, ParrotId = 2, Value = "https://www.youtube.com/shorts/EA9J3poFlOs" });
            videos.Add(new Video() { Id = 5, ParrotId = 5, Value = "https://www.youtube.com/shorts/UFt2pt7eTyY" });
            videos.Add(new Video() { Id = 6, ParrotId = 4, Value = "https://www.youtube.com/shorts/Hw8-jbTtqdA" });
            videos.Add(new Video() { Id = 7, ParrotId = 1, Value = "https://www.youtube.com/watch?v=er9uysEEyX4" });
            videos.Add(new Video() { Id = 8, ParrotId = 1, Value = "https://www.youtube.com/watch?v=7Arab-zmne0" });
            videos.Add(new Video() { Id = 9, ParrotId = 6, Value = "https://www.youtube.com/watch?v=MIAwx3XwnsY" });
            videos.Add(new Video() { Id = 10, ParrotId = 7, Value = "https://www.youtube.com/shorts/_AmBMMv88rI" });
            videos.Add(new Video() { Id = 11, ParrotId = 7, Value = "https://www.youtube.com/shorts/FVxlikv7QWM" });
            videos.Add(new Video() { Id = 12, ParrotId = 6, Value = "https://www.youtube.com/watch?v=7Arab-zmne0" });

            modelBuilder.Entity<Video>().HasData(videos);
        }
    }
}
