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

/*
+========================================================================================================================+
|                                                       DEPENDENCY PROPERTIES                                            |
+==========================+==========+==================================================================================+
|          NAME            |   TYPE   |                                   DESCRIPTION                                    |
+==========================+==========+==================================================================================+
| DesignMode	              | bool     | Indicates whether the the code is running in the Visual Studio.                  |
+--------------------------+----------+----------------------------------------------------------------------------------+
| JSAutoCenter             | bool     | Controls whether the joystick knob returns to the center position when released. |
+--------------------------+----------+----------------------------------------------------------------------------------+
| JSXPos                   | double   | Current Joystick X position.                                                     |
+--------------------------+----------+----------------------------------------------------------------------------------+
| JSXPosDisp               | String   | Current Joystick X position.                                                     |
+--------------------------+----------+----------------------------------------------------------------------------------+
| JSYPos                   | double   | Current Joystick Y position.                                                     |
+--------------------------+----------+----------------------------------------------------------------------------------+
| JSYPosDisp               | String   | Current Joystick Y position.                                                     |
+--------------------------+----------+----------------------------------------------------------------------------------+
| LegendBrush              | Brush    | Color used to display the legend text.                                           |
+--------------------------+----------+----------------------------------------------------------------------------------+
| LegendFontSize           | double   | Size of the font used to display the legend text.                                |
+--------------------------+----------+----------------------------------------------------------------------------------+
| SectionEnabled           | bool     | Determines whether the control in the section are enabled.                       |
+--------------------------+----------+----------------------------------------------------------------------------------+
| SectionTitleText         | String   | Text displayed in the section title (styled GroupBox).                           |
+--------------------------+----------+----------------------------------------------------------------------------------+
| SwitchLegendText         | String   | Text displayed below the toggle switch.                                          |
+--------------------------+----------+----------------------------------------------------------------------------------+
| SwitchOffColor           | LEDColor | Color of the LED when the toggle switch is in the off state.                     |
+--------------------------+----------+----------------------------------------------------------------------------------+
| SwitchOnColor            | LEDColor | Color of the LED when the toggle switch is in the on state.                      |
+--------------------------+----------+----------------------------------------------------------------------------------+
| SwitchSize               | double   | Size of the toggle switch (Height = Width).                                      |
+==========================+==========+==================================================================================+
 */

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

using JoystickControl;
using SimpleMVVMUserControlDemo.Utils.Diagnostics;
using ToggleSwitchControl.Enums;

namespace SimpleMVVMUserControlDemo.UserControls.SectionJS
{
    /// <summary>
    /// Interaction logic for SectionJS.xaml.
    /// </summary>
    public partial class SectionJS
    {
        /// <summary>
        /// Constructor (default).
        /// </summary>
        public SectionJS()
        {
            if (false == DesignMode)
            {
                // ReSharper disable once PossibleNullReferenceException
                Logger.GetInstance().Log(new LogMessage(LogMessage.Severity.eDebug,
                    LogMessage.LogMessageType.eSubCall,
                    GetType().FullName, System.Reflection.MethodBase.GetCurrentMethod().Name));
            }

            InitializeComponent();

            var joystickControl = FindName("TranslationStick") as Joystick;

            if (null != joystickControl)
            {
                joystickControl.Moved += Joystick_Moved;
            }

            if (false == DesignMode)
            {
                // ReSharper disable once PossibleNullReferenceException
                Logger.GetInstance().Log(new LogMessage(LogMessage.Severity.eDebug,
                    LogMessage.LogMessageType.eSubExit,
                    GetType().FullName, System.Reflection.MethodBase.GetCurrentMethod().Name));
            }
        }

        #region Dependency Properties

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

        public bool JSAutoCenter
        {
            get { return (bool)GetValue(JSAutoCenterProperty); }
            set { SetValue(JSAutoCenterProperty, value); }
        }

        public static readonly DependencyProperty JSAutoCenterProperty = DependencyProperty.Register("JSAutoCenter", 
                                                                                                     typeof(bool),
                                                                                                     typeof(SectionJS), 
                                                                                                     new PropertyMetadata(false));
        public Double JSXPos
        {
            get { return (Double)GetValue(JSXPosProperty); }
            set { SetValue(JSXPosProperty, value); }
        }

        public static readonly DependencyProperty JSXPosProperty = DependencyProperty.Register("JSXPos", 
                                                                                               typeof(Double),
                                                                                               typeof(SectionJS), 
                                                                                               new PropertyMetadata(0.0));
        public String JSXPosDisp
        {
            get { return (String)GetValue(JSXPosDispProperty); }
            set { SetValue(JSXPosDispProperty, value); }
        }

