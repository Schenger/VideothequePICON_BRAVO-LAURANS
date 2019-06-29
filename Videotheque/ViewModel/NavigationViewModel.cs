using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Videotheque.Models;

namespace Videotheque.ViewModel
{
    public class NavigationViewModel : Base
    {
        public Page Page
        {
            get
            {
                return GetValue<Page>();
            }
            set
            {
                SetValue<Page>(value);
            }
        }
    }
}
