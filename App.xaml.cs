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

using System.Windows;

using SimpleMVVMUserControlDemo.Models;
using SimpleMVVMUserControlDemo.Utils.Diagnostics;
using SimpleMVVMUserControlDemo.ViewModels.Main;
using SimpleMVVMUserControlDemo.Views;

namespace SimpleMVVMUserControlDemo
{
    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App
    {
        private readonly MainVM _mainVM;

        /// <summary>
        /// Constructor (default).
        /// </summary>
        public App()
        {
            Logger.GetInstance().Start(Logger.OutputFormat.eANSIText, "Log", true);

            // ReSharper disable once PossibleNullReferenceException
            Logger.GetInstance().Log(new LogMessage(LogMessage.Severity.eInfo,
                LogMessage.LogMessageType.eSubCall,
                GetType().FullName, System.Reflection.MethodBase.GetCurrentMethod().Name));

            Parameters.GetInstance().Start("", true);

            _mainVM = new MainVM("User Control Demo using MVVM");

            // ReSharper disable once PossibleNullReferenceException
            Logger.GetInstance().Log(new LogMessage(LogMessage.Severity.eInfo,
                LogMessage.LogMessageType.eSubExit,
                GetType().FullName, System.Reflection.MethodBase.GetCurrentMethod().Name));
        }

        /// <summary>
        /// Handle OnExit event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            // ReSharper disable once PossibleNullReferenceException
            Logger.GetInstance().Log(new LogMessage(LogMessage.Severity.eInfo,
                LogMessage.LogMessageType.eSubCall,
                GetType().FullName, System.Reflection.MethodBase.GetCurrentMethod().Name));

            // ReSharper disable once PossibleNullReferenceException
            Logger.GetInstance().Log(new LogMessage(LogMessage.Severity.eInfo, 
                LogMessage.LogMessageType.eSubExit, 
                GetType().FullName, System.Reflection.MethodBase.GetCurrentMethod().Name));
        }

        /// <summary>
        /// Handle OnStartup event.
        /// </summary>
        /// <param name="e">StartupEventArs object.</param>
        protected override void OnStartup(StartupEventArgs e) 
        {
            base.OnStartup(e);

            // ReSharper disable once PossibleNullReferenceException
            Logger.GetInstance().Log(new LogMessage(LogMessage.Severity.eInfo, 
                LogMessage.LogMessageType.eSubCall, 
                GetType().FullName, System.Reflection.MethodBase.GetCurrentMethod().Name));

            MainWindow mainWindow = new MainWindow(_mainVM);

            mainWindow.Show();

            // ReSharper disable once PossibleNullReferenceException
            Logger.GetInstance().Log(new LogMessage(LogMessage.Severity.eInfo,
                LogMessage.LogMessageType.eSubExit,
                GetType().FullName, System.Reflection.MethodBase.GetCurrentMethod().Name));
        }
    }
}
