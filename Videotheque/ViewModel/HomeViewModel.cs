using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Models;
using Videotheque.Services;

namespace Videotheque.ViewModel
{
    public class HomeViewModel : Base
    {
        public SeriesCollection Series { get { return GetValue<SeriesCollection>(); } set { SetValue<SeriesCollection>(value); } }
        private GenreService _genreService;

        public HomeViewModel()
        {
            _genreService = new GenreService();
            Refresh();
        }

        public void Refresh()
        {
            var data = _genreService.GetMediaParGenre();
            Series = new SeriesCollection();
            foreach (var d in data)
            {
                Series.Add(new PieSeries
                {
                    Title = d.NomGenre,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(d.NombreMedia) },
                    DataLabels = true
                });
            }
        }
    }
}
