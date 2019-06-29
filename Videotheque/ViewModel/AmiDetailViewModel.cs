using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Models;
using Videotheque.Services;

namespace Videotheque.ViewModel
{
    public class AmiDetailViewModel : Base
    {
        private readonly AmiService _amiService;
        public NavigationViewModel NavigationViewModel;

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

        public AmiDetailViewModel(Personne pers, NavigationViewModel navigationViewModel)
        {
            _amiService = new AmiService();
            NavigationViewModel = navigationViewModel;
            Ami = pers;
        }

        public async Task Remove()
        {
            await _amiService.RemoveAmi(Ami);
            Ami = null;
        }
    }
}
