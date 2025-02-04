/*
 
Adapted from https://github.com/shakram02/XamlVirtualJoystick. 
    
MIT License

Copyright (c) 2018 Ahmed Hamdy Mahmoud (shakram02)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.    
                                                               
*/

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace JoystickControl
{
    /// <summary>
    /// Interaction logic for Joystick.xaml.
    /// </summary>
    /// <remarks>
    /// +=========================================================================================================+
    /// |                                     DEPENDENCY PROPERTIES                                               |
    /// +==========================+==========+===================================================================+
    /// |          NAME            |   TYPE   |                         DESCRIPTION                               |
    /// +==========================+==========+===================================================================+
    /// | Angle                    | double   | Current angle of the joystick.                                    |
    /// +--------------------------+----------+-------------------------------------------------------------------+
    /// | AngleStep                | double   | Amount of angular change required to trigger a stick moved event. |
    /// +--------------------------+----------+-------------------------------------------------------------------+
    /// | ControlEnabled           | bool     | Determines whether the control is enabled.                        |
    /// +--------------------------+----------+-------------------------------------------------------------------+    
    /// | Distance         	       | double   | The current distance (from center) of the joystick.               |
    /// +--------------------------+----------+-------------------------------------------------------------------+
    /// | DistanceStep             | double   | Amount of displacement required to trigger a stick moved event.   |
    /// +--------------------------+----------+-------------------------------------------------------------------+
    /// | PresetX                  | double   | Initial X position of the joystick.                               |                                        
    /// +--------------------------+----------+-------------------------------------------------------------------+
    /// | PresetY                  | double   | Initial Y position of the joystick.                               |  
    /// +--------------------------+----------+-------------------------------------------------------------------+
    /// | ResetKnobAfterRelease    | bool     | Controls whether stick returns to center after having been moved. | 
    /// +--------------------------+----------+-------------------------------------------------------------------+
    /// | X                        | double   | The current joystick X position.                                  | 
    /// +--------------------------+----------+-------------------------------------------------------------------+
    /// | Y                        | double   | The current joystick Y position.                                  |                                        
    /// +==========================+==========+===================================================================+ 
    /// </remarks>    
    public partial class Joystick
    {
        #region Dependency Properties

        /// <summary>Current angle in degrees from 0 to 360,</summary>
        public static readonly DependencyProperty AngleProperty = DependencyProperty.Register("Angle", 
                                                                                              typeof(double), 
                                                                                              typeof(Joystick), 
                                                                                              null);

        public double Angle
        {
            get { return Convert.ToDouble(GetValue(AngleProperty)); }
            private set { SetValue(AngleProperty, value); }
        }

        /// <summary>Set the amount of angular mouse movement needed to trigger an update,</summary>
        public static readonly DependencyProperty AngleStepProperty = DependencyProperty.Register("AngleStep",
                                                                                                  typeof(double),
                                                                                                  typeof(Joystick),
                                                                                                  new PropertyMetadata(1.0));
        public double AngleStep
        {
            get { return Convert.ToDouble(GetValue(AngleStepProperty)); }
            set
            {
                if (value < 1) value = 1; else if (value > 90) value = 90;
                SetValue(AngleStepProperty, Math.Round(value));
            }
        }

        /// <summary>
        /// Disable/Enable the control.
        /// </summary>
        public static readonly DependencyProperty ControlEnabledProperty = DependencyProperty.Register("ControlEnabled",
                                                                                                       typeof(bool),
                                                                                                       typeof(Joystick),
                                                                                                       new FrameworkPropertyMetadata(false));
        public bool ControlEnabled
        {
            get { return (bool)GetValue(ControlEnabledProperty); }
            set
            {
                SetValue(ControlEnabledProperty, value);

                ArrowBrush = (true == value ? Brushes.LightGreen : Brushes.DarkRed);

                DownArrow.Fill = ArrowBrush;
                LeftArrow.Fill = ArrowBrush;
                RightArrow.Fill = ArrowBrush;
                UPArrow.Fill = ArrowBrush;
            }
        }

        /// <summary>Set the amount of linear mouse movement needed to trigger an update,</summary>
        public static readonly DependencyProperty DistanceStepProperty = DependencyProperty.Register("DistanceStep",
                                                                                                     typeof(double),
                                                                                                     typeof(Joystick),
                                                                                                     new PropertyMetadata(1.0));
        public double Distance
        {
            get { return Convert.ToDouble(GetValue(DistanceProperty)); }
            private set { SetValue(DistanceProperty, value); }
        }

        /// <summary>Knob Preset X</summary>
        public static readonly DependencyProperty PresetXProperty = DependencyProperty.Register("PresetX", 
                                                                                                typeof(double), 
                                                                                                typeof(Joystick), 
                                                                                                new FrameworkPropertyMetadata(0.0, OnPresetXChanged));
        public double DistanceStep
        {
         get { return Convert.ToDouble(GetValue(DistanceStepProperty)); }
         set
         {
          if (value < 1) value = 1; else if (value > 50) value = 50;
          SetValue(DistanceStepProperty, value);
         }
        }

        /// <summary>Current distance (or "magnitude"), from 0 to 100.</summary>
        public static readonly DependencyProperty DistanceProperty = DependencyProperty.Register("Distance",
                                                                                                  typeof(double),
                                                                                                  typeof(Joystick),
                                                                                                  null);
        public double PresetX
        {
            get
            {
                return presetX;
            }
            set
            {
                presetX = value;

                OnPropertyChanged("PresetX");
            }
        }

        private static void OnPresetXChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Joystick)d).OnPresetXChanged(e);
        }

        protected virtual void OnPresetXChanged(DependencyPropertyChangedEventArgs e)
        {
            if (null != e.NewValue)
            {
                presetX = (double)e.NewValue;

                MoveKnobToPreset();
            }
        }

        /// <summary>Knob Preset Y</summary>
        public static readonly DependencyProperty PresetYProperty = DependencyProperty.Register("PresetY", 
                                                                                                typeof(double), 
                                                                                                typeof(Joystick), 
                                                                                                new FrameworkPropertyMetadata(0.0, OnPresetYChanged));
        public double PresetY
        {
            get { return presetY; }
            set
            {
                presetY = value;

                OnPropertyChanged("PresetY");
            }
        }

        private static void OnPresetYChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Joystick)d).OnPresetYChanged(e);
        }

        protected virtual void OnPresetYChanged(DependencyPropertyChangedEventArgs e)
        {
            if (null != e.NewValue)
            {
                presetY = (double)e.NewValue;

                MoveKnobToPreset();
            }
        }

        /// <summary>Indicates whether the joystick knob resets its place after being released,</summary>
        public static readonly DependencyProperty ResetKnobAfterReleaseProperty = DependencyProperty.Register("ResetKnobAfterRelease",
                                                                                                              typeof(bool),
                                                                                                              typeof(Joystick),
                                                                                                              new PropertyMetadata(true));
        public bool ResetKnobAfterRelease
        {
            get { return Convert.ToBoolean(GetValue(ResetKnobAfterReleaseProperty)); }
            set { SetValue(ResetKnobAfterReleaseProperty, value); }
        }

        /// <summary>X value of the joystick position.</summary>
        public static readonly DependencyProperty XProperty = DependencyProperty.Register("X", 
                                                                                          typeof(double), 
                                                                                          typeof(Joystick), 
                                                                                          null);
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
                OnPropertyChanged("X");
            }
        }

        /// <summary>Y value of the joystick position,</summary>
        public static readonly DependencyProperty YProperty = DependencyProperty.Register("Y", 
                                                                                          typeof(double), 
                                                                                          typeof(Joystick), 
                                                                                          null);
        public double Y
        {
            get { return y; }
            set
            {
                y = value;
                OnPropertyChanged("Y");
            }
        }

        #endregion

        #region UI Bound Properties

        public Brush ArrowBrush
        {
            get { return arrowBrush; }
            set
            {
                arrowBrush = value;
                OnPropertyChanged("ArrowBrush");
            }
        }

        public double ArrowHeight
        {
            get { return arrowHeight; }
            set
            {
                arrowHeight = value;
                OnPropertyChanged("ArrowHeight");
            }
        }

        public double ArrowWidth
        {
            get { return arrowWidth; }
            set
            {
                arrowWidth = value;
                OnPropertyChanged("ArrowWidth");
            }
        }

        public double BottomArrowLeft
        {
            get { return bottomArrowLeft; }
            set
            {
                bottomArrowLeft = value;
                OnPropertyChanged("BottomArrowLeft");
            }
        }

        public double BottomArrowTop
        {
            get { return bottomArrowTop; }
            set
            {
                bottomArrowTop = value;
                OnPropertyChanged("BottomArrowTop");
            }
        }

        public double InnerCircleHeight
        {
            get { return innerCircleHeight; }
            set
            {
                innerCircleHeight = value;
                OnPropertyChanged("InnerCircleHeight");
            }
        }

        public double InnerCircleLeft
        {
            get { return innerCircleLeft; }
            set
            {
                innerCircleLeft = value;
                OnPropertyChanged("InnerCircleLeft");
            }
        }

        public double InnerCircleTop
        {
            get { return innerCircleTop; }
            set
            {
                innerCircleTop = value;
                OnPropertyChanged("InnerCircleTop");
            }
        }

        public double InnerCircleWidth
        {
            get { return innerCircleWidth; }
            set
            {
                innerCircleWidth = value;
                OnPropertyChanged("InnerCircleWidth");
            }
        }

        public int JoystickControlHeight
        {
            get { return joystickHeight; }
            set
            {
                joystickHeight = value;
                OnPropertyChanged("JoystickControlHeight");
            }
        }

        public int JoystickControlWidth
        {
            get { return joystickWidth; }
            set
            {
                joystickWidth = value;
                OnPropertyChanged("JoystickControlWidth");
            }
        }

        public double LeftArrowLeft
        {
            get { return leftArrowLeft; }
            set
            {
                leftArrowLeft = value;
                OnPropertyChanged("LeftArrowLeft");
            }
        }

        public double LeftArrowTop
        {
            get { return leftArrowTop; }
            set
            {
                leftArrowTop = value;
                OnPropertyChanged("LeftArrowTop");
            }
        }

        public double OuterCircleHeight
        {
            get { return outerCircleHeight; }
            set
            {
                outerCircleHeight = value;
                OnPropertyChanged("OuterCircleHeight");
            }
        }

        public double OuterCircleWidth
        {
            get { return outerCircleWidth; }
            set
            {
                outerCircleWidth = value;
                OnPropertyChanged("OuterCircleWidth");
            }
        }

        public double RightArrowLeft
        {
            get { return rightArrowLeft; }
            set
            {
                rightArrowLeft = value;
                OnPropertyChanged("RightArrowLeft");
            }
        }

        public double RightArrowTop
        {
            get { return rightArrowTop; }
            set
            {
                rightArrowTop = value;
                OnPropertyChanged("RightArrowTop");
            }
        }

        public double TopArrowLeft
        {
            get { return topArrowLeft; }
            set
            {
                topArrowLeft = value;
                OnPropertyChanged("TopArrowLeft");
            }
        }

        public double TopArrowTop
        {
            get { return topArrowTop; }
            set
            {
                topArrowTop = value;
                OnPropertyChanged("TopArrowTop");
            }
        }

        #endregion

        #region Internal Variables

        private bool movedOnce;

        private Brush arrowBrush;

        private double maxX;
        private double maxY;
        private double minX;
        private double minY;

        private double arrowHeight;
        private double arrowWidth;

        private double bottomArrowLeft;
        private double bottomArrowTop;

        private double innerCircleLeft;
        private double innerCircleTop;

        private double innerCircleHeight;
        private double innerCircleWidth;

        private double leftArrowLeft;
        private double leftArrowTop;

        private double outerCircleHeight;
        private double outerCircleWidth;

        private double presetX;
        private double presetY;

        private double prevAngle,
                       prevDistance;

        private double ringHeight;
        private double ringWidth;

        private double rightArrowLeft;
        private double rightArrowTop;

        private double topArrowLeft;
        private double topArrowTop;

        private double x;
        private double y;

        private int joystickHeight;
        private int joystickWidth;

        private Point joystickCenter,
                      startPos;

        #endregion

        #region Event Handlers

        /// <summary>Delegate for joystick events that hold no data</summary>
        /// <param name="sender">The object that fired the event</param>
        public delegate void EmptyJoystickEventHandler(Joystick sender);

        /// <summary>Delegate holding data for joystick state change</summary>
        /// <param name="sender">The object that fired the event</param>
        /// <param name="args">Holds new values for angle and distance</param>
        public delegate void OnScreenJoystickEventHandler(Joystick sender, JoystickEventArgs args);

        /// <summary>This event fires once the joystick is captured</summary>
        public event EmptyJoystickEventHandler Captured;

        /// <summary>This event fires whenever the joystick moves</summary>
        public event OnScreenJoystickEventHandler Moved;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>This event fires once the joystick is released and its position is reset</summary>
        public event EmptyJoystickEventHandler Released;

        #endregion

        /// <summary>
        /// Constructor (default).
        /// </summary>
        public Joystick()
        {
            arrowBrush = Brushes.LightGreen;

            joystickHeight = 340;
            joystickWidth  = 340;

            arrowHeight = joystickHeight * 0.058;
            arrowWidth  = joystickHeight * 0.176;

            joystickCenter.Y = joystickHeight / 2;
            joystickCenter.X = joystickHeight / 2;

            innerCircleHeight = joystickHeight / 2;
            innerCircleWidth  = joystickWidth  / 2;

            innerCircleTop  = innerCircleHeight / 2 - 1;
            innerCircleLeft = innerCircleWidth  / 2 - 1;

            minX = joystickWidth  - (joystickWidth * 0.9);
            maxX = joystickWidth  * 0.9;
            minY = joystickHeight * 0.9;
            maxY = joystickHeight - (joystickHeight * 0.9);

            outerCircleHeight = joystickHeight;
            outerCircleWidth = joystickWidth;

            ringHeight = (outerCircleHeight - innerCircleHeight) / 2;
            ringWidth  = (outerCircleWidth  - innerCircleWidth) / 2;

            bottomArrowLeft = (joystickWidth / 2) - (arrowWidth / 2);
            bottomArrowTop  = joystickHeight - ((ringHeight / 2) + (arrowHeight / 2));

            leftArrowLeft = (ringWidth / 2) - (arrowWidth / 2);
            leftArrowTop  = (joystickHeight / 2) - (arrowHeight / 2);

            rightArrowLeft = joystickWidth - ((ringWidth / 2) + (arrowWidth / 2));
            rightArrowTop  = (joystickHeight / 2) - (arrowHeight / 2);

            topArrowLeft = (joystickWidth / 2) - (arrowWidth / 2);
            topArrowTop  = (ringHeight / 2) - (arrowHeight / 2);

            InitializeComponent();

            movedOnce = false;

            Knob.MouseLeftButtonDown += Knob_MouseLeftButtonDown;
            Knob.MouseLeftButtonUp   += Knob_MouseLeftButtonUp;
            Knob.MouseMove           += Knob_MouseMove;
        }

        /// <summary>
        /// Move Knob to Preset position.
        /// </summary>
        public void MoveKnobToPreset()
        {
            startPos = joystickCenter;

            movedOnce = true;

            double angle = Math.Atan2(PresetY, PresetX) * 180 / Math.PI;

            if (angle > 0)
            {
                angle += 90;
            }
            else
            {
                angle = 270 + (180 + angle);

                if (angle >= 360)
                {
                    angle -= 360;
                }
            }

            double distance = Math.Round(Math.Sqrt(PresetX * PresetX + PresetY * PresetY) / 135 * 100);

            Angle    = angle;
            Distance = distance;

            TranslateTransform knobTransform = new TranslateTransform();

            knobTransform.X = presetX / 135 * 100;
            knobTransform.Y = presetY / 135 * 100;

            TransformGroup knobTransformGroup = new TransformGroup();

            knobTransformGroup.Children.Add(knobTransform);

            RotateTransform shaftRotateTransform = new RotateTransform();

            shaftRotateTransform.Angle   = Angle - 180;
            shaftRotateTransform.CenterX = Shaft.Width / 2;

            TransformGroup shaftTransformGroup = new TransformGroup();

            shaftTransformGroup.Children.Add(shaftRotateTransform);

            Shaft.Height = Distance;

            Knob.RenderTransform  = knobTransformGroup;
            Shaft.RenderTransform = shaftTransformGroup;

            prevAngle    = Angle;
            prevDistance = Distance;
        }

        #region Event Handlers

        /// <summary>
        /// Handle bound property changed.
        /// </summary>
        /// <param name="propertyName">String containing name of property that has changed.</param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Handle mouse left button pressed event for the joystick knob,
        /// </summary>
        /// <param name="senderUnused">Object identifying source of the event (unused).</param>
        /// <param name="args">MouseEventArgs object containing the mouse coordinates.</param>
        private void Knob_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (true == ResetKnobAfterRelease || false == movedOnce)
            {
                prevAngle = prevDistance = 0;
                startPos  = e.GetPosition(baseCanvas);                
            }

            if (null != Captured)
            {
                Captured.Invoke(this);
            }

            Knob.CaptureMouse();

            movedOnce = true;
        }

        /// <summary>
        /// Handle mouse left button released event for the joystick knob,
        /// </summary>
        /// <param name="senderUnused">Object identifying source of the event (unused).</param>
        /// <param name="argsUnused">MouseEventArgs object containing the mouse coordinates (unused).</param>
        private void Knob_MouseLeftButtonUp(object senderUnused, MouseButtonEventArgs args)
        {
            Knob.ReleaseMouseCapture();

            if (true == ResetKnobAfterRelease)
            {
                Angle = Distance = prevAngle = prevDistance = 0;

                X = 0;
                Y = 0;

                TranslateTransform knobTransform = new TranslateTransform();

                knobTransform.X = 0;
                knobTransform.Y = 0;

                TransformGroup knobTransformGroup = new TransformGroup();

                knobTransformGroup.Children.Add(knobTransform);

                TransformGroup shaftTransformGroup = new TransformGroup();

                RotateTransform shaftRotateTransform = new RotateTransform();

                shaftTransformGroup.Children.Add(shaftRotateTransform);

                Shaft.Height = Distance;

                Knob.RenderTransform  = knobTransformGroup;
                Shaft.RenderTransform = shaftTransformGroup;

                if (null != Moved)
                {
                    Moved.Invoke(this, new JoystickEventArgs { Angle = Angle, Distance = Distance, X = x, Y = y });
                }

                if (null != Released)
                {
                    Released.Invoke(this);
                }
            }
        }

        /// <summary>
        /// Handle mouse moved event for the joystick knob,
        /// </summary>
        /// <param name="senderUnused">Object identifying source of the event (unused).</param>
        /// <param name="args">MouseEventArgs object containing the mouse coordinates.</param>
        private void Knob_MouseMove(object sender, MouseEventArgs args)
        {
            if (false == Knob.IsMouseCaptured)
            {
                return;
            }

            Point newPos = args.GetPosition(baseCanvas);

            // Confine the Knob's range of movement while letting the user drag outside of those bounds:

            if (newPos.X > maxX)
            {
                newPos.X = maxX;
            }

            if (newPos.X < minX)
            {
                newPos.X = minX;
            }

            if (newPos.Y < maxY)
            {
                newPos.Y = maxY;
            }

            if (newPos.Y > minY)
            {
                newPos.Y = minY;
            }

            Point deltaPos = new Point(newPos.X - startPos.X, newPos.Y - startPos.Y);

            x =   deltaPos.X / 135 * 100;
            y = -(deltaPos.Y / 135 * 100);

            double angle = Math.Atan2(deltaPos.Y, deltaPos.X) * 180 / Math.PI;

            if (angle > 0)
            {
                angle += 90;
            }
            else
            {
                angle = 270 + (180 + angle);

                if (angle >= 360)
                {
                    angle -= 360;
                }
            }

            double distance = Math.Round(Math.Sqrt(deltaPos.X * deltaPos.X + deltaPos.Y * deltaPos.Y) / 135 * 100);

            if (0 == distance)
            {
                return;
            }

            Angle    = angle;
            Distance = distance;

            if (!(Math.Abs(prevAngle - angle) > AngleStep) && !(Math.Abs(prevDistance - distance) > DistanceStep))
            {
                return;
            }

            if (null != Moved)
            {
                Moved.Invoke(this, new JoystickEventArgs { Angle = Angle, Distance = Distance, X = x, Y = y });
            }

            prevAngle    = Angle;
            prevDistance = Distance;

            TranslateTransform knobTransform = new TranslateTransform();

            knobTransform.X =  x;
            knobTransform.Y = -y;

            TransformGroup knobTransformGroup = new TransformGroup();

            knobTransformGroup.Children.Add(knobTransform);

            RotateTransform shaftRotateTransform = new RotateTransform();

            shaftRotateTransform.Angle   = angle - 180;
            shaftRotateTransform.CenterX = Shaft.Width / 2;

            TransformGroup shaftTransformGroup = new TransformGroup();

            shaftTransformGroup.Children.Add(shaftRotateTransform);

            Shaft.Height = distance;

            Knob.RenderTransform  = knobTransformGroup;
            Shaft.RenderTransform = shaftTransformGroup;
        }

        #endregion
    }
}
