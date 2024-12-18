// Adapted from the Rotary Control described in https://www.codeproject.com/Articles/4044072/A-WPF-Rotary-Control.  

using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RotaryControl
{
    /*
     *  Represents an arc or ring on the Rotary Control.
     */
    public class RotaryControlArc
    {
        public Brush Fill { get; set; }
        public Brush Stroke { get; set; }

        public double AngleInDegrees { get; set; }
        public double Radius { get; set; }
        public double StartAngleInDegrees { get; set; }
        public double StrokeThickness { get; set; }
        public double Thickness { get; set; }

        public Point Centre { get; set; }

        /// <summary>
        /// Convert an angle and radius to Cartesian coordinates.
        /// </summary>
        /// <param name="angle">The angle.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>Point object containing the computed Cartesian coordinates.</returns>
        public static Point ComputeCartesianCoordinate(double angle, double radius)
        {
            double angleRad = (Math.PI / 180.0) * (angle - 90);

            double x = radius * Math.Cos(angleRad);
            double y = radius * Math.Sin(angleRad);

            return new Point(x, y);
        }

        /// <summary>
        /// Constructor (default).
        /// </summary>
        public RotaryControlArc()
        {
            Fill = Brushes.White;
            Stroke = Brushes.Black;
            StrokeThickness = 0;
            Thickness = 10;
        }

        /// <summary>
        /// Create a copy of the current Arc.
        /// </summary>
        /// <returns>RotaryControlArc object, copied from the current Arc.</returns>
        public RotaryControlArc Clone()
        {
            RotaryControlArc arc = new RotaryControlArc();

            arc.AngleInDegrees = AngleInDegrees;
            arc.Centre = Centre;
            arc.Fill = Fill;
            arc.Radius = Radius;
            arc.StartAngleInDegrees = StartAngleInDegrees;
            arc.StrokeThickness = 0;
            arc.Thickness = Thickness;

            return arc;
        }

        /// <summary>
        /// Create an Arc segment.
        /// </summary>
        /// <returns>Path object representing an Arc.</returns>
        public Path CreateArcSegment()
        {
            Point outerArcStartPoint = ComputeCartesianCoordinate(StartAngleInDegrees, Radius);

            outerArcStartPoint.Offset(Centre.X, Centre.Y);

            Point outerArcEndPoint = ComputeCartesianCoordinate(StartAngleInDegrees + AngleInDegrees, Radius);

            outerArcEndPoint.Offset(Centre.X, Centre.Y);

            bool largeArc = AngleInDegrees > 180.0;

            Size outerArcSize = new Size(Radius, Radius);

            double insideRadius = Radius - Thickness;

            Point innerArcStartPoint = ComputeCartesianCoordinate(StartAngleInDegrees, insideRadius);

            innerArcStartPoint.Offset(Centre.X, Centre.Y);

            Point innerArcEndPoint = ComputeCartesianCoordinate(StartAngleInDegrees + AngleInDegrees, insideRadius);

            innerArcEndPoint.Offset(Centre.X, Centre.Y);

            Size innerArcSize = new Size(insideRadius, insideRadius);

            Path path = new Path();

            path.Fill = Fill;
            path.Stroke = Stroke;
            path.StrokeThickness = StrokeThickness;

            PathGeometry pathGeometry = new PathGeometry();

            path.Data = pathGeometry;

            PathFigure pathFigure = new PathFigure();

            pathFigure.IsFilled = true;
            pathFigure.StartPoint = outerArcStartPoint;
            pathGeometry.Figures.Add(pathFigure);

            ArcSegment arcSegment = new ArcSegment();

            arcSegment.Point = outerArcEndPoint;
            arcSegment.Size = outerArcSize;
            arcSegment.SweepDirection = SweepDirection.Clockwise;
            arcSegment.IsLargeArc = largeArc;
            pathFigure.Segments.Add(arcSegment);

            LineSegment lineSegment = new LineSegment();

            lineSegment.Point = innerArcEndPoint;
            pathFigure.Segments.Add(lineSegment);

            arcSegment = new ArcSegment();

            arcSegment.Point = innerArcStartPoint;
            arcSegment.Size = innerArcSize;
            arcSegment.SweepDirection = SweepDirection.Counterclockwise;
            arcSegment.IsLargeArc = largeArc;
            pathFigure.Segments.Add(arcSegment);

            lineSegment = new LineSegment();

            lineSegment.Point = outerArcStartPoint;
            pathFigure.Segments.Add(lineSegment);

            return path;
        }
    }
}
