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
    /// Logique d'interaction pour AddAmi.xaml
    /// </summary>
    public partial class AddAmi : Page
    {
        private AddAmiViewModel _addAmiViewModel;


        public AddAmi()
        {
            InitializeComponent();
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await _addAmiViewModel.Add();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _addAmiViewModel = DataContext as AddAmiViewModel;
        }
    }
}
