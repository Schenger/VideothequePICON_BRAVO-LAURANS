﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.Models
{
    public class Base : INotifyPropertyChanged
    {
        private Dictionary<string, object> propertyValues = new Dictionary<string, object>();
        public event PropertyChangedEventHandler PropertyChanged;

        public T GetValue<T>([CallerMemberName] string propertyName = null)
        {
            if (propertyValues.ContainsKey(propertyName))
            {
                return (T)propertyValues[propertyName];
            }
            return default(T);
        }

        public void SetValue<T>(T newValue, [CallerMemberName] string propertyName = null)
        {
            T currentValue = GetValue<T>(propertyName);
            if (!EqualityComparer<T>.Default.Equals(currentValue, newValue))
            {
                propertyValues[propertyName] = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
