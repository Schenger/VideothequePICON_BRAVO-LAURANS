using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.Models
{
    public class MediaPersonne : Base
    {
        public int IdMedia
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        [ForeignKey(nameof(IdMedia))]
        public Media Media
        {
            get { return GetValue<Media>(); }
            set { SetValue(value); }
        }
        public int IdPersonne
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        [ForeignKey(nameof(IdPersonne))]
        public Personne Personne
        {
            get { return GetValue<Personne>(); }
            set { SetValue(value); }
        }
        public string Fonction
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string Role
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}
