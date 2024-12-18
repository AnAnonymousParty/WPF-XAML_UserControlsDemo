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
using System.Windows.Media;
using SimpleMVVMUserControlDemo.Models;
using SimpleMVVMUserControlDemo.Utils.Diagnostics;
using SimpleMVVMUserControlDemo.ViewModels.Base;


namespace SimpleMVVMUserControlDemo.ViewModels.Main
{
    /// <summary>
    /// View Model for the Main Screen.
    /// </summary>
    public class MainVM : BaseViewModel
    {
        private bool _js1AutoCenter;
        private bool _js2AutoCenter;

        private Brush _controlTitleBrush = Brushes.Cyan;

        private Double _js1XPos;
        private Double _js1YPos;
        private Double _js2XPos;
        private Double _js2YPos;
        private Double _knob1Pos;
        private Double _rotaryControlTitleFontSize;

        private String _control1TitleText = "Control 1";
        private String _headingText = "Default Heading";
        private String _js1XPosDisp = "";
        private String _js1YPosDisp = "";
        private String _js2XPosDisp = "";
        private String _js2YPosDisp = "";
        private String _knob1PosDisp = "";
        private String _section1TitleText = "Section 1";
        private String _section2TitleText = "Section 2";
        private String _section3TitleText = "Section 3";

        /// <summary>
        /// Constructor (default).
        /// </summary>
        public MainVM()
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
        /// Constructor, given heading and Parameters.
        /// 
        /// @param [IN] headingText String containing the heading text to be displayed.
        /// </summary>
        public MainVM(String headingText)
        {
            // ReSharper disable once PossibleNullReferenceException
            Logger.GetInstance().Log(new LogMessage(LogMessage.Severity.eDebug,
                        LogMessage.LogMessageType.eSubCall,
                        GetType().FullName, System.Reflection.MethodBase.GetCurrentMethod().Name,
                        "", headingText));

            _headingText = headingText;

            Init();

            // ReSharper disable once PossibleNullReferenceException
            Logger.GetInstance().Log(new LogMessage(LogMessage.Severity.eDebug,
                        LogMessage.LogMessageType.eSubExit,
                        GetType().FullName, System.Reflection.MethodBase.GetCurrentMethod().Name));
        }

        #region Public Properties

        public Brush ControlLegendBrush
        {
            get { return _controlTitleBrush; }
            set
            {
                _controlTitleBrush = value;
                OnPropertyChanged("ControlLegendBrush");
            }
        }

        public Double ControlLegendFontSize
        {
            get { return _rotaryControlTitleFontSize; }
            set
            {
                _rotaryControlTitleFontSize = value;
                OnPropertyChanged("ControlLegendFontSize");
            }
        }

        public String Control1LegendText
        {
            get { return _control1TitleText; }
            set
            {
                _control1TitleText = value;
                OnPropertyChanged("Control1LegendText");
            }
        }

        public bool JS1AutoCenter
        {
            get { return _js1AutoCenter;  }
            set
            {
                _js1AutoCenter = value;
                OnPropertyChanged("JS1AutoCenter");
            }
        }

        public bool JS2AutoCenter
        {
            get { return _js2AutoCenter; }
            set
            {
                _js2AutoCenter = value;
                OnPropertyChanged("JS2AutoCenter");
            }
        }

        public String HeadingText
        {
            get { return _headingText; }
            set
            {
                _headingText = value;
                OnPropertyChanged("HeadingText");
            }
        }

        public Double JS1XPos
        {
            get { return _js1XPos; }
            set
            {
                _js1XPos = value;
                OnPropertyChanged("JS1XPos");

                JS1XPosDisp = String.Format("{0:0.00}", _js1XPos);
            }
        }

        public Double JS1YPos
        {
            get { return _js1YPos; }
            set
            {
                _js1YPos = value;
                OnPropertyChanged("JS1YPos");

                JS1YPosDisp = String.Format("{0:0.00}" ,_js1YPos);
            }
        }

        public Double JS2XPos
        {
            get { return _js2XPos; }
            set
            {
                _js2XPos = value;
                OnPropertyChanged("JS2XPos");

                JS2XPosDisp = String.Format("{0:0.00}", _js2XPos);
            }
        }

        public Double JS2YPos
        {
            get { return _js2YPos; }
            set
            {
                _js2YPos = value;
                OnPropertyChanged("JS2YPos");

                JS2YPosDisp = String.Format("{0:0.00}", _js2YPos);
            }
        }

        public String JS1XPosDisp
        {
            get { return _js1XPosDisp; }
            set
            {
                _js1XPosDisp = value;
                OnPropertyChanged("JS1XPosDisp");
            }
        }

        public String JS1YPosDisp
        {
            get { return _js1YPosDisp; }
            set
            {
                _js1YPosDisp = value;
                OnPropertyChanged("JS1YPosDisp");
            }
        }

        public String JS2XPosDisp
        {
            get { return _js2XPosDisp; }
            set
            {
                _js2XPosDisp = value;
                OnPropertyChanged("JS2XPosDisp");
            }
        }

        public String JS2YPosDisp
        {
            get { return _js2YPosDisp; }
            set
            {
                _js2YPosDisp = value;
                OnPropertyChanged("JS2YPosDisp");
            }
        }

        public Double Knob1Pos
        {
            get { return _knob1Pos; }
            set
            {
                _knob1Pos = value;
                OnPropertyChanged("Knob1Pos");

                Knob1PosDisp = String.Format("{0:0.00}", _knob1Pos);
            }
        }

        public String Knob1PosDisp
        {
            get { return _knob1PosDisp; }
            set
            {
                _knob1PosDisp = value;
                OnPropertyChanged("Knob1PosDisp");
            }
        }

        public String Section1TitleText
        {
            get { return _section1TitleText; }
            set
            {
                _section1TitleText = value;
                OnPropertyChanged("Section1TitleText");
            }
        }

        public String Section2TitleText
        {
            get { return _section2TitleText; }
            set
            {
                _section2TitleText = value;
                OnPropertyChanged("Section2TitleText");
            }
        }

        public String Section3TitleText
        {
            get { return _section3TitleText; }
            set
            {
                _section3TitleText = value;
                OnPropertyChanged("Section3TitleText");
            }
        }

        #endregion

        /// <summary>
        /// Initialize the View Model.
        /// </summary>
        private void Init()
        {
            _js1AutoCenter = false;
            _js2AutoCenter = true;

            _js1XPos = Parameters.GetInstance().JS1XVal;
            _js1YPos = Parameters.GetInstance().JS1YVal;
            _js2XPos = Parameters.GetInstance().JS2XVal;
            _js2YPos = Parameters.GetInstance().JS2YVal;
            _knob1Pos = Parameters.GetInstance().Ctrl1Val;

            _js1XPosDisp = String.Format("{0:0.00}", _js1XPos);
            _js1YPosDisp = String.Format("{0:0.00}", _js1YPos);
            _js2XPosDisp = String.Format("{0:0.00}", _js2XPos);
            _js2YPosDisp = String.Format("{0:0.00}", _js2YPos);
            _knob1PosDisp = String.Format("{0:0.00}", _knob1Pos);
            _rotaryControlTitleFontSize = 14.0;
        }
    }
}