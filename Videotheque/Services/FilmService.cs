using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.DataAccess;
using Videotheque.Models;

namespace Videotheque.Services
{
    public class FilmService
    {
        public async Task AddFilm(Film film)
        {
            var context = await VideothequeDbContext.GetCurrent();
            context.Add(film);
            await context.SaveChangesAsync();

        }
        
        public async Task<List<Film>> GetFilm()
        {
            var context = await VideothequeDbContext.GetCurrent();
            List<Film> films = new List<Film>();
            await Task.Run(() => {
                films = context.Films.ToList();
                foreach(Film f in films)
                {
                    f.MediaGenres = context.MediaGenre.Where(x => x.IdMedia == f.Id).ToList();
                    f.Genre = context.Genres.First(x => x.Id == f.MediaGenres.First().IdGenre);
                }
            });            
            return films;
        }

        public async Task<List<Film>> GetPrets()
        {
            var context = await VideothequeDbContext.GetCurrent();
            List<Film> films = new List<Film>();
            await Task.Run(() => {
                films = context.Films.FromSql(@"select m.Id, m.Titre, m.Statut, m.DateCreation, m.Note, m.Commentaire, m.Synopsis, m.AgeMinimum, 
                                                m.LangueVO, m.LangueMedia, m.SousTitre, m.AudioDescription, m.SupportPhysique, m.SupportNumerique, m.Duree
                                                , m.Discriminator, m.Photo
                                                from Media m 
                                                left join MediaPersonne mp on m.Id = mp.IdMedia 
                                                where m.SupportPhysique = 1 and mp.IdPersonne is not null").ToList();
                foreach (Film f in films)
                {
                    f.MediaGenres = context.MediaGenre.Where(x => x.IdMedia == f.Id).ToList();
                    f.MediaPersonnes = context.MediaPersonne.Where(x => x.IdMedia == f.Id).ToList();
                    f.Personne = context.Personnes.First(x => x.Id == f.MediaPersonnes.First().IdPersonne);
                    f.Genre = context.Genres.First(x => x.Id == f.MediaGenres.First().IdGenre);
                }
            });
            return films;
        }

        public async Task<List<Film>> GetDispo()
        {
            var context = await VideothequeDbContext.GetCurrent();
            List<Film> films = new List<Film>();
            await Task.Run(() => {
                films = context.Films.FromSql(@"select m.Id, m.Titre, m.Statut, m.DateCreation, m.Note, m.Commentaire, m.Synopsis, m.AgeMinimum, 
                                                m.LangueVO, m.LangueMedia, m.SousTitre, m.AudioDescription, m.SupportPhysique, m.SupportNumerique, m.Duree
                                                , m.Discriminator, m.Photo
                                                from Media m 
                                                left join MediaPersonne mp on m.Id = mp.IdMedia 
                                                where m.SupportPhysique = 1 and mp.IdPersonne is null").ToList();
                foreach (Film f in films)
                {
                    f.MediaGenres = context.MediaGenre.Where(x => x.IdMedia == f.Id).ToList();
                    f.Genre = context.Genres.First(x => x.Id == f.MediaGenres.First().IdGenre);
                }
            });
            return films;
        }

        public async Task RemoveFilm(Film film)
        {
            var context = await VideothequeDbContext.GetCurrent();
            context.Remove(film);
            await context.SaveChangesAsync();
        }

        public async Task UpdateFilm(Film film)
        {
            var context = await VideothequeDbContext.GetCurrent();
            context.Update(film);
            await context.SaveChangesAsync();
        }
    }
}
