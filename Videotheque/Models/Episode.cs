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
    public class Episode : Base
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
        public TimeSpan Duree
        {
            get { return GetValue<TimeSpan>(); }
            set { SetValue(value); }
        }
        public int Numero
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
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
        public DateTime DateSortie
        {
            get { return GetValue<DateTime>(); }
            set { SetValue(value); }
        }
        public int Saison
        {
            get { return GetValue<int>(); }
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
        public StatutMedia Statut
        {
            get { return GetValue<StatutMedia>(); }
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
    }
}
