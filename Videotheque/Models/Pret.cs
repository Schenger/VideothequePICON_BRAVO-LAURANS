using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.Models
{
    public class Pret : Base
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
        public DateTime DatePret
        {
            get { return GetValue<DateTime>(); }
            set { SetValue(value); }
        }
        public DateTime DateRetour
        {
            get { return GetValue<DateTime>(); }
            set { SetValue(value); }
        }
    }
}
