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
+====================================================================================================+
|                                       DEPENDENCY PROPERTIES                                        |
+==========================+==========+==============================================================+
|          NAME            |   TYPE   |                        DESCRIPTION                           |
+==========================+==========+==============================================================+
| ControlEnabled           | bool     | Determines whether the control is enabled.                   |
+--------------------------+----------+--------------------------------------------------------------+
| LEDOffColor              | LEDColor | Color of the LED when the toggle switch is in the off state. |
+--------------------------+----------+--------------------------------------------------------------+
| LEDOnColor               | LEDColor | Color of the LED when the toggle switch is in the on state.  |
+--------------------------+----------+--------------------------------------------------------------+
| LegendBrush              | Brush    | Color used to display the legend text.                       |
+--------------------------+----------+--------------------------------------------------------------+
| LegendFontSize           | double   | Size of the font used to display the legend text.            |
+--------------------------+----------+--------------------------------------------------------------+
| SectionEnabled           | bool     | Determines whether the control in the section are enabled.   |
+--------------------------+----------+--------------------------------------------------------------+
| SwitchLegendText         | String   | Text displayed below the toggle switch.                      |
+--------------------------+----------+--------------------------------------------------------------+
| SwitchSize               | double   | Size of the toggle switch (Height = Width).                  |
+==========================+==========+==============================================================+
 */

using System;
using System.ComponentModel;
using System.Windows;

using ToggleSwitchControl.Enums;
using Brush = System.Windows.Media.Brush;
using Brushes = System.Windows.Media.Brushes;


namespace ToggleSwitchControl
{
    /// <summary>
    /// Interaction logic for ToggleSwitchControl.xaml.
    /// </summary>
    public partial class ToggleSwitchControl
    {
        public ToggleSwitchControl()
        {
            InitializeComponent();
        }

        #region Dependency 

        #region Control Enabled property

        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static readonly DependencyProperty ControlEnabledProperty = DependencyProperty.Register("ControlEnabled",
                                                                                                       typeof(bool),
                                                                                                       typeof(ToggleSwitchControl),
                                                                                                       new FrameworkPropertyMetadata(false, OnControlEnabledChanged));
        public bool ControlEnabled
        {
            get { return (bool)GetValue(ControlEnabledProperty); }
            set
            {
                SetValue(ControlEnabledProperty, value);
            }
        }

