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


namespace ToggleSwitchControl.Enums
{
    /// <summary>
    /// LED color selections.
    /// </summary>
    public enum LEDColor
    {
        [Description("Blue")]    eLEDBlue,
        [Description("Green")]   eLEDGreen,
        [Description("Orange")]  eLEDOrange,
        [Description("Red")]     eLEDRed,
        [Description("")]        eLEDUndefined,
        [Description("White")]   eLEDWhite,
        [Description("Yellow")]  eLEDYellow
    };
}
