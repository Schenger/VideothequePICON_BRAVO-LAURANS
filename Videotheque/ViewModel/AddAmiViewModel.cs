using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Models;
using Videotheque.Models.Enums;
using Videotheque.Services;
using Videotheque.Tools;
using Videotheque.Views;

namespace Videotheque.ViewModel
{
    public class AddAmiViewModel : Base
    {
        private bool _update;
        private readonly AmiService _amiService;
        public NavigationViewModel NavigationViewModel;

        public List<ComboboxUtils> Civilites
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

        public List<ComboboxUtils> Nationalites
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

        public Personne Ami
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

        public AddAmiViewModel(NavigationViewModel nav, Personne pers = null)
        {
            _amiService = new AmiService();
            NavigationViewModel = nav;
            Civilites = ComboboxUtils.init(new Civilite());
            Nationalites = ComboboxUtils.init(new Langue());
            if (pers == null)
            {
                Ami = new Personne();
                _update = false;
            }
            else
            {
                Ami = pers;
                _update = true;
            }
        }

        public async Task Add()
        {
            if (_update)
            {
                await _amiService.UpdateAmi(Ami);
                NavigationViewModel.Page = NavigationCache.GetPage<Amis, AmisViewModel>(true, NavigationViewModel);
            }
            else
            {
                Ami.EstAmi = true;
                await _amiService.AddAmi(Ami);
                Ami = null;
                NavigationViewModel.Page = NavigationCache.GetPage<Amis, AmisViewModel>(true, NavigationViewModel);
            }
        }
    }
}
