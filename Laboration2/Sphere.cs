using System;
using System.Numerics;

namespace Laboration2
{
    public class Sphere : Shape3D
    {
        //Auto-Implemented Properties
        public override float Area { get; }
        public override Vector3 Center { get; }
        public override float Volume { get; }
        public float Radius { get; }

        //Constructors
        public Sphere(Vector3 center, float radius)
        {
            Center = center;
            Radius = radius;
            Area = 4f * (float)Math.PI * radius * radius;
            Volume = 4f * (float)Math.PI * radius * radius * radius / 3f;
        }
        //Methods
        public override string ToString()
        {
            return String.Format("sphere @({0:0.0}, {1:0.0}, {2:0.0}): r = {3:0.0}",
                Center.X, Center.Y, Center.Z, Radius);
        }
    }
}
