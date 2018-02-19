﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace WorkingWithTriggers.Converters
{
    /// <summary>
    /// Converts an Entry's Text.Length into a 'flag'
    ///  * Entry is empty, returns 1
    /// 
    /// </summary>
    public class MultiTriggerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if ((int)value > 0)
                return true;    // data has been entered
            else
                return false;   // input is empty
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}