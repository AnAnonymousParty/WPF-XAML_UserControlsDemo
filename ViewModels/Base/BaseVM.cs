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

using System.ComponentModel;
using System.Diagnostics;
using System.Windows;

using SimpleMVVMUserControlDemo.Utils.Diagnostics;

namespace SimpleMVVMUserControlDemo.ViewModels.Base
{
    /// <summary>
    /// The basic View Model. 
    /// <br/>
    /// This base View Model implements the INotifyPropertyChanged interface to handle property change notifications
    /// needed for the MVVM framework. It is expected that all other View Models will be derived from this class.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static readonly bool _isInDesignMode;

        /// <summary>
        /// Constructor (static).
        /// </summary>
        static BaseViewModel()
        {
            var prop = DesignerProperties.IsInDesignModeProperty;

            _isInDesignMode
                    = (bool)DependencyPropertyDescriptor
                    .FromProperty(prop, typeof(FrameworkElement))
                    .Metadata.DefaultValue;
        }

        /// <summary>
        /// Handle the OnPropertyChanged event.
        /// </summary>
        /// <param name="propertyName">String contating the name of the property that triggered the event.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);

            PropertyChangedEventHandler handler = PropertyChanged;

            if (null == handler)
            {
                return;
            }

            var e = new PropertyChangedEventArgs(propertyName);

            handler(this, e);
        }

        /// <summary>
        /// Constructor (default).
        /// </summary>
        public BaseViewModel()
        {
        }

        /// <summary>
        /// Verify the the named property exists and log a warning message if it does not.
        /// </summary>
        /// <param name="propertyName">String containing the name of the property to be verified.</param>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real, 
            // public, instance property on this object. 

            if (null == TypeDescriptor.GetProperties(this)[propertyName])
            {
                // ReSharper disable once PossibleNullReferenceException
                Logger.GetInstance().Log(new LogMessage(LogMessage.Severity.eWarning,  
                    LogMessage.LogMessageType.eSubInfo, 
                    GetType().FullName, 
                    System.Reflection.MethodBase.GetCurrentMethod().Name,
                    "Attempt to access unrecognized property '" + propertyName + "' failed"));
            }
        }

        #region Public Properties

        public bool IsInDesignMode
        {
            get
            {
                return _isInDesignMode;
            }
        }

        #endregion
    }
}