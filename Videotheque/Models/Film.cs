using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.Models
{
    public class Film : Media, IComparable
    {
        public TimeSpan Duree
        {
            get { return GetValue<TimeSpan>(); }
            set { SetValue(value); }
        }

        [NotMapped]
        public Genre Genre
        {
            get
            {
                return GetValue<Genre>();
            }
            set
            {
                SetValue(value);
            }
        }

        [NotMapped]
        public Personne Personne
        {
            get
            {
                return GetValue<Personne>();
            }
            set
            {
                SetValue(value);
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Film otherFilm = obj as Film;
            if (otherFilm != null)
            {
                return this.Titre.CompareTo(otherFilm.Titre);
            }
            else
            {
                throw new ArgumentException("Object is not a Film");
            }
        }

        public override string ToString()
        {
            return Titre;
        }
    }
}
