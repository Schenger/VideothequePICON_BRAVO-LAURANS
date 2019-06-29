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
    public class GenreService
    {
        public List<Genre> GetGenres()
        {
            var context = VideothequeDbContext.GetCurrent().Result;
            var genres = context.Genres.ToList();
            if (genres.Count == 0)
            {
                context.Genres.Add(new Genre { Nom = "Horreur" });
                context.Genres.Add(new Genre { Nom = "SF" });
                context.Genres.Add(new Genre { Nom = "Aventure" });
                context.Genres.Add(new Genre { Nom = "Action" });
                context.Genres.Add(new Genre { Nom = "Policer" });
                context.Genres.Add(new Genre { Nom = "Animation" });
                context.Genres.Add(new Genre { Nom = "Romantique" });
                context.SaveChanges();
                return GetGenres();
            }
            return genres;
        }

        public async Task RemoveMediaGenre(List<MediaGenre> mediaGenre)
        {
            var context = await VideothequeDbContext.GetCurrent();
            context.RemoveRange(mediaGenre);
            await context.SaveChangesAsync();
        }

        public List<MediaParGenre> GetMediaParGenre()
        {
            var context = VideothequeDbContext.GetCurrent().Result;
            List<MediaParGenre> mpd = context.MediasParGenre
                .FromSql("select g.Nom NomGenre, count(m.Id) NombreMedia from Genres g " +
                "inner join MediaGenre mg on g.Id = mg.IdGenre " +
                "inner join Media m on mg.IdMedia = m.Id " +
                "group by g.Nom").ToList();
            return mpd;
        }
    }
}
