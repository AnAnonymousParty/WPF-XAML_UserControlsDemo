/*
 * This file is part of WPF-XAML_UserControlsDemo.
 *
 * WPF-XAML_UserControlsDemo is free software: you can redistribute it and/or 
 * modify it under the terms of the GNU General Public License as published by 
 * the Free Software Foundation, either version 3 of the License, or (at your 
 * option) any later version.
 *
 * WPF-XAML_UserControlsDemo is distributed in the hope that it will be useful, 
 * but WITHOUT  ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
 * or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for 
 * more details.
 *
 * You should have received a copy of the GNU General Public License along with
 * WPF-XAML_UserControlsDemo. If not, see <https://www.gnu.org/licenses/>. 
 */ 

using System;
using System.Windows.Data;

namespace SimpleMVVMUserControlDemo.Utils.MVVM
{
    public class StyleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            System.Windows.FrameworkElement targetElement = values[0] as System.Windows.FrameworkElement;

            string styleName = values[1] as string;

            if (null == styleName)
            {
                return null;
            }

            System.Windows.Style newStyle = (System.Windows.Style)targetElement.TryFindResource(styleName);

            if (null == newStyle)
            {
                newStyle = (System.Windows.Style)targetElement.TryFindResource("MyDefaultStyleName"); // TODO: find a default style anyway.
            }

            return newStyle;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
