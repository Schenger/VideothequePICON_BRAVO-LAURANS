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
    public class PretsViewModel : Base
    {
        public NavigationViewModel NavigationViewModel;
        private readonly FilmService _filmService;
        private readonly AmiService _amiService;

        public List<Film> FilmDispo
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
        public List<Film> FilmPret
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
        public List<Personne> Amis
        {
            get
            {
                return GetValue<List<Personne>>();
            }
            set
            {
                SetValue(value);
            }
        }
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
        public Personne SelectedAmi
        {
            get
            {
                return GetValue<Personne>();
            }
            set
            {
                SetValue(value);
            }
        }
        public Film SelectedPret
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

        public PretsViewModel(NavigationViewModel nav)
        {
            NavigationViewModel = nav;
            _filmService = new FilmService();
            _amiService = new AmiService();            
        }

        public async Task Setup()
        {
            Amis = await _amiService.GetAmis();
            FilmDispo = await _filmService.GetDispo();
            FilmPret = await _filmService.GetPrets();
        }

        public async Task Preter()
        {
            if(SelectedAmi != null && SelectedFilm != null)
            {
                await _amiService.Preter(new MediaPersonne
                {
                    IdMedia = SelectedFilm.Id,
                    IdPersonne = SelectedAmi.Id
                });
                await Setup();
            }            
        }

        public async Task Rendre()
        {
            if(SelectedPret != null)
            {
                await _amiService.Rendre(SelectedPret.MediaPersonnes.First());
                await Setup();
            }            
        }

    }
}
