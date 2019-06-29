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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Videotheque.Tools;
using Videotheque.ViewModel;
using Videotheque.Views;

namespace Videotheque
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NavigationViewModel _navigationViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _navigationViewModel = new NavigationViewModel();
            DataContext = _navigationViewModel;
            _navigationViewModel.Page = NavigationCache.GetPage<Home, HomeViewModel>();
        }

        private void AddFilmNav(object sender, RoutedEventArgs e)
        {
            _navigationViewModel.Page = NavigationCache.GetPage<AddFilm, AddFilmViewModel>(true, _navigationViewModel, null);
        }

        private void FilmsNav(object sender, RoutedEventArgs e)
        {
            _navigationViewModel.Page = NavigationCache.GetPage<Films, FilmsViewModel>(true, _navigationViewModel);
        }

        private void HomeNav(object sender, RoutedEventArgs e)
        {
            _navigationViewModel.Page = NavigationCache.GetPage<Home, HomeViewModel>(true);
        }

        private void AmisNav(object sender, RoutedEventArgs e)
        {
            _navigationViewModel.Page = NavigationCache.GetPage<Amis, AmisViewModel>(true, _navigationViewModel);
        }

        private void AddAmiNav(object sender, RoutedEventArgs e)
        {
            _navigationViewModel.Page = NavigationCache.GetPage<AddAmi, AddAmiViewModel>(true, _navigationViewModel, null);
        }

        private void PretNav(object sender, RoutedEventArgs e)
        {
            _navigationViewModel.Page = NavigationCache.GetPage<Prets, PretsViewModel>(true, _navigationViewModel);
        }

        private void Frame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            var animation = new ThicknessAnimation();
            animation.Duration = TimeSpan.FromSeconds(0.3);
            animation.DecelerationRatio = 0.7;
            animation.To = new Thickness(0, 0, 0, 0);
            animation.From = new Thickness(500, 0, 0, 0);
            (e.Content as Page).BeginAnimation(MarginProperty, animation);
        }
    }
}
