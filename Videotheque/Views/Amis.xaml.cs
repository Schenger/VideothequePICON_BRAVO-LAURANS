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
using Videotheque.ViewModel;
using Videotheque.Tools;

namespace Videotheque.Views
{
    /// <summary>
    /// Logique d'interaction pour Amis.xaml
    /// </summary>
    public partial class Amis : Page
    {
        private AmisViewModel _amisViewModel;

        public Amis()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _amisViewModel = DataContext as AmisViewModel;
            await _amisViewModel.LoadAmis();
        }

        private void DetailItem(object sender, RoutedEventArgs e)
        {
            if(_amisViewModel.SelectedPersonne != null)
            {
                _amisViewModel.NavigationViewModel.Page = NavigationCache.GetPage<AmiDetail, AmiDetailViewModel>(true, _amisViewModel.SelectedPersonne, _amisViewModel.NavigationViewModel);
            }
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            _amisViewModel.Filter(((TextBox)sender).Text);
        }

        private void Order(object sender, MouseButtonEventArgs e)
        {
            _amisViewModel.Order(((TextBlock)sender).Text);
        }
    }
}
