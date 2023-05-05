using BeersApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeersApplication.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {
                
        }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Parrot> Parrots { get; set; }
        public DbSet<Species> Species { get; set; }

        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed the datebase with beers
            var beers = new List<Beer>();
            beers.Add(new Beer
            {
                Id = 1,
                Name = "Glarus English Ale",
                Abv = 4.6,
                StyleId = 1
            });
            beers.Add(new Beer
            {
                Id = 2,
                Name = "Pirinsko",
                Abv = 4,
                StyleId = 1
            });
            beers.Add(new Beer
            {
                Id = 3,
                Name = "Leffe",
                Abv = 5.2,
                StyleId = 2
            });
            beers.Add(new Beer
            {
                Id = 4,
                Name = "London Pale Ale",
                Abv = 4.7,
                StyleId = 3
            });
            beers.Add(new Beer
            {
                Id = 5,
                Name = "Bernard",
                Abv = 6.6,
                StyleId = 3
            });
            modelBuilder.Entity<Beer>().HasData(beers);

            //Seed the database with styles
            var styles = new List<Style>();
            styles.Add(new Style
            {
                Id = 1,
                Name = "Special Ale"
            });
            styles.Add(new Style
            {
                Id = 2,
                Name = "English Porter"
            });
            styles.Add(new Style
            {
                Id = 3,
                Name = "Indian Pale Ale"
            });
            modelBuilder.Entity<Style>().HasData(styles);

            //Seed the database with users
            var users = new List<User>();
            users.Add(new User
            {
                Id = 1,
                Username = "admin",
                IsAdmin = true
            });
            users.Add(new User
            {
                Id = 2,
                Username = "gosho",
                IsAdmin = false
            });
            users.Add(new User
            {
                Id = 3,
                Username = "pesho",
                IsAdmin = false
            });
            modelBuilder.Entity<User>().HasData(users);

            //Seed the database with ratings
            var ratings = new List<Rating>();
            ratings.Add(new Rating() { Id = 1, BeerId = 1, UserId = 3, Value = 5 });
            ratings.Add(new Rating() { Id = 2, BeerId = 1, UserId = 2, Value = 3 });
            ratings.Add(new Rating() { Id = 3, BeerId = 2, UserId = 1, Value = 1 });
            ratings.Add(new Rating() { Id = 4, BeerId = 3, UserId = 3, Value = 0 });
            ratings.Add(new Rating() { Id = 5, BeerId = 4, UserId = 2, Value = 4 });
            ratings.Add(new Rating() { Id = 6, BeerId = 5, UserId = 3, Value = 2 });
            modelBuilder.Entity<Rating>().HasData(ratings);

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
