using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Models;
using static System.Environment;

namespace Videotheque.DataAccess
{
    public class VideothequeDbContext : DbContext
    {
        private static VideothequeDbContext _context = null;
        public string DatabasePath { get; set; }

        public async static Task<VideothequeDbContext> GetCurrent()
        {
            if(_context == null)
            {
                _context = new VideothequeDbContext(Path.Combine(Environment.GetFolderPath(SpecialFolder.LocalApplicationData), "database.db"));
                await _context.Database.MigrateAsync(); 
            }
            return _context;
        }

        internal VideothequeDbContext(DbContextOptions options) : base(options)
        {

        }

        private VideothequeDbContext(string path) : base()
        {
            DatabasePath = path;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            base.OnConfiguring(optionBuilder);
            optionBuilder.UseSqlite($"Filename={DatabasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pret>().HasKey(x => new { x.IdMedia, x.IdPersonne });
            modelBuilder.Entity<MediaGenre>().HasKey(x => new { x.IdMedia, x.IdGenre });
            modelBuilder.Entity<MediaPersonne>().HasKey(x => new { x.IdMedia, x.IdPersonne });
            modelBuilder.Entity<MediaParGenre>().HasKey(x => new { x.NomGenre, x.NombreMedia });
        }

        public DbSet<Film> Films { get; set; }
        public DbSet<MediaGenre> MediaGenre { get; set; }
        public DbSet<MediaPersonne> MediaPersonne { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MediaParGenre> MediasParGenre { get; set; }
    }
}
