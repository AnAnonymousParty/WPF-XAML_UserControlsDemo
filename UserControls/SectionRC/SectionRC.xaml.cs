﻿/*
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
+=======================================================================================================+
|                                       DEPENDENCY PROPERTIES                                           |
+==========================+==========+=================================================================+
|          NAME            |   TYPE   |                        DESCRIPTION                              |
+==========================+==========+=================================================================+
| ControlLegendText        | String   | Sets the text displayed below the RotaryControl.                |
+--------------------------+----------+-----------------------------------------------------------------+
| DesignMode	              | bool     | Indicates whether the the code is running in the Visual Studio. |
+--------------------------+----------+-----------------------------------------------------------------+
| KnobPos                  | double   | Position of the Rotary Control knob.                            |
+--------------------------+----------+-----------------------------------------------------------------+
| KnobPosDisp              | String   | Position of the Rotary Control knob.                            |
+--------------------------+----------+-----------------------------------------------------------------+
| LegendBrush              | Brush    | Color used to display the legend text.                          |
+--------------------------+----------+-----------------------------------------------------------------+
| LegendFontSize           | double   | Size of the font used to display the legend text.               |
+--------------------------+----------+-----------------------------------------------------------------+
| SectionEnabled           | bool     | Determines whether the control in the section are enabled.      |
+--------------------------+----------+-----------------------------------------------------------------+
| SectionTitleText         | String   | Text displayed in the section title (styled GroupBox).          |
+--------------------------+----------+-----------------------------------------------------------------+
| SwitchLegendText         | String   | Text displayed below the toggle switch.                         |
+--------------------------+----------+-----------------------------------------------------------------+
| SwitchOffColor           | LEDColor | Color of the LED when the toggle switch is in the off state.    |
+--------------------------+----------+-----------------------------------------------------------------+
| SwitchOnColor            | LEDColor | Color of the LED when the toggle switch is in the on state.     |
+--------------------------+----------+-----------------------------------------------------------------+
| SwitchSize               | double   | Size of the toggle switch (Height = Width).                     |
+==========================+==========+=================================================================+
 */

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

using SimpleMVVMUserControlDemo.Utils.Diagnostics;
using ToggleSwitchControl.Enums;

