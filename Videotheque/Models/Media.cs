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
    public abstract class Media : Base
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        public string Titre
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public StatutMedia Statut
        {
            get { return GetValue<StatutMedia>(); }
            set { SetValue(value); }
        }
        public DateTime DateCreation
        {
            get { return GetValue<DateTime>(); }
            set { SetValue(value); }
        }
        public int Note
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        public string Commentaire
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string Synopsis
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public int AgeMinimum
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        public Langue LangueVO
        {
            get { return GetValue<Langue>(); }
            set { SetValue(value); }
        }
        public Langue LangueMedia
        {
            get { return GetValue<Langue>(); }
            set { SetValue(value); }
        }
        public Langue SousTitre
        {
            get { return GetValue<Langue>(); }
            set { SetValue(value); }
        }
        public bool AudioDescription
        {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }
        public bool SupportPhysique
        {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }
        public bool SupportNumerique
        {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }
        public byte[] Photo
        {
            get { return GetValue<byte[]>(); }
            set { SetValue(value); }
        }
        [InverseProperty(nameof(Videotheque.Models.Pret.Media))]
        public Pret Pret
        {
            get { return GetValue<Pret>(); }
            set { SetValue(value); }
        }
        [InverseProperty(nameof(MediaGenre.Media))]
        public List<MediaGenre> MediaGenres
        {
            get { return GetValue<List<MediaGenre>>(); }
            set { SetValue(value); }
        }
        [InverseProperty(nameof(MediaPersonne.Media))]
        public List<MediaPersonne> MediaPersonnes
        {
            get { return GetValue<List<MediaPersonne>>(); }
            set { SetValue(value); }
        }

    }
}
