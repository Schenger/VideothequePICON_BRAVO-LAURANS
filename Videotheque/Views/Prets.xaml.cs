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

namespace Videotheque.Views
{
    /// <summary>
    /// Logique d'interaction pour Prets.xaml
    /// </summary>
    public partial class Prets : Page
    {
        private PretsViewModel _pretsViewModel;

        public Prets()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _pretsViewModel = DataContext as PretsViewModel;
            _pretsViewModel.Setup();
        }

        private void Preter(object sender, RoutedEventArgs e)
        {
            _pretsViewModel.Preter();
        }

        private void Rendre(object sender, RoutedEventArgs e)
        {
            _pretsViewModel.Rendre();
        }
    }
}
