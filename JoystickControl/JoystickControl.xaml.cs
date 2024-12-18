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
using System.Windows.Media.Animation;

namespace JoystickControl
{
    /// <summary>
    /// Interaction logic for Joystick.xaml.
    /// </summary>
    public partial class Joystick
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

        /// <summary>Current angle in degrees from 0 to 360</summary>
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(Joystick), null);

        /// <summary>Current distance (or "magnitude"), from 0 to 100</summary>
        public static readonly DependencyProperty DistanceProperty =
            DependencyProperty.Register("Distance", typeof(double), typeof(Joystick), null);

        /// <summary>Current distance (or "magnitude"), from 0 to 100</summary>
        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register("X", typeof(double), typeof(Joystick), null);

        /// <summary>Current distance (or "magnitude"), from 0 to 100</summary>
        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register("Y", typeof(double), typeof(Joystick), null);

        /// <summary>How often should be raised StickMove event in degrees</summary>
        public static readonly DependencyProperty AngleStepProperty =
            DependencyProperty.Register("AngleStep", typeof(double), typeof(Joystick), new PropertyMetadata(1.0));

        /// <summary>How often should be raised StickMove event in distance units</summary>
        public static readonly DependencyProperty DistanceStepProperty =
            DependencyProperty.Register("DistanceStep", typeof(double), typeof(Joystick), new PropertyMetadata(1.0));

        /// <summary>Indicates whether the joystick knob resets its place after being released</summary>
        public static readonly DependencyProperty ResetKnobAfterReleaseProperty =
            DependencyProperty.Register("ResetKnobAfterRelease", typeof(bool), typeof(Joystick), new PropertyMetadata(true));

        /// <summary>Current angle in degrees from 0 to 360</summary>
        public double Angle
        {
            get { return Convert.ToDouble((object)GetValue(AngleProperty)); }
            private set { SetValue(AngleProperty, value); }
        }

        /// <summary>current distance (or "power"), from 0 to 100</summary>
        public double Distance
        {
            get { return Convert.ToDouble((object)GetValue(DistanceProperty)); }
            private set { SetValue(DistanceProperty, value); }
        }

        /// <summary>How often should be raised StickMove event in degrees</summary>
        public double AngleStep
        {
            get { return Convert.ToDouble((object)GetValue(AngleStepProperty)); }
            set
            {
                if (value < 1) value = 1; else if (value > 90) value = 90;
                SetValue(AngleStepProperty, Math.Round(value));
            }
        }

        /// <summary>How often should be raised StickMove event in distance units</summary>
        public double DistanceStep
        {
            get { return Convert.ToDouble((object)GetValue(DistanceStepProperty)); }
            set
            {
                if (value < 1) value = 1; else if (value > 50) value = 50;
                SetValue(DistanceStepProperty, value);
            }
        }

        /// <summary>Indicates whether the joystick knob resets its place after being released</summary>
        public bool ResetKnobAfterRelease
        {
            get { return Convert.ToBoolean((object)GetValue(ResetKnobAfterReleaseProperty)); }
            set { SetValue(ResetKnobAfterReleaseProperty, value); }
        }

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

        public double InnerCircleHeight
        {
            get { return innerCircleHeight; }
            set
            {
                innerCircleHeight = value;
                OnPropertyChanged("InnerCircleHeight");
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

        public double Y
        {
            get { return y; }
            set
            {
                y = value;
                OnPropertyChanged("Y");
            }
        }

        /// <summary>Delegate holding data for joystick state change</summary>
        /// <param name="sender">The object that fired the event</param>
        /// <param name="args">Holds new values for angle and distance</param>
        public delegate void OnScreenJoystickEventHandler(Joystick sender, JoystickEventArgs args);

        /// <summary>Delegate for joystick events that hold no data</summary>
        /// <param name="sender">The object that fired the event</param>
        public delegate void EmptyJoystickEventHandler(Joystick sender);

        /// <summary>This event fires whenever the joystick moves</summary>
        public event OnScreenJoystickEventHandler Moved;

        /// <summary>This event fires once the joystick is released and its position is reset</summary>
        public event EmptyJoystickEventHandler Released;

        /// <summary>This event fires once the joystick is captured</summary>
        public event EmptyJoystickEventHandler Captured;

        private Point _startPos;
        private double _prevAngle, _prevDistance;
        private readonly Storyboard centerKnob;

        private bool movedOnce;

        private Brush arrowBrush;

        private double arrowHeight;
        private double arrowWidth;

        private double bottomArrowLeft;
        private double bottomArrowTop;

        private double leftArrowLeft;
        private double leftArrowTop;

        private double rightArrowLeft;
        private double rightArrowTop;

        private double topArrowLeft;
        private double topArrowTop;

        private double innerCircleLeft;
        private double innerCircleTop;

        private double innerCircleHeight;
        private double innerCircleWidth;

        private double outerCircleHeight;
        private double outerCircleWidth;

        private int joystickHeight;
        private int joystickWidth;

        private double x;
        private double y;

        public Joystick()
        {
            arrowBrush = System.Windows.Media.Brushes.LightGreen;

            joystickHeight = 340;
            joystickWidth = 340;

            outerCircleHeight = joystickHeight;
            outerCircleWidth = joystickWidth;

            innerCircleHeight = joystickHeight / 2;
            innerCircleWidth = joystickWidth / 2;

            innerCircleTop = innerCircleHeight / 2 - 1;
            innerCircleLeft = innerCircleWidth / 2 - 1;

            arrowHeight = joystickHeight * 0.058;
            arrowWidth = joystickHeight * 0.176;

            double ringHeight = (outerCircleHeight - innerCircleHeight) / 2;
            double ringWidth = (outerCircleWidth - innerCircleWidth) / 2;

            bottomArrowLeft = (joystickWidth / 2) - (arrowWidth / 2);
            bottomArrowTop = joystickHeight - ((ringHeight / 2) + (arrowHeight / 2));

            leftArrowLeft = (ringWidth / 2) - (arrowWidth / 2);
            leftArrowTop = (joystickHeight / 2) - (arrowHeight / 2);

            rightArrowLeft = joystickWidth - ((ringWidth / 2) + (arrowWidth / 2));
            rightArrowTop = (joystickHeight / 2) - (arrowHeight / 2);

            topArrowLeft = (joystickWidth / 2) - (arrowWidth / 2);
            topArrowTop = (ringHeight / 2) - (arrowHeight / 2);

            InitializeComponent();

            movedOnce = false;

            Knob.MouseLeftButtonDown += Knob_MouseLeftButtonDown;
            Knob.MouseLeftButtonUp += Knob_MouseLeftButtonUp;
            Knob.MouseMove += Knob_MouseMove;

            centerKnob = Knob.Resources["CenterKnob"] as Storyboard;
        }

        private void CenterKnobCompleted(object sender, EventArgs e)
        {
            Angle = Distance = _prevAngle = _prevDistance = 0;

            KnobPosition.X = 0;
            KnobPosition.Y = 0;

            X = 0;
            Y = 0;

            if (null != Released)
            {
                Released.Invoke(this);
            }
        }

        private void Knob_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (true == ResetKnobAfterRelease || false == movedOnce)
            {
                _startPos = e.GetPosition(baseCanvas);
                _prevAngle = _prevDistance = 0;
            }

            if (null != Captured)
            {
                Captured.Invoke(this);
            }

            Knob.CaptureMouse();

            if (true == ResetKnobAfterRelease && true == movedOnce)
            {
                centerKnob.Stop();
            }

            movedOnce = true;
        }

        private void Knob_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Knob.ReleaseMouseCapture();

            if (true == ResetKnobAfterRelease)
            {
                centerKnob.Begin();

                Angle = Distance = _prevAngle = _prevDistance = 0;

                KnobPosition.X = 0;
                KnobPosition.Y = 0;

                X = 0;
                Y = 0;

                Moved.Invoke(this, new JoystickEventArgs { Angle = Angle, Distance = Distance, X = x, Y = y });
            }
        }

        private void Knob_MouseMove(object sender, MouseEventArgs e)
        {
            if (false == Knob.IsMouseCaptured)
            {
                return;
            }

            Point newPos = e.GetPosition(baseCanvas);

            Point deltaPos = new Point(newPos.X - _startPos.X, newPos.Y - _startPos.Y);

            x = deltaPos.X / 135 * 100;
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

            if (distance <= 100)
            {
                Angle = angle;
                Distance = distance;

                KnobPosition.X = deltaPos.X;
                KnobPosition.Y = deltaPos.Y;

                X = x;
                Y = y;

                if ((!(Math.Abs(_prevAngle - angle) > AngleStep) && !(Math.Abs(_prevDistance - distance) > DistanceStep)))
                {
                    return;
                }

                if (null != Moved)
                {
                    Moved.Invoke(this, new JoystickEventArgs { Angle = Angle, Distance = Distance, X = x, Y = y });
                }

                _prevAngle = Angle;
                _prevDistance = Distance;
            }

            RotateTransform myRotateTransform = new RotateTransform();

            myRotateTransform.CenterX = Shaft.Width / 2;
            myRotateTransform.Angle = Angle - 180;

            // Create a TransformGroup to contain the transforms 
            // and add the transforms to it. 

            TransformGroup myTransformGroup = new TransformGroup();
            myTransformGroup.Children.Add(myRotateTransform);

            // Associate the transforms to the object.
            Shaft.RenderTransform = myTransformGroup;
            Shaft.Height = Distance;
        }
    }
}
