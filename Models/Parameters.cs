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

namespace SimpleMVVMUserControlDemo.Models
{
    /// <summary>
    /// This container class serves as the data model for the Main View Model.
    /// </summary>
    public class Parameters
    {
        private static Random randomizer;

        private static readonly object _lock = new object();

        private static Parameters _instance = null;

        private bool _randomize = false;

        private Double _ctl1Val;
        private Double _ctl2Val;
        private Double _js1XVal;
        private Double _js1YVal;
        private Double _js2XVal;
        private Double _js2YVal;
       
        private String _defaultParmsPathFile;
        private String _sec1Title;
        private String _sec2Title;

        private Parameters()
        {
        }

        /// <summary>
        /// Obtain a reference to the singleton instance of this class.
        /// </summary>
        /// <returns>The sole instance of this class.</returns>
        public static Parameters GetInstance()
        {
            if (null == _instance)
            {
                lock (_lock)
                {
                    if (null == _instance)
                    {
                        _instance = new Parameters();
                    }
                }
            }

            return _instance;
        }

        /// <summary>
        /// Start the logger.
        /// </summary>
        /// <param name="defaultParmsPathFile">String containing the pathe and name of the log file.</param>
        /// <param name="randomize">true = randomize the default values if no path/file name exists.</param>
        public void Start(String defaultParmsPathFile, bool randomize)
        {
            _defaultParmsPathFile = defaultParmsPathFile;
            _randomize = randomize;

            Init();
        }

        /// <summary>
        /// Initialize the parameters, either by the values contained in an external file, or via
        /// defaults or randomized values.
        /// </summary>
        private void Init()
        {
            if (!string.IsNullOrEmpty(_defaultParmsPathFile))
            {
                LoadParmsFromFile();

                return;
            }

            _ctl1Val =
            _ctl2Val =
            _js1XVal =
            _js1YVal =
            _js2XVal =
            _js2YVal = 0.0;

            _sec1Title = "Section 1";
            _sec2Title = "Section 2";

            if (true == _randomize)
            {
                randomizer = new Random();

                if (randomizer != null)
                {
                    _ctl1Val = (uint)randomizer.Next(100);
                    _ctl2Val = (uint)randomizer.Next(100);
                    _js1XVal = (uint)randomizer.Next(100);
                    _js1YVal = (uint)randomizer.Next(100);
                    _js2XVal = (uint)randomizer.Next(100);
                    _js2YVal = (uint)randomizer.Next(100);
                }
            }            
        }

        /// <summary>
        /// Open, load and parse the XML file containing all of the parameters used by the application.
        /// </summary>
        private void LoadParmsFromFile()
        {

        }

        #region Public Properties

        public Double Ctrl1Val
        {
            get { return _ctl1Val; }
            set { _ctl1Val = value; }
        }

        public Double Ctrl2Val
        {
            get { return _ctl2Val; }
            set { _ctl2Val = value; }
        }

        public Double JS1XVal
        {
            get { return _js1XVal; }
            set { _js1XVal = value; }
        }

        public Double JS1YVal
        {
            get { return _js1YVal; }
            set { _js1YVal = value; }
        }

        public Double JS2XVal
        {
            get { return _js2XVal; }
            set { _js2XVal = value; }
        }

        public Double JS2YVal
        {
            get { return _js2YVal; }
            set { _js2YVal = value; }
        }

        public String Sec1Title
        {
            get { return _sec1Title; }
            set { _sec1Title = value;  }
        }

        public String Sec2Title
        {
            get { return _sec2Title; }
            set { _sec2Title = value; }
        }

        #endregion
    }
}
