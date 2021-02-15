using System;
using System.Numerics;

namespace Laboration2
{
    public abstract class Shape
    {
        //Fields
        private static readonly Random rng = new Random();

        //Abstract properties
        public abstract Vector3 Center { get; }
        public abstract float Area { get; }

        //Methods
        public static Shape GenerateShape()
        {
            switch (rng.Next(7))
            {
                case 0:
                    return GenerateRandomCircle();
                case 1:
                    return GenerateRandomRectangle();
                case 2:
                    return GenerateRandomSquare();
                case 3:
                    return GenerateRandomTriangle();
                case 4:
                    return GenerateRandomCuboid();
                case 5:
                    return GenerateRandomCube();
                case 6:
                    return GenerateRandomSphere();
                default:
                    return null;
            }
        }
        public static Shape GenerateShape(Vector3 center)
        {
            switch (rng.Next(7))
            {
                case 0:
                    return GenerateCircle(center);
                case 1:
                    return GenerateRectangle(center);
                case 2:
                    return GenerateSquare(center);
                case 3:
                    return GenerateTriangle(center);
                case 4:
                    return GenerateCuboid(center);
                case 5:
                    return GenerateCube(center);
                case 6:
                    return GenerateSphere(center);
                default:
                    return null;
            }
        }
        private static Circle GenerateRandomCircle()
        {
            return new Circle(new Vector2(rng.Next(-100, 101), rng.Next(-100, 101)), rng.Next(1, 11));
        }
        private static Circle GenerateCircle(Vector3 center)
        {
            return new Circle(new Vector2(center.X, center.Y), rng.Next(1, 11));
        }
        private static Rectangle GenerateRandomRectangle()
        {
            var rectangle = new Rectangle(new Vector2(rng.Next(-100, 101), rng.Next(-100, 101)), new Vector2(rng.Next(1, 21), rng.Next(1, 21)));
            while (rectangle.IsSquare)
            {
                rectangle = new Rectangle(new Vector2(rng.Next(-100, 101), rng.Next(-100, 101)), new Vector2(rng.Next(1, 21), rng.Next(1, 21)));
            }
            return rectangle;
        }
        private static Rectangle GenerateRectangle(Vector3 center)
        {
            var rectangle = new Rectangle(new Vector2(center.X, center.Y), new Vector2(rng.Next(1, 21), rng.Next(1, 21)));
            while (rectangle.IsSquare)
            {
                rectangle = new Rectangle(new Vector2(center.X, center.Y), new Vector2(rng.Next(1, 21), rng.Next(1, 21)));
            }
            return rectangle;
        }
        private static Rectangle GenerateRandomSquare()
        {
            return new Rectangle(new Vector2(rng.Next(-100, 101), rng.Next(-100, 101)), rng.Next(1, 21));
        }
        private static Rectangle GenerateSquare(Vector3 center)
        {
            return new Rectangle(new Vector2(center.X, center.Y), rng.Next(1, 21));
        }
        private static Triangle GenerateRandomTriangle()
        {
            return new Triangle(new Vector2(rng.Next(-100, 101), rng.Next(-100, 101)),
                new Vector2(rng.Next(-100, 101), rng.Next(-100, 101)),
                new Vector2(rng.Next(-100, 101), rng.Next(-100, 101)));
        }
        private static Triangle GenerateTriangle(Vector3 center)
        {
            return new Triangle(new Vector2(rng.Next(-100, 101), rng.Next(-100, 101)),
                new Vector2(rng.Next(-100, 101), rng.Next(-100, 101)), center);
        }
        private static Cuboid GenerateRandomCuboid()
        {
            var cuboid = new Cuboid(new Vector3(rng.Next(-100, 101), rng.Next(-100, 101), rng.Next(-100, 101)),
                new Vector3(rng.Next(1, 21), rng.Next(1, 21), rng.Next(1, 21)));
            while (cuboid.IsCube)
            {
                cuboid = new Cuboid(new Vector3(rng.Next(-100, 101), rng.Next(-100, 101), rng.Next(-100, 101)),
                    new Vector3(rng.Next(1, 21), rng.Next(1, 21), rng.Next(1, 21)));
            }
            return cuboid;
        }
        private static Cuboid GenerateCuboid(Vector3 center)
        {
            var cuboid = new Cuboid(center, new Vector3(rng.Next(1, 21), rng.Next(1, 21), rng.Next(1, 21)));
            while (cuboid.IsCube)
            {
                cuboid = new Cuboid(center, new Vector3(rng.Next(1, 21), rng.Next(1, 21), rng.Next(1, 21)));
            }
            return cuboid;
        }
        private static Cuboid GenerateRandomCube()
        {
            return new Cuboid(new Vector3(rng.Next(-100, 101), rng.Next(-100, 101), rng.Next(-100, 101)), rng.Next(1, 21));
        }
        private static Cuboid GenerateCube(Vector3 center)
        {
            return new Cuboid(center, rng.Next(1, 21));
        }
        private static Sphere GenerateRandomSphere()
        {
            return new Sphere(new Vector3(rng.Next(-100, 101), rng.Next(-100, 101), rng.Next(-100, 101)), rng.Next(1, 11));
        }
        private static Sphere GenerateSphere(Vector3 center)
        {
            return new Sphere(center, rng.Next(1, 11));
        }
    }
}
