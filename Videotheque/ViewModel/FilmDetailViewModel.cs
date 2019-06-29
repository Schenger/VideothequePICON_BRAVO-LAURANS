using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Models;
using Videotheque.Services;
using Videotheque.Tools;
using Videotheque.Views;

namespace Videotheque.ViewModel
{
    public class FilmDetailViewModel : Base
    {
        private readonly FilmService _filmService;
        public NavigationViewModel NavigationViewModel;

        public Film Film
        {
            get
            {
                return GetValue<Film>();
            }
            set
            {
                SetValue(value);
            }
        }

        public FilmDetailViewModel(Film film, NavigationViewModel navigationViewModel)
        {
            _filmService = new FilmService();
            NavigationViewModel = navigationViewModel;
            Film = film;
        }

        public async Task RemoveFilm()
        {
            await _filmService.RemoveFilm(Film);
            Film = null;            
        }
    }
}
