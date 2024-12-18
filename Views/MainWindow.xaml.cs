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

using SimpleMVVMUserControlDemo.Utils.Diagnostics;
using SimpleMVVMUserControlDemo.ViewModels.Main;


namespace SimpleMVVMUserControlDemo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow
    {
        private readonly MainVM _mainVM;

        /// <summary>
        /// Constructor (default).
        /// </summary>
        public MainWindow()
        {
            // ReSharper disable once PossibleNullReferenceException
            Logger.GetInstance().Log(new LogMessage(LogMessage.Severity.eDebug,
                        LogMessage.LogMessageType.eSubCall,
                        GetType().FullName, System.Reflection.MethodBase.GetCurrentMethod().Name)); 
            Init();

            // ReSharper disable once PossibleNullReferenceException
            Logger.GetInstance().Log(new LogMessage(LogMessage.Severity.eDebug,
                        LogMessage.LogMessageType.eSubExit,
                        GetType().FullName, System.Reflection.MethodBase.GetCurrentMethod().Name));
        }

        /// <summary>
        /// Constructor (default).
        /// </summary>
        public MainWindow(MainVM mainVM)
        {
            if (false == DesignMode)
            {
                // ReSharper disable once PossibleNullReferenceException
                Logger.GetInstance().Log(new LogMessage(LogMessage.Severity.eDebug,
                            LogMessage.LogMessageType.eSubCall,
                            GetType().FullName, System.Reflection.MethodBase.GetCurrentMethod().Name,
                            "", mainVM.HeadingText));
             }

            _mainVM = mainVM;

            Init();

            if (false == DesignMode)
            {
                // ReSharper disable once PossibleNullReferenceException
                Logger.GetInstance().Log(new LogMessage(LogMessage.Severity.eDebug,
                    LogMessage.LogMessageType.eSubExit,
                    GetType().FullName, System.Reflection.MethodBase.GetCurrentMethod().Name));
            }
        }

        #region Public Properties

        /// <summary>
        /// Indicate whether the program is running in design mode.
        /// Usage of this property is mainly to avoid warnings in the XAML designer.
        /// </summary>
        public bool DesignMode
        {
            get
            {
                return (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            }
        }

        public MainVM MainVM
        {
            get { return _mainVM; }
        }

        #endregion

        /// <summary>
        /// Initialize the View.
        /// </summary>
        private void Init()
        {
            DataContext = _mainVM;

            InitializeComponent();
        }
    }
}
