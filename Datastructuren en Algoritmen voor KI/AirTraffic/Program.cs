using System;
using System.Collections.Generic;
using System.Linq;

namespace AirTraffic
{
    class Point
    {
        public int X;
        public int Y;
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    class SortX : IComparer<Point>
    {
        public int Compare(Point a, Point b)
        {
            return a.X - b.X;
        }
    }

    class SortY : IComparer<Point>
    {
        public int Compare(Point a, Point b)
        {
            return a.Y - b.Y;
        }
    }
    class AirTraffic
    {
        static void Main()
        {
            string quan_airplanes = Console.ReadLine();
            quan_airplanes = quan_airplanes.Trim();
            string[] arr1 = quan_airplanes.Split();
            int n = int.Parse(arr1[0]);

            Point[] points = new Point[n];
            for (int i = 0; i < n; i++)
            {
                string coord = Console.ReadLine();
                coord = coord.Trim();
                string[] arr2 = coord.Split();
                int px = int.Parse(arr2[0]);
                int py = int.Parse(arr2[1]);
                Point airplane = new Point(px, py);
                points[i] = airplane;
            }

            Array.Sort(points, new SortX());
            Console.WriteLine(Recursion(points, 0, points.Length - 1));
        }

        static float CalcDistance(Point p1, Point p2)
        {
            return (float)(Math.Pow(Math.Abs(p1.X - p2.X), 2) + Math.Pow(Math.Abs(p1.Y - p2.Y), 2));
        }

        static float Recursion(Point[] points, int startIndex, int endIndex)
        {
            if (startIndex == endIndex)
                return float.MaxValue;

            else
            {
                int midIndex = (startIndex + endIndex) / 2;

                float deltaLeft = Recursion(points, startIndex, midIndex);
                float deltaRight = Recursion(points, midIndex + 1, endIndex);

                float deltaMin;
                if (deltaLeft <= deltaRight)
                    deltaMin = deltaLeft;
                else
                    deltaMin = deltaRight;

                /*List<Point> pointsByYList = new List<Point>();
                List<Point> pointsList = points.ToList();
                pointsByYList.AddRange(from Point p in pointsList.GetRange(startIndex, endIndex - startIndex) select p);
                Point[] pointsByY = pointsByYList.ToArray();
                Array.Sort(pointsByY, new SortY());*/

                int length = endIndex - startIndex + 1;
                Point[] pointsByY = new Point[length];
                Array.Copy(points, startIndex, pointsByY, 0, length);
                Array.Sort(pointsByY, new SortY());

                Point[] middlePoints = pointsByY.Where(point => Math.Abs(points[midIndex].X - point.X) <= deltaMin).ToArray();
                for (int i = 0; i < middlePoints.Length; i++)
                {
                    for (int j = 1; j < 16 && j + i < middlePoints.Length; j++)
                    {
                        float dist = CalcDistance(middlePoints[i], middlePoints[i + j]);
                        if (dist < deltaMin)
                        {
                            deltaMin = dist;
                        }
                    }
                }
                return deltaMin;
            }
        }
    }
}