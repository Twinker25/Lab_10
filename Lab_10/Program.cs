using System.Runtime.CompilerServices;

namespace Lab_10
{
    class Point3D
    {
        public double X;
        public double Y;
        public double Z;
        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public double DistancePoint(Point3D p)
        {
            double dx = X - p.X;
            double dy = Y - p.Y;
            double dz = Z - p.Z;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }
    }

    class Program
    {
        public delegate void Distance(Point3D point1, Point3D point2, double distance);

        public static event Distance MaxDistance;

        static void Main(string[] args)
        {
            Point3D[] points = new Point3D[3]
            {
                new Point3D(1, 2, 3),
                new Point3D(3, 2, 1),
                new Point3D(4, 5, 6),
            };

            double maxDistance = 0;
            Point3D maxDistancePoint1 = null;
            Point3D maxDistancePoint2 = null;

            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    double distance = points[i].DistancePoint(points[j]);
                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                        maxDistancePoint1 = points[i];
                        maxDistancePoint2 = points[j];
                    }
                }
            }

            MaxDistance?.Invoke(maxDistancePoint1, maxDistancePoint2, maxDistance);

            Console.WriteLine($"Max distance: {maxDistance}");
            Console.WriteLine($"Point 1: ({maxDistancePoint1.X}, {maxDistancePoint1.Y}, {maxDistancePoint1.Z})");
            Console.WriteLine($"Point 2: ({maxDistancePoint2.X}, {maxDistancePoint2.Y}, {maxDistancePoint2.Z})");
        }
    }
}