        public static readonly DependencyProperty JSXPosDispProperty = DependencyProperty.Register("JSXPosDisp", 
                                                                                                   typeof(String),
                                                                                                   typeof(SectionJS), 
                                                                                                   new PropertyMetadata());
        public Double JSYPos
        {
            get { return (Double)GetValue(JSYPosProperty); }
            set { SetValue(JSYPosProperty, value); }
        }

        public static readonly DependencyProperty JSYPosProperty = DependencyProperty.Register("JSYPos",
                                                                                               typeof(Double),
                                                                                               typeof(SectionJS), 
                                                                                               new PropertyMetadata(0.0));
        public String JSYPosDisp        
        {
            get { return (String)GetValue(JSYPosDispProperty); }
            set { SetValue(JSYPosDispProperty, value); }
        }

        public static readonly DependencyProperty JSYPosDispProperty = DependencyProperty.Register("JSYPosDisp",
                                                                                                   typeof(string),
                                                                                                   typeof(SectionJS), 
                                                                                                   new PropertyMetadata(""));
        public Brush LegendBrush
        {
            get { return (Brush)GetValue(LegendBrushProperty); }
            set { SetValue(LegendBrushProperty, value); }
        }

        public static readonly DependencyProperty LegendBrushProperty = DependencyProperty.Register("LegendBrush", 
                                                                                                    typeof(Brush),
                                                                                                    typeof(SectionJS), 
                                                                                                    new PropertyMetadata(Brushes.Gray));
        public Double LegendFontSize
        {
            get { return (Double)GetValue(LegendFontSizeProperty); }
            set { SetValue(LegendFontSizeProperty, value); }
        }

        public static readonly DependencyProperty LegendFontSizeProperty = DependencyProperty.Register("LegendFontSize", 
                                                                                                       typeof(Double),
                                                                                                       typeof(SectionJS), 
                                                                                                       new PropertyMetadata(10.0));
        public bool SectionEnabled
        {
            get { return (bool)GetValue(SectionEnabledProperty); }
            set { SetValue(SectionEnabledProperty, value); }
        }

        public static readonly DependencyProperty SectionEnabledProperty = DependencyProperty.Register("SectionEnabled",
                                                                                                       typeof(bool),
                                                                                                       typeof(SectionJS),
                                                                                                       new PropertyMetadata(false));
        public String SectionTitleText
        {
            get { return (String)GetValue(SectionTitleTextProperty); }
            set { SetValue(SectionTitleTextProperty, value); }
        }

        public static readonly DependencyProperty SectionTitleTextProperty = DependencyProperty.Register("SectionTitleText", 
                                                                                                         typeof(string),
                                                                                                         typeof(SectionJS), 
                                                                                                         new PropertyMetadata(""));
        public String SwitchLegendText
        {
            get { return (String)GetValue(SwitchLegendTextProperty); }
            set { SetValue(SwitchLegendTextProperty, value); }
        }

        public static readonly DependencyProperty SwitchLegendTextProperty = DependencyProperty.Register("SwitchLegend",
                                                                                                         typeof(string),
                                                                                                         typeof(SectionJS),
                                                                                                         new PropertyMetadata(""));
        public LEDColor SwitchOffColor
        {
            get { return (LEDColor)GetValue(SwitchOffColorProperty); }
            set { SetValue(SwitchOffColorProperty, value); }
        }

        public static readonly DependencyProperty SwitchOffColorProperty = DependencyProperty.Register("SwitchOffColor",
                                                                                                         typeof(LEDColor),
                                                                                                         typeof(SectionJS),
                                                                                                         new PropertyMetadata(LEDColor.eLEDRed));
        public LEDColor SwitchOnColor
        {
            get { return (LEDColor)GetValue(SwitchOnColorProperty); }
            set { SetValue(SwitchOnColorProperty, value); }
        }

        public static readonly DependencyProperty SwitchOnColorProperty = DependencyProperty.Register("SwitchOnColor",
                                                                                                        typeof(LEDColor),
                                                                                                        typeof(SectionJS),
                                                                                                        new PropertyMetadata(LEDColor.eLEDGreen));
        public double SwitchSize
        {
            get { return (double)GetValue(SwitchSizeProperty); }
            set { SetValue(SwitchSizeProperty, value); }
        }

        public static readonly DependencyProperty SwitchSizeProperty = DependencyProperty.Register("SwitchSize",
                                                                                                   typeof(double),
                                                                                                   typeof(SectionJS),
                                                                                                   new PropertyMetadata(64.0));
        #endregion


        /// <summary>
        /// Joystick moved event handler.
        /// </summary>
        /// <param name="sender">UI element triggering the event (unused)</param>
        /// <param name="args">Event arguments (joystick X/Y coordinates).</param>
        private void Joystick_Moved(object sender, JoystickEventArgs args)
        {
            JSXPos = args.X;
            JSYPos = args.Y;
        }
    }
}
