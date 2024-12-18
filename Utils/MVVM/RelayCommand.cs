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
using System.Windows.Input;

namespace SimpleMVVMUserControlDemo.Utils.MVVM
{
    /// <summary>
    /// Class that provides command handling from UI elements contained in a View.
    /// </summary>
    class RelayCommand : ICommand
    {
        #region Public Members.
        
        /// <summary>
        /// Constructor, given action object.
        /// </summary>
        /// <param name="action">Action object to be called on command invocation.</param>
        public RelayCommand(Action<object> action)
        {
            _action = action;
        }

        /// <summary>
        /// Constructor, given action and predicate objects.
        /// </summary>
        /// <param name="action">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<object> action, Predicate<object> canExecute)
        {
            if (null == action)
            {
                throw new ArgumentNullException("RelayCommand(Action, Predicate) action");
            }
            
            _action     = action;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Determine if command can be executed.
        /// </summary>
        /// <param [IN] name="parameter"></param>
        /// <returns>
        /// true  = command can be executed.
        /// false = command cannot be executed.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add 
            { 
                CommandManager.RequerySuggested += value; 
            }

            remove 
            {
                CommandManager.RequerySuggested -= value; 
            }
        }

        /// <summary>
        /// Execute command.
        /// </summary>
        /// <param name="parameter">
        /// Object containing function to be executed.
        /// </param>
        public void Execute(object parameter)
        {
            _action(parameter);
        }

        #endregion

        #region Private members.
        private readonly Action<object>    _action;
        private readonly Predicate<object> _canExecute;
        #endregion
    }
}
