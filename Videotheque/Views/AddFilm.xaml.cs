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
using System.Text.RegularExpressions;


namespace Videotheque.Views
{
    /// <summary>
    /// Logique d'interaction pour AddFilm.xaml
    /// </summary>
    public partial class AddFilm : Page
    {
        private AddFilmViewModel _addFilmViewModel;

        public AddFilm()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await _addFilmViewModel.Add();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _addFilmViewModel = DataContext as AddFilmViewModel;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