namespace SimpleMVVMUserControlDemo.UserControls.SectionRC
{
    /// <summary>
    /// Interaction logic for SectionRC.xaml.
    /// </summary>
    public partial class SectionRC
    {
        /// <summary>
        /// Constructor (default).
        /// </summary>
        public SectionRC()
        {
            if (false == DesignMode)
            {
                // ReSharper disable once PossibleNullReferenceException
                Logger.GetInstance().Log(new LogMessage(LogMessage.Severity.eDebug,
                    LogMessage.LogMessageType.eSubCall,
                    GetType().FullName, System.Reflection.MethodBase.GetCurrentMethod().Name));
            }

            InitializeComponent();

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
        /// The text displayed below the control.
        /// </summary>
        public String ControlLegendText
        {
            get { return (String)GetValue(ControlLegendTextProperty); }
            set { SetValue(ControlLegendTextProperty, value); }
        }

        public static readonly DependencyProperty ControlLegendTextProperty = DependencyProperty.Register("ControlLegendText",
                                                                                                          typeof(String),
                                                                                                          typeof(SectionRC),
                                                                                                          new PropertyMetadata(""));
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

        public Double KnobPos
        {
            get { return (Double)GetValue(KnobPosProperty); }
            set { SetValue(KnobPosProperty, value); }
        }

        public static readonly DependencyProperty KnobPosProperty = DependencyProperty.Register("KnobPos", 
                                                                                                typeof(Double),
                                                                                                typeof(SectionRC), 
                                                                                                new PropertyMetadata(0.0));
        public String KnobPosDisp
        {
            get { return (String)GetValue(KnobPosDispProperty); }
            set { SetValue(KnobPosDispProperty, value); }
        }

        public static readonly DependencyProperty KnobPosDispProperty = DependencyProperty.Register("KnobPosDisp", 
                                                                                                    typeof(String),
                                                                                                    typeof(SectionRC), 
                                                                                                    new PropertyMetadata(""));
        public Brush LegendBrush
        {
            get { return (Brush)GetValue(LegendBrushProperty); }
            set { SetValue(LegendBrushProperty, value); }
        }

        public static readonly DependencyProperty LegendBrushProperty = DependencyProperty.Register("LegendBrush", 
                                                                                                    typeof(Brush),
                                                                                                    typeof(SectionRC), 
                                                                                                    new PropertyMetadata(Brushes.Gray));
        public Double LegendFontSize
        {
            get { return (Double)GetValue(LegendFontSizeProperty); }
            set { SetValue(LegendFontSizeProperty, value); }
        }

        public static readonly DependencyProperty LegendFontSizeProperty = DependencyProperty.Register("LegendFontSize", 
                                                                                                       typeof(Double),
                                                                                                       typeof(SectionRC), 
                                                                                                       new PropertyMetadata(10.0));
        /// <summary>
        /// The section enable toggles the display of all the control indicators in the section to reflect
        /// whether the associated controls are active.
        /// </summary>
        public bool SectionEnabled
        {
            get { return (bool)GetValue(SectionEnabledProperty); }
            set { SetValue(SectionEnabledProperty, value); }
        }

        public static readonly DependencyProperty SectionEnabledProperty = DependencyProperty.Register("SectionEnabled",
                                                                                                       typeof(bool),
                                                                                                       typeof(SectionRC),
                                                                                                       new PropertyMetadata(false));
        /// <summary>
        /// The text displayed as the title for the section in the styled GroupBox.
        /// </summary>
        public String SectionTitleText
        {
            get { return (String)GetValue(SectionTitleTextProperty); }
            set { SetValue(SectionTitleTextProperty, value); }
        }

        public static readonly DependencyProperty SectionTitleTextProperty = DependencyProperty.Register("SectionTitleText", 
                                                                                                         typeof(string),
                                                                                                         typeof(SectionRC), 
                                                                                                          new PropertyMetadata(""));
        public String SwitchLegendText
        {
            get { return (String)GetValue(SwitchLegendTextProperty); }
            set { SetValue(SwitchLegendTextProperty, value); }
        }

        public static readonly DependencyProperty SwitchLegendTextProperty = DependencyProperty.Register("SwitchLegendText",
                                                                                                         typeof(string),
                                                                                                         typeof(SectionRC),
                                                                                                         new PropertyMetadata(""));
        public LEDColor SwitchOffColor
        {
            get { return (LEDColor)GetValue(SwitchOffColorProperty); }
            set { SetValue(SwitchOffColorProperty, value); }
        }

        public static readonly DependencyProperty SwitchOffColorProperty = DependencyProperty.Register("SwitchOffColor",
                                                                                                         typeof(LEDColor),
                                                                                                         typeof(SectionRC),
                                                                                                         new PropertyMetadata(LEDColor.eLEDRed));

        public LEDColor SwitchOnColor
        {
            get { return (LEDColor)GetValue(SwitchOnColorProperty); }
            set { SetValue(SwitchOnColorProperty, value); }
        }

        public static readonly DependencyProperty SwitchOnColorProperty = DependencyProperty.Register("SwitchOnColor",
                                                                                                      typeof(LEDColor),
                                                                                                      typeof(SectionRC),
                                                                                                      new PropertyMetadata(LEDColor.eLEDGreen));
        public double SwitchSize
        {
            get { return (double)GetValue(SwitchSizeProperty); }
            set { SetValue(SwitchSizeProperty, value); }
        }

        public static readonly DependencyProperty SwitchSizeProperty = DependencyProperty.Register("SwitchSize",
                                                                                                   typeof(double),
                                                                                                   typeof(SectionRC),
                                                                                                   new PropertyMetadata(64.0));
        #endregion

        /// <summary>
        /// Handle Toggle Switch being clicked.
        /// </summary>
        /// <param name="senderUnused">UI element objec triggering the event (unused).</param>
        /// <param name="argsUnused">RoutedEventArgs object to contain any arguments (unused).</param>
        private void RCTSClkd(object senderUnused, RoutedEventArgs argsUnused)
        {
            // ReSharper disable once PossibleNullReferenceException
            Logger.GetInstance().Log(new LogMessage(LogMessage.Severity.eDebug,
                LogMessage.LogMessageType.eSubInfo,
                GetType().FullName, System.Reflection.MethodBase.GetCurrentMethod().Name,
                "Switch = " + (true == RCTS.SwitchOn ? "ON" : "OFF")));

            Control1.ControlEnabled = RCTS.SwitchOn;
        }
    }
}