        private static void OnControlEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ToggleSwitchControl)d).OnControlEnabledChanged(e);
        }

        protected virtual void OnControlEnabledChanged(DependencyPropertyChangedEventArgs e)
        {
            if (null != e.NewValue)
            {
                ControlEnabled = (bool)e.NewValue;
            }
        }
        #endregion

        #region LED OFF Color property

        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static readonly DependencyProperty LEDOffColorProperty = DependencyProperty.Register("LEDOffColor",
                                                                                                    typeof(LEDColor),
                                                                                                    typeof(ToggleSwitchControl),
                                                                                                    new FrameworkPropertyMetadata(LEDColor.eLEDUndefined, OnLEDOffColorChanged));
        public LEDColor LEDOffColor
        {
            get { return (LEDColor)GetValue(LEDOffColorProperty); }
            set
            {
                SetValue(LEDOffColorProperty, value);
            }
        }

        private static void OnLEDOffColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ToggleSwitchControl)d).OnLEDOffColorChanged(e);
        }

        protected virtual void OnLEDOffColorChanged(DependencyPropertyChangedEventArgs e)
        {
            if (null != e.NewValue)
            {
                LEDOffColor = (LEDColor)e.NewValue;
            }
        }
        #endregion

        #region LED ON Color property

        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static readonly DependencyProperty LEDOnColorProperty = DependencyProperty.Register("LEDOnColor",
                                                                                                    typeof(LEDColor),
                                                                                                    typeof(ToggleSwitchControl),
                                                                                                    new FrameworkPropertyMetadata(LEDColor.eLEDUndefined, OnLEDOnColorChanged));
        public LEDColor LEDOnColor
        {
            get { return (LEDColor)GetValue(LEDOnColorProperty); }
            set
            {
                SetValue(LEDOnColorProperty, value);
            }
        }

        private static void OnLEDOnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ToggleSwitchControl)d).OnLEDOnColorChanged(e);
        }

        protected virtual void OnLEDOnColorChanged(DependencyPropertyChangedEventArgs e)
        {
            if (null != e.NewValue)
            {
                LEDOnColor = (LEDColor)e.NewValue;
            }
        }

        #endregion
        
        #region Legend Brush property

        [Bindable(true)] [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
        public static readonly DependencyProperty LegendBrushProperty = DependencyProperty.Register("LegendBrush",
                                                                                                    typeof(Brush), 
                                                                                                    typeof(ToggleSwitchControl),
                                                                                                    new FrameworkPropertyMetadata(Brushes.Gray, OnLegendBrushChanged));
        public Brush LegendBrush
        {
            get { return (Brush) GetValue(LegendBrushProperty); }
            set
            {
                SetValue(LegendBrushProperty, value);

                SwitchLegend.Foreground = value;
            }
        }

        private static void OnLegendBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ToggleSwitchControl) d).OnLegendBrushChanged(e);
        }

        protected virtual void OnLegendBrushChanged(DependencyPropertyChangedEventArgs e)
        {
            if (null != e.NewValue)
            {
                LegendBrush = (Brush) e.NewValue;
            }
        }

        #endregion

        #region Legend Font Size property

        [Bindable(true)] [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] 
        public static readonly DependencyProperty LegendFontSizeProperty = DependencyProperty.Register("LegendFontSize",
                                                                                                       typeof(Double), 
                                                                                                       typeof(ToggleSwitchControl),
                                                                                                       new FrameworkPropertyMetadata(10.0, OnLegendFontSizeChanged));
        public Double LegendFontSize
        {
            get { return (Double) GetValue(LegendFontSizeProperty); }
            set
            {
                SetValue(LegendFontSizeProperty, value);

                SwitchLegend.FontSize = value;
            }
        }

        private static void OnLegendFontSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ToggleSwitchControl)d).OnLegendFontSizeChanged(e);
        }

        protected virtual void OnLegendFontSizeChanged(DependencyPropertyChangedEventArgs e)
        {
            if (null != e.NewValue)
            {
                LegendFontSize = (Double) e.NewValue;
            }
        }

        #endregion

        #region Legend Text property

        [Bindable(true)] [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] public static readonly DependencyProperty SwitchLegendTextProperty =
            DependencyProperty.Register("SwitchLegendText",
                typeof(String), 
                typeof(ToggleSwitchControl),
                new FrameworkPropertyMetadata("SwitchLegend", OnSwitchLegendTextChanged));

        public String SwitchLegendText
        {
            get { return (String)GetValue(SwitchLegendTextProperty); }
            set
            {
                SetValue(SwitchLegendTextProperty, value);

                SwitchLegend.Content = value;
            }
        }

        private static void OnSwitchLegendTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ToggleSwitchControl)d).OnSwitchLegendTextChanged(e);
        }

        protected virtual void OnSwitchLegendTextChanged(DependencyPropertyChangedEventArgs e)
        {
            if (null != e.NewValue)
            {
                SwitchLegendText = (String)e.NewValue;
            }
        }

        #endregion

        #region Switch Size property

        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static readonly DependencyProperty SwitchSizeProperty = DependencyProperty.Register("SwitchSize",
                                                                                                   typeof(double),
                                                                                                   typeof(ToggleSwitchControl),
                                                                                                   new FrameworkPropertyMetadata(64.0, OnSwitchSizeChanged));
        public double SwitchSize
        {
            get { return (double)GetValue(SwitchSizeProperty); }
            set
            {
                SetValue(SwitchSizeProperty, value);

                ToggleSwitchButton.Height = value;
                ToggleSwitchButton.Width = value;
            }
        }

        private static void OnSwitchSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ToggleSwitchControl)d).OnSwitchSizeChanged(e);
        }

        protected virtual void OnSwitchSizeChanged(DependencyPropertyChangedEventArgs e)
        {
            if (null != e.NewValue)
            {
                SwitchSize = (double)e.NewValue;
            }
        }

        #endregion

        #endregion
    }
}