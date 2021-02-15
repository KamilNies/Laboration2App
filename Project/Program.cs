using Laboration2;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            bool unflagged = true;
            while (unflagged)
            {
                byte option = 0;
                Console.WriteLine(new string('-', 90));
                Console.WriteLine(new string(' ', 38) + "Available options");
                Console.WriteLine(new string('-', 90));
                Console.WriteLine("\t\t 1.\tGenerate 20 random shapes");
                Console.WriteLine("\t\t 2.\tGenerate 20 random shapes at predefined postions");
                Console.WriteLine("\t\t 3.\tPrint triangle vector2 postions P1, P2, and P3");
                Console.WriteLine("\t\t 4.\tExit console");
                Console.WriteLine(new string('-', 90));
                Console.Write("Select option: ");
                bool parsed = false;
                do
                {
                    parsed = byte.TryParse(Console.ReadLine(), out option);
                    if (!parsed || (option! > 4 ^ option! < 1))
                    {
                        Console.Write("Invalid option. Select new option: ");
                    }
                } while (!parsed || (option! > 4 ^ option! < 1));
                Console.WriteLine(new string('-', 90));
                switch (option)
                {
                    case 1:
                        Generate20RandomShapes();
                        break;
                    case 2:
                        Generate20RandomShapesAtFixedPositions();
                        break;
                    case 3:
                        TriangleVectorPositions();
                        break;
                    case 4:
                        unflagged = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private static void Generate20RandomShapes()
        {
            Console.WriteLine(new string(' ', 33) + "Generating 20 random shapes");
            Console.WriteLine(new string('-', 90));
            float circumference = 0, totalArea = 0, maxVolume = 0;
            int numberOfShapes = 20;
            var shapes = new List<Shape>();
            var bigShapes = new List<Shape3D>();
            var bigShapeVolume = new List<float>();
            shapes.Clear();
            bigShapes.Clear();
            bigShapeVolume.Clear();
            for (int i = 0; i < numberOfShapes; i++)
            {
                shapes.Add(Shape.GenerateShape());
            }
            foreach (var shape in shapes)
            {
                totalArea += shape.Area;
                if (shape is Triangle)
                {
                    var triangle = shape as Triangle;
                    circumference += triangle.Circumference;
                    Console.WriteLine(triangle);
                }
                else if (shape is Shape3D)
                {
                    if (shape is Cuboid)
                    {
                        var cuboid = shape as Cuboid;
                        if (cuboid.Volume > maxVolume)
                        {
                            maxVolume = cuboid.Volume;
                            bigShapeVolume.Add(cuboid.Volume);
                            bigShapes.Add(cuboid);
                        }
                        Console.WriteLine(cuboid);
                    }
                    if (shape is Sphere)
                    {
                        var sphere = shape as Sphere;
                        if (sphere.Volume > maxVolume)
                        {
                            maxVolume = sphere.Volume;
                            bigShapeVolume.Add(sphere.Volume);
                            bigShapes.Add(sphere);
                        }
                        Console.WriteLine(sphere);
                    }
                }
                else
                {
                    Console.WriteLine(shape);
                }
            }
            Console.WriteLine(new string('-', 90));
            Console.WriteLine("Total circumference for all triangle shapes: {0:0.0}", circumference);
            Console.WriteLine(new string('-', 90));
            Console.WriteLine("Average area for all shape objects: {0:0.0}", totalArea / numberOfShapes);
            Console.WriteLine(new string('-', 90));
            if (bigShapes.Count == 0)
            {
                Console.WriteLine("Largest 3D Shape: \"No 3D Shapes were generated this run.\"");
            }
            else
            {
                Console.WriteLine("Largest 3D Shape: {0}", bigShapes[bigShapes.Count - 1]);
                Console.WriteLine("Volume of the largest 3D Shape: {0:0.0}", maxVolume);
            }
            Console.WriteLine(new string('-', 90));
            Console.Write("Press any key to continue... ");
            Console.ReadKey();
            Console.WriteLine();
        }
        private static void Generate20RandomShapesAtFixedPositions()
        {
            float xAxis = 0, yAxis = 0, zAxis = 0;
            Console.Write("Input x-coordinate: ");
            bool parsed = false;
            do
            {
                parsed = float.TryParse(Console.ReadLine(), out xAxis);
                if (!parsed || (xAxis! > 100 ^ xAxis! < -100))
                {
                    Console.Write("Invalid input. Input a float between -100 and 100: ");
                }
            } while (!parsed || (xAxis! > 100 ^ xAxis! < -100));
            Console.Write("Input y-coordinate: ");
            parsed = false;
            do
            {
                parsed = float.TryParse(Console.ReadLine(), out yAxis);
                if (!parsed || (yAxis! > 100 ^ yAxis! < -100))
                {
                    Console.Write("Invalid input. Input a float between -100 and 100: ");
                }
            } while (!parsed || (yAxis! > 100 ^ yAxis! < -100));
            Console.Write("Input z-coordinate: ");
            parsed = false;
            do
            {
                parsed = float.TryParse(Console.ReadLine(), out zAxis);
                if (!parsed || (zAxis! > 100 ^ zAxis! < -100))
                {
                    Console.Write("Invalid input. Input a float between -100 and 100: ");
                }
            } while (!parsed || (zAxis! > 100 ^ zAxis! < -100));

            Console.WriteLine(new string('-', 90));
            Console.WriteLine(new string(' ', 20) + "Generating 20 random shapes at predefined positions");
            Console.WriteLine(new string('-', 90));

            float circumference = 0, totalArea = 0, maxVolume = 0;
            int numberOfShapes = 20;
            var shapes = new List<Shape>();
            var bigShapes = new List<Shape3D>();
            var bigShapeVolume = new List<float>();
            shapes.Clear();
            bigShapes.Clear();
            bigShapeVolume.Clear();
            for (int i = 0; i < numberOfShapes; i++)
            {
                shapes.Add(Shape.GenerateShape(new Vector3(xAxis, yAxis, zAxis)));
            }
            foreach (var shape in shapes)
            {
                totalArea += shape.Area;
                if (shape is Triangle)
                {
                    var triangle = shape as Triangle;
                    circumference += triangle.Circumference;
                    Console.WriteLine(triangle);
                }
                else if (shape is Shape3D)
                {
                    if (shape is Cuboid)
                    {
                        var cuboid = shape as Cuboid;
                        if (cuboid.Volume > maxVolume)
                        {
                            maxVolume = cuboid.Volume;
                            bigShapeVolume.Add(cuboid.Volume);
                            bigShapes.Add(cuboid);
                        }
                        Console.WriteLine(cuboid);
                    }
                    if (shape is Sphere)
                    {
                        var sphere = shape as Sphere;
                        if (sphere.Volume > maxVolume)
                        {
                            maxVolume = sphere.Volume;
                            bigShapeVolume.Add(sphere.Volume);
                            bigShapes.Add(sphere);
                        }
                        Console.WriteLine(sphere);
                    }
                }
                else
                {
                    Console.WriteLine(shape);
                }
            }
            Console.WriteLine(new string('-', 90));
            Console.WriteLine("Total circumference for all triangle shapes: {0:0.0}", circumference);
            Console.WriteLine(new string('-', 90));
            Console.WriteLine("Average area for all shape objects: {0:0.0}", totalArea / numberOfShapes);
            Console.WriteLine(new string('-', 90));
            if (bigShapes.Count == 0)
            {
                Console.WriteLine("Largest 3D Shape: \"No 3D Shapes were generated this run.\"");
            }
            else
            {
                Console.WriteLine("Largest 3D Shape: {0}", bigShapes[bigShapes.Count - 1]);
                Console.WriteLine("Volume of the largest 3D Shape: {0:0.0}", maxVolume);
            }
            Console.WriteLine(new string('-', 90));
            Console.Write("Press any key to continue... ");
            Console.ReadKey();
            Console.WriteLine();
        }
        private static void TriangleVectorPositions()
        {
            Console.WriteLine(new string(' ', 38) + "Vector position 1");
            Console.WriteLine(new string('-', 90));
            float xAxisVectorP1 = 0, yAxisVectorP1 = 0;
            Console.Write("Input x-coordinate: ");
            bool parsed = false;
            do
            {
                parsed = float.TryParse(Console.ReadLine(), out xAxisVectorP1);
                if (!parsed || (xAxisVectorP1! > 100 ^ xAxisVectorP1! < -100))
                {
                    Console.Write("Invalid input. Input a float between -100 and 100: ");
                }
            } while (!parsed || (xAxisVectorP1! > 100 ^ xAxisVectorP1! < -100));
            Console.Write("Input y-coordinate: ");
            parsed = false;
            do
            {
                parsed = float.TryParse(Console.ReadLine(), out yAxisVectorP1);
                if (!parsed || (yAxisVectorP1! > 100 ^ yAxisVectorP1! < -100))
                {
                    Console.Write("Invalid input. Input a float between -100 and 100: ");
                }
            } while (!parsed || (yAxisVectorP1! > 100 ^ yAxisVectorP1! < -100));
            Console.WriteLine(new string('-', 90));
            Console.WriteLine(new string(' ', 38) + "Vector position 2");
            Console.WriteLine(new string('-', 90));
            float xAxisVectorP2 = 0, yAxisVectorP2 = 0;
            Console.Write("Input x-coordinate: ");
            parsed = false;
            do
            {
                parsed = float.TryParse(Console.ReadLine(), out xAxisVectorP2);
                if (!parsed || (xAxisVectorP2! > 100 ^ xAxisVectorP2! < -100))
                {
                    Console.Write("Invalid input. Input a float between -100 and 100: ");
                }
            } while (!parsed || (xAxisVectorP2! > 100 ^ xAxisVectorP2! < -100));
            Console.Write("Input y-coordinate: ");
            parsed = false;
            do
            {
                parsed = float.TryParse(Console.ReadLine(), out yAxisVectorP2);
                if (!parsed || (yAxisVectorP2! > 100 ^ yAxisVectorP2! < -100))
                {
                    Console.Write("Invalid input. Input a float between -100 and 100: ");
                }
            } while (!parsed || (yAxisVectorP2! > 100 ^ yAxisVectorP2! < -100));
            Console.WriteLine(new string('-', 90));
            Console.WriteLine(new string(' ', 38) + "Vector position 3");
            Console.WriteLine(new string('-', 90));
            float xAxisVectorP3 = 0, yAxisVectorP3 = 0;
            Console.Write("Input x-coordinate: ");
            parsed = false;
            do
            {
                parsed = float.TryParse(Console.ReadLine(), out xAxisVectorP3);
                if (!parsed || (xAxisVectorP3! > 100 ^ xAxisVectorP3! < -100))
                {
                    Console.Write("Invalid input. Input a float between -100 and 100: ");
                }
            } while (!parsed || (xAxisVectorP3! > 100 ^ xAxisVectorP3! < -100));
            Console.Write("Input y-coordinate: ");
            parsed = false;
            do
            {
                parsed = float.TryParse(Console.ReadLine(), out yAxisVectorP3);
                if (!parsed || (yAxisVectorP3! > 100 ^ yAxisVectorP3! < -100))
                {
                    Console.Write("Invalid input. Input a float between -100 and 100: ");
                }
            } while (!parsed || (yAxisVectorP3! > 100 ^ yAxisVectorP3! < -100));
            Console.WriteLine(new string('-', 90));
            Console.WriteLine(new string(' ', 21) + "Printing triangle vector2 postions P1, P2, and P3");
            Console.WriteLine(new string('-', 90));

            var t = new Triangle(new Vector2(xAxisVectorP1, yAxisVectorP2),
                new Vector2(xAxisVectorP2, yAxisVectorP2),
                new Vector2(xAxisVectorP3, yAxisVectorP3));

            int vectorCounter = 0;
            foreach (Vector2 v in t)
            {
                vectorCounter++;
                Console.WriteLine("P{0}: {1}", vectorCounter, v);
            }
            Console.WriteLine(new string('-', 90));
            Console.Write("Press any key to continue... ");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
