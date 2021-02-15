using System;
using System.Numerics;

namespace Laboration2
{
    public class Circle : Shape2D
    {
        //Auto-Implemented Properties
        public override Vector3 Center { get; }
        public override float Circumference { get; }
        public override float Area { get; }
        public float Radius { get; }

        //Constructors
        public Circle(Vector2 center, float radius)
        {
            Center = new Vector3(center, 0f);
            Radius = radius;
            Circumference = 2f * (float)Math.PI * radius;
            Area = (float)Math.PI * radius * radius;
        }
        //Methods
        public override string ToString()
        {
            return String.Format("circle @({0:0.0}, {1:0.0}): r = {2:0.0}", Center.X, Center.Y, Radius);
        }
    }
}
