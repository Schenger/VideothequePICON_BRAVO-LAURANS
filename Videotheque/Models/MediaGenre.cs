using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.Models
{
    public class MediaGenre : Base
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
        public int IdGenre
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        [ForeignKey(nameof(IdGenre))]
        public Genre Genre
        {
            get { return GetValue<Genre>(); }
            set { SetValue(value); }
        }
    }
}
