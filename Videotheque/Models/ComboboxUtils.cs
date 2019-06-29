﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.Models
{
    public class ComboboxUtils
    {
        public object ValueEnum { get; set; }
        public string ValueString { get; set; }

        public static List<ComboboxUtils> init(Enum e)
        {
            List<ComboboxUtils> list = new List<ComboboxUtils>();
            Array enumValues = Enum.GetValues(e.GetType());
            foreach (object o in enumValues)
            {
                list.Add(new ComboboxUtils() { ValueEnum = o, ValueString = o.ToString() });
            }
            return list;
        }

        public override string ToString()
        {
            return ValueString;
        }
    }
}
