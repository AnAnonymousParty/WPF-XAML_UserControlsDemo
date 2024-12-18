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
using System.Collections.Generic;
using System.ComponentModel;

namespace SimpleMVVMUserControlDemo.ViewModels.Base
{
    /// <summary>
    /// Helper functions for the base VM.
    /// </summary>
    public static class BaseVMHelpers
    {
        public static void Each<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }

        public static string StripLeft(this string value, int length)
        {
            return value.Substring(length, value.Length - length);
        }

        public static void Raise(this PropertyChangedEventHandler eventHandler, object source, string propertyName)
        {
            var handlers = eventHandler;

            if (null != handlers)
            {
                handlers(source, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static void Raise(this EventHandler eventHandler, object source)
        {
            var handlers = eventHandler;

            if (null != handlers)
            {
                handlers(source, EventArgs.Empty);
            }
        }

        public static void Register(this INotifyPropertyChanged model, string propertyName, Action whenChanged)
        {
            model.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == propertyName)
                {
                    whenChanged();
                }
            };
        }
    }
}
