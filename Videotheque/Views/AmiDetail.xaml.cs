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
    /// Logique d'interaction pour AmiDetail.xaml
    /// </summary>
    public partial class AmiDetail : Page
    {
        private AmiDetailViewModel _amiDetailViewModel;

        public AmiDetail()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _amiDetailViewModel = DataContext as AmiDetailViewModel;
        }

        private void Modifier(object sender, RoutedEventArgs e)
        {
            _amiDetailViewModel.NavigationViewModel.Page = NavigationCache.GetPage<AddAmi, AddAmiViewModel>(true, _amiDetailViewModel.NavigationViewModel, _amiDetailViewModel.Ami);
        }

        private void Supprimer(object sender, RoutedEventArgs e)
        {
            _amiDetailViewModel.Remove();
            _amiDetailViewModel.NavigationViewModel.Page = NavigationCache.GetPage<Home, HomeViewModel>();
        }
    }
}
