using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Models.Enums;

namespace Videotheque.Models
{
    public class Personne : Base
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        public string Nom
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string Prenom
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public bool EstAmi
        {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }
        public Langue Nationalite
        {
            get { return GetValue<Langue>(); }
            set { SetValue(value); }
        }
        public Civilite Civilite
        {
            get { return GetValue<Civilite>(); }
            set { SetValue(value); }
        }
        public byte[] Photo
        {
            get { return GetValue<byte[]>(); }
            set { SetValue(value); }
        }

        public override string ToString()
        {
            return Prenom + " " + Nom;
        }
    }
}
