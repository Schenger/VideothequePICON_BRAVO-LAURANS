using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Videotheque.Tools;
using Videotheque.ViewModel;

namespace Videotheque.Views
{
    /// <summary>
    /// Logique d'interaction pour FilmDetail.xaml
    /// </summary>
    public partial class FilmDetail : Page
    {
        private FilmDetailViewModel _filmDetailViewModel;

        public FilmDetail()
        {            
            InitializeComponent();            
        }

        private void RemoveButton(object sender, RoutedEventArgs e)
        {
            _filmDetailViewModel.RemoveFilm();
            _filmDetailViewModel.NavigationViewModel.Page = NavigationCache.GetPage<Home, HomeViewModel>();
        }

        private void UpdateButton(object sender, RoutedEventArgs e)
        {
            _filmDetailViewModel.NavigationViewModel.Page = NavigationCache.GetPage<AddFilm, AddFilmViewModel>(true, _filmDetailViewModel.NavigationViewModel, _filmDetailViewModel.Film);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _filmDetailViewModel = DataContext as FilmDetailViewModel;
        }
    }
}
