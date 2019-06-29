using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Models;
using Videotheque.Models.Enums;
using Videotheque.Tools;
using Videotheque.Services;
using Videotheque.Views;

namespace Videotheque.ViewModel
{
    public class AddFilmViewModel : Base
    {
        private bool _update;
        private readonly FilmService _filmService;
        private readonly GenreService _genreService;
        public NavigationViewModel NavigationViewModel;

        public List<ComboboxUtils> Langues
        {
            get
            {
                return GetValue<List<ComboboxUtils>>();
            }
            set
            {
                SetValue(value);
            }
        }

        public List<Genre> Genres
        {
            get
            {
                return GetValue<List<Genre>>();
            }
            set
            {
                SetValue(value);
            }
        }

        public Film Film
        {
            get
            {
                return GetValue<Film>();
            }
            set
            {
                SetValue<Film>(value);
            }
        }

        public AddFilmViewModel(NavigationViewModel nav, Film film = null)
        {
            _filmService = new FilmService();
            _genreService = new GenreService();
            NavigationViewModel = nav;
            Genres = _genreService.GetGenres();
            Langues = ComboboxUtils.init(new Langue());
            if(film == null)
            {
                Film = new Film();
                _update = false;
            }
            else
            {
                Film = film;
                _update = true;
            }            
        }

        public async Task Add()
        {
            if (IsValid())
            {
                if (_update)
                {
                    if(Film.MediaGenres != null && Film.MediaGenres.Count > 0)
                    {
                        await _genreService.RemoveMediaGenre(Film.MediaGenres);
                    }
                    Film.MediaGenres = new List<MediaGenre>();
                    Film.MediaGenres.Add(new MediaGenre { Genre = Genres.First(x => x.Nom == Film.Genre.Nom), IdGenre = Genres.First(x => x.Nom == Film.Genre.Nom).Id });
                    await _filmService.UpdateFilm(Film);
                    NavigationViewModel.Page = NavigationCache.GetPage<Films, FilmsViewModel>(true, NavigationViewModel);
                }
                else
                {
                    Film.MediaGenres = new List<MediaGenre>();
                    Film.MediaGenres.Add(new MediaGenre { Genre = Genres.First(x => x.Nom == Film.Genre.Nom), IdGenre = Genres.First(x => x.Nom == Film.Genre.Nom).Id });
                    await _filmService.AddFilm(Film);
                    Film = null;
                    NavigationViewModel.Page = NavigationCache.GetPage<Films, FilmsViewModel>(true, NavigationViewModel);
                }
            }                   
        }

        public bool IsValid()
        {
            return Film.Genre != null;
        }
    }
}
