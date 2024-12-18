# WPF-XAML_UserControlsDemo
Nested user controls demo using MVVM, including Joystick, Rotary Control and Toggle Switch Control.

This application demonstrates several user controls, nested within other user controls, using MVVM 
for data binding.

Controls include:

Joystick:

Adapted from https://github.com/shakram02/XamlVirtualJoystick, modified to expose properties 
to allow the stick to autocenter and adds an animated shaft connecting the ball to the stick.

Rotary Control:

Adapted from https://www.codeproject.com/Articles/4044072/A-WPF-Rotary-Control, adding a legend
below the control.

Toggle switch:

An automated switch with properties to set and style the legend, size the switch and set the LED
indicator colors.



Other user controls represent independent sections to demonstrate how the controls can be combined 
and used together with properties to set the section title and border color.

See ScreenShot.jpg for an image of the running application.

This code was developed under Visual Studio 2013 and targets .NET framework 4.8.1.
