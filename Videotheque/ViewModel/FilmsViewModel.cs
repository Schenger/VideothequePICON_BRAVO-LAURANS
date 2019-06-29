using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Models;
using Videotheque.Services;

namespace Videotheque.ViewModel
{
    public class FilmsViewModel : Base
    {
        private readonly FilmService _filmService;
        public NavigationViewModel NavigationViewModel;

        public Film SelectedFilm
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

        public List<Film> Films
        {
            get
            {
                return GetValue<List<Film>>();
            }
            set
            {
                SetValue(value);
            }
        }

        public List<Film> FullFilms
        {
            get
            {
                return GetValue<List<Film>>();
            }
            set
            {
                SetValue(value);
            }
        }

        public FilmsViewModel(NavigationViewModel nav)
        {
            _filmService = new FilmService();
            NavigationViewModel = nav;
        }

        public async Task LoadFilms()
        {
            Films = await _filmService.GetFilm();
            FullFilms = Films;
        }

        public void Filter(string filtre)
        {
            if (string.IsNullOrEmpty(filtre))
            {
                Films = FullFilms;
            }
            else
            {
                Films = FullFilms.Where(x => x.Titre != null && x.Titre.StartsWith(filtre)).ToList();
            }
        }

        public void OrderFilm(string order)
        {
            if(order == "Titre")
            {
                Films = Films.OrderBy(x => x.Titre).ToList();
            }
            if (order == "Duree")
            {
                Films = Films.OrderBy(x => x.Duree).ToList();
            }
            if (order == "Note")
            {
                Films = Films.OrderBy(x => x.Note).ToList();
            }
            if (order == "Age minimum")
            {
                Films = Films.OrderBy(x => x.AgeMinimum).ToList();
            }
            if (order == "Langue")
            {
                Films = Films.OrderBy(x => x.LangueMedia).ToList();
            }
        }
    }
}
