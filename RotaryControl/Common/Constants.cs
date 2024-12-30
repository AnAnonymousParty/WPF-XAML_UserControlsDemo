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

namespace RotaryControl.Common
{
    /// <summary>
    /// Constant values used throughout the control.
    /// </summary>
    public class Constants
    {
        public const double constMaximumOuterDialBorderThickness = 30.0;
        public const double constMaximumInnerDialRadius          = 75;
        public const double constMaximumMajorTickIncrement       = 1000;
        public const double constMinimumOuterDialBorderThickness = 0.0;
        public const double constMinimumInnerDialRadius          = 0;
        public const double constMinimumMajorTickIncrement       = 0.1;
        public const double OneTwentyDegreesInRadians            = (Math.PI + Math.PI) / 3;
        public const double ThirtyDegreesInRadians               = Math.PI / 6;

        public const int constMaximumNumberOfMajorTicks = 20;
        public const int constMaximumNumberOfMinorTicks = 20;
        public const int constMinimumNumberOfMajorTicks = 3;
        public const int constMinimumNumberOfMinorTicks = 0;
    }
}
