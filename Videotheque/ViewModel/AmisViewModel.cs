using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Models;
using Videotheque.Services;

namespace Videotheque.ViewModel
{
    public class AmisViewModel : Base
    {
        private readonly AmiService _amiService;
        public NavigationViewModel NavigationViewModel;

        public Personne SelectedPersonne
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

        public List<Personne> Personnes
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

        public List<Personne> FullPersonnes
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

        public AmisViewModel(NavigationViewModel nav)
        {
            _amiService = new AmiService();
            NavigationViewModel = nav;
        }

        public async Task LoadAmis()
        {
            FullPersonnes = await _amiService.GetAmis();
            Personnes = FullPersonnes;
        }

        public void Filter(string filtre)
        {
            if (string.IsNullOrEmpty(filtre))
            {
                Personnes = FullPersonnes;
            }
            else
            {
                Personnes = FullPersonnes.Where(x => x.Prenom != null && x.Prenom.StartsWith(filtre)).ToList();
            }
        }

        public void Order(string order)
        {
            if (order == "Prenom")
            {
                Personnes = Personnes.OrderBy(x => x.Prenom).ToList();
            }
            if (order == "Nom")
            {
                Personnes = Personnes.OrderBy(x => x.Nom).ToList();
            }
            if (order == "Civilité")
            {
                Personnes = Personnes.OrderBy(x => x.Civilite).ToList();
            }
            if (order == "Nationalité")
            {
                Personnes = Personnes.OrderBy(x => x.Nationalite).ToList();
            }
        }
    }
}
