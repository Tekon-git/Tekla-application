using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace GridBuilder.Models
{
    public class VisualGridModel
    {
        // Definicja siatki geometrii
        private GeometryGroup geometry = new GeometryGroup();
        private List<string> listMarkX = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8" };
        private List<string> listMarkY = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H" };
        private List<string> listMarkZ= new List<string>() { "0,000"};

   
        private List<(int,double)> listStepsX = new List<(int, double)>() { (1, 0.0), (3, 6000.0)};
        private List<(int, double)> listStepsY = new List<(int, double)>() { (1, 0.0), (1, 6000.0)};
        private List<double> listStepsZ = new List<double>() { 0.0 };
        private Point offset = new Point(0,0);
        private double scaleX = 1;
        private double scaleY = 1;

        public List<Point> CrossPoint
        {
            get
            {
                return FindCrossPoints();
            }
         
        }

        public GeometryGroup Geometry
        {
            get
            {
                return geometry;
            }
            set
            {
                geometry = value;
                
            }
        }

        public List<string> ListMarkX
        {
            get
            {
                return listMarkX;
            }
            set
            {
                listMarkX = value;
                UpdateGeometry();
            }
        }

        public List<string> ListMarkY
        {
            get
            {
                return listMarkY;
            }
            set
            {
                listMarkY = value;
                UpdateGeometry();
            }
        }

        public List<string> ListMarkZ
        {
            get
            {
                return listMarkZ;
            }
            set
            {
                listMarkZ = value;
                UpdateGeometry();
            }
        }

        public List<(int, double)> ListStepsX
        {
            get
            {
                return listStepsX;
            }
            set
            {
                listStepsX = value;
                UpdateGeometry();
            }
        }

        public List<(int, double)> ListStepsY
        {
            get
            {
                return listStepsY;
            }
            set
            {
                listStepsY = value;
                UpdateGeometry();
            }
        }

        public List<double> ListStepsZ
        {
            get
            {
                return listStepsZ;
            }
            set
            {
                listStepsZ = value;
                UpdateGeometry();
            }
        }

        private void UpdateGeometry()
        {
            Draw();
        }

        public GeometryGroup Draw()
        {
            FindCrossPoints();
            double maxX = CrossPoint.Max(p => p.X);
            double maxY = CrossPoint.Max(p => p.Y);
            Geometry.Children.Clear();
            GeometryGroup geometryGroupX = new GeometryGroup();
            GeometryGroup geometryGroupY = new GeometryGroup();
            if (listStepsX.Count > 0)
            {
                foreach (LineGeometry lg in CreateLinesFromList(ListStepsX, maxY, true))
                {
                    geometryGroupX.Children.Add(lg);
                }
            }

            Geometry.Children.Add(geometryGroupX);

            if (listStepsY.Count > 0)
            {
                foreach (LineGeometry lg in CreateLinesFromList(ListStepsY, maxX, false))
                {
                    geometryGroupY.Children.Add(lg);
                }
            }

            Geometry.Children.Add(geometryGroupY);

            TransformGroup transformGroup = new TransformGroup();
            transformGroup.Children.Add(new ScaleTransform(scaleX, scaleY));
            transformGroup.Children.Add(new TranslateTransform(offset.X / 2, offset.Y / 2));
            Geometry.Children[0].Transform = transformGroup;
            Geometry.Children[1].Transform = transformGroup;

            Geometry.Children.Add(AddMarks(Geometry.Children[0] as GeometryGroup, transformGroup, true));
            Geometry.Children.Add(AddMarks(Geometry.Children[1] as GeometryGroup, transformGroup, false));

            return Geometry;

        }

        

        private Geometry AddMarks(GeometryGroup geometryGroup, TransformGroup transformGroup, bool isXAxis)
        {
            GeometryGroup marks = new GeometryGroup();
            int markCount = 0;
            var reverseList = ListMarkY.Select(x => x).ToList();
            reverseList.Reverse(0, geometryGroup.Children.Count);
            foreach (LineGeometry lg in geometryGroup.Children)
            {
                Point sP = transformGroup.Transform(lg.StartPoint);

                if (isXAxis)
                {
                    EllipseGeometry eg = new EllipseGeometry(new Point(sP.X, sP.Y - 25), 15, 15);
                    marks.Children.Add(eg);
                    LineGeometry line = new LineGeometry(sP, new Point(sP.X, sP.Y - 10));
                    marks.Children.Add(line);
                    string mark = ListMarkX[markCount];
                    if (string.IsNullOrEmpty(mark))
                    {
                        mark = string.Empty;
                    }
                    FormattedText ft = new FormattedText(mark, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"),
                        20, Brushes.Red, VisualTreeHelper.GetDpi(Application.Current.MainWindow).PixelsPerDip);

                    marks.Children.Add(ft.BuildGeometry(new Point(sP.X - 5, sP.Y - 35)));

                }
                else
                {
                    EllipseGeometry eg = new EllipseGeometry(new Point(sP.X - 25, sP.Y), 15, 15);
                    marks.Children.Add(eg);
                    LineGeometry line = new LineGeometry(sP, new Point(sP.X - 10, sP.Y));
                    marks.Children.Add(line);

                    string mark = reverseList[markCount];
                    if (string.IsNullOrEmpty(mark))
                    {
                        mark = string.Empty;
                    }
                    FormattedText ft = new FormattedText(mark, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"),
                        16, Brushes.Red, VisualTreeHelper.GetDpi(Application.Current.MainWindow).PixelsPerDip);

                    marks.Children.Add(ft.BuildGeometry(new Point(sP.X - 30, sP.Y - 10)));
                }

                markCount++;
            }
            return marks;

        }

        private List<LineGeometry> CreateLinesFromList(List<(int, double)> list, double length, bool isXAxis)
        {
            List<LineGeometry> lineGeometries = new List<LineGeometry>();
            double lastCoordinate = 0;
            for (int i = 0; i < list.Count; i++)
            {
                for (int s = 0; s < list[i].Item1; s++)
                {
                    lastCoordinate += list[i].Item2;
                    LineGeometry lineGeometry = new LineGeometry();
                    if (isXAxis)
                    {
                        lineGeometry.StartPoint = new Point(lastCoordinate, 0);
                        lineGeometry.EndPoint = new Point(lastCoordinate, length);
                        lineGeometries.Add(lineGeometry);
                    }
                    else
                    {
                        lineGeometry.StartPoint = new Point(0, lastCoordinate);
                        lineGeometry.EndPoint = new Point(length, lastCoordinate);
                        lineGeometries.Add(lineGeometry);
                    }
                }
            }
            return lineGeometries;
        }

        private List<Point> FindCrossPoints()
        {
            List<Point> joinList = new List<Point>();
            List<double> coordinateX = TransformToDouble(ListStepsX);
            List<double> coordinateY = TransformToDouble(ListStepsY);
            joinList = coordinateX.SelectMany(x => coordinateY, (x, y) => new Point(x, y)).ToList();
            return joinList;
        }

        private List<double> TransformToDouble(List<(int, double)> list)
        {
            List<double> transformList = new List<double>();
            double lastCoordinate = 0;
            for (int i = 0; i < list.Count; i++)
            {
                for (int c = 0; c < list[i].Item1; c++)
                {
                    lastCoordinate += list[i].Item2;
                    transformList.Add(lastCoordinate);
                }
            }
            return transformList;
        }
        internal void SetTransform(double width, double height)
        {
            offset.X = ((width - (width * 0.5)) / 2);
            offset.Y = ((height - (height * 0.5)) / 2);
            double lengthX = width * 0.5 + offset.X;
            double lengthY = height * 0.5 + offset.Y;
            double maxX = CrossPoint.Max(p => p.X);
            double maxY = CrossPoint.Max(p => p.Y);
            if (maxX != 0)
                scaleX = lengthX / maxX;
            if (maxY != 0)
                scaleY = lengthY / maxY;

            UpdateGeometry();


        }

    }
}