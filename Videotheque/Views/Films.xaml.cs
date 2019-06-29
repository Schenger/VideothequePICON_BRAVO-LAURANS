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
using Videotheque.Models;
using Videotheque.Tools;
using Videotheque.ViewModel;

namespace Videotheque.Views
{
    /// <summary>
    /// Logique d'interaction pour Films.xaml
    /// </summary>
    public partial class Films : Page
    {
        private FilmsViewModel _filmViewModel;

        public Films()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _filmViewModel = DataContext as FilmsViewModel;
            await _filmViewModel.LoadFilms();
        }

        private void DetailItem(object sender, MouseButtonEventArgs e)
        {
            if(_filmViewModel.SelectedFilm != null)
            {
                _filmViewModel.NavigationViewModel.Page = NavigationCache.GetPage<FilmDetail, FilmDetailViewModel>(true, _filmViewModel.SelectedFilm, _filmViewModel.NavigationViewModel);
            }
        }        

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            _filmViewModel.Filter(((TextBox)sender).Text);
        }

        private void OrderFilm(object sender, MouseButtonEventArgs e)
        {
            _filmViewModel.OrderFilm(((TextBlock)sender).Text);
        }
    }
}
