using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace JFinance.Windows.WPF.Controls
{
    class PiePiece : Shape
    {
        #region Properties

        private static FrameworkPropertyMetadata FrameworkPropertyMetadata => new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure);

        public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("RadiusProperty", typeof(double), typeof(PiePiece), PiePiece.FrameworkPropertyMetadata);

        public static readonly DependencyProperty PushOutProperty = DependencyProperty.Register("PushOutProperty", typeof(double), typeof(PiePiece), PiePiece.FrameworkPropertyMetadata);

        public static readonly DependencyProperty InnerRadiusProperty = DependencyProperty.Register("InnerRadiusProperty", typeof(double), typeof(PiePiece), PiePiece.FrameworkPropertyMetadata);

        public static readonly DependencyProperty WedgeAngleProperty = DependencyProperty.Register("WedgeAngleProperty", typeof(double), typeof(PiePiece), PiePiece.FrameworkPropertyMetadata);

        public static readonly DependencyProperty RotationAngleProperty = DependencyProperty.Register("RotationAngleProperty", typeof(double), typeof(PiePiece), PiePiece.FrameworkPropertyMetadata);

        public static readonly DependencyProperty CentreXProperty = DependencyProperty.Register("CentreXProperty", typeof(double), typeof(PiePiece), PiePiece.FrameworkPropertyMetadata);

        public static readonly DependencyProperty CentreYProperty = DependencyProperty.Register("CentreYProperty", typeof(double), typeof(PiePiece), PiePiece.FrameworkPropertyMetadata);

        public static readonly DependencyProperty PercentageProperty = DependencyProperty.Register("PercentageProperty", typeof(double), typeof(PiePiece), new FrameworkPropertyMetadata(0.0));

        public static readonly DependencyProperty PieceValueProperty = DependencyProperty.Register("PieceValueProperty", typeof(double), typeof(PiePiece), new FrameworkPropertyMetadata(0.0));

        public double Radius
        {
            get => (double)this.GetValue(RadiusProperty);
            set => this.SetValue(RadiusProperty, value);
        }
        
        public double PushOut
        {
            get => (double)this.GetValue(PushOutProperty);
            set => this.SetValue(PushOutProperty, value);
        }

        public double InnerRadius
        {
            get => (double)this.GetValue(InnerRadiusProperty);
            set => this.SetValue(InnerRadiusProperty, value);
        }

        public double WedgeAngle
        {
            get => (double)GetValue(WedgeAngleProperty);
            set
            {
                this.SetValue(WedgeAngleProperty, value);
                this.Percentage = (value / 360.0);
            }
        }

        public double RotationAngle
        {
            get => (double)this.GetValue(RotationAngleProperty);
            set => this.SetValue(RotationAngleProperty, value);
        }

        public double CentreX
        {
            get => (double)this.GetValue(CentreXProperty);
            set => this.SetValue(CentreXProperty, value);
        }

        public double CentreY
        {
            get => (double)this.GetValue(CentreYProperty);
            set => this.SetValue(CentreYProperty, value);
        }

        public double Percentage
        {
            get => (double)this.GetValue(PercentageProperty);
            private set => this.SetValue(PercentageProperty, value);
        }

        public double PieceValue
        {
            get => (double)this.GetValue(PieceValueProperty);
            set => this.SetValue(PieceValueProperty, value);
        }

        protected override Geometry DefiningGeometry => this.GetDefiningGeometry();

        #endregion

        #region Methods

        private Geometry GetDefiningGeometry()
        {
            StreamGeometry geometry = new StreamGeometry { FillRule = FillRule.EvenOdd };

            using (StreamGeometryContext context = geometry.Open())
                this.DrawGeometry(context);

            geometry.Freeze();
            return geometry;
        }

        public static Point ComputeCartesianCoordinate(double angle, double radius)
        {
            double angleRad = (Math.PI / 180.0) * (angle - 90);

            double x = radius * Math.Cos(angleRad);
            double y = radius * Math.Sin(angleRad);

            return new Point(x, y);
        }

        private void DrawGeometry(StreamGeometryContext context)
        {
            Point startPoint = new Point(this.CentreX, this.CentreY);

            Point innerArcStartPoint = PiePiece.ComputeCartesianCoordinate(this.RotationAngle, this.InnerRadius);
            innerArcStartPoint.Offset(this.CentreX, this.CentreY);

            Point innerArcEndPoint = PiePiece.ComputeCartesianCoordinate(this.RotationAngle + this.WedgeAngle, this.InnerRadius);
            innerArcEndPoint.Offset(this.CentreX, this.CentreY);

            Point outerArcStartPoint = PiePiece.ComputeCartesianCoordinate(this.RotationAngle, this.Radius);
            outerArcStartPoint.Offset(this.CentreX, this.CentreY);

            Point outerArcEndPoint = PiePiece.ComputeCartesianCoordinate(this.RotationAngle + this.WedgeAngle, this.Radius);
            outerArcEndPoint.Offset(this.CentreX, this.CentreY);

            bool largeArc = WedgeAngle > 180.0;

            if (this.PushOut > 0)
            {
                Point offset = PiePiece.ComputeCartesianCoordinate(this.RotationAngle + this.WedgeAngle / 2, this.PushOut);
                innerArcStartPoint.Offset(offset.X, offset.Y);
                innerArcEndPoint.Offset(offset.X, offset.Y);
                outerArcStartPoint.Offset(offset.X, offset.Y);
                outerArcEndPoint.Offset(offset.X, offset.Y);
            }

            Size outerArcSize = new Size(this.Radius, this.Radius);
            Size innerArcSize = new Size(this.InnerRadius, this.InnerRadius);

            context.BeginFigure(innerArcStartPoint, true, true);
            context.LineTo(outerArcStartPoint, true, true);
            context.ArcTo(outerArcEndPoint, outerArcSize, 0, largeArc, SweepDirection.Clockwise, true, true);
            context.LineTo(innerArcEndPoint, true, true);
            context.ArcTo(innerArcStartPoint, innerArcSize, 0, largeArc, SweepDirection.Counterclockwise, true, true);
        }

        #endregion
    }
}
