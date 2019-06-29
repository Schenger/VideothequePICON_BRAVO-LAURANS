using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.Tools
{
    public class EnumUtils
    {
        public static object GetEnumValueWithString(string value)
        {
            int index = Array.IndexOf(Enum.GetValues(value.GetType()), value);
            return Enum.GetValues(value.GetType()).GetValue(index);
        }
    }
}
