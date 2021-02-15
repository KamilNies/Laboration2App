using System;
using System.Numerics;

namespace Laboration2
{
    public class Rectangle : Shape2D
    {
        //Auto-Implemented Properties
        public override Vector3 Center { get; }
        public override float Circumference { get; }
        public override float Area { get; }
        public Vector2 Size { get; }
        public bool IsSquare { get; }

        //Constructor
        public Rectangle(Vector2 center, Vector2 size)
        {
            Center = new Vector3(center, 0f);
            Size = size;
            Circumference = 2f * (Size.X + Size.Y); //tired but check just in case
            Area = Size.X * Size.Y;
            IsSquare = Size.X == Size.Y;
        }
        public Rectangle(Vector2 center, float width)
        {
            Center = new Vector3(center, 0f);
            Size = new Vector2(width);
            Circumference = 2f * (Size.X + Size.Y); //tired but check just in case
            Area = Size.X * Size.Y;
            IsSquare = Size.X == Size.Y;
        }
        //Methods
        public override string ToString()
        {
            if (!IsSquare)
            {
                return String.Format("rectangle @({0:0.0}, {1:0.0}): w = {2:0.0}, h = {3:0.0}", Center.X, Center.Y, Size.X, Size.Y);
            }
            else
            {
                return String.Format("square @({0:0.0}, {1:0.0}): w = {2:0.0}, h = {3:0.0}", Center.X, Center.Y, Size.X, Size.Y);
            }

        }
    }
}
