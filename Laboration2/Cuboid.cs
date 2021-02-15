using System;
using System.Numerics;

namespace Laboration2
{
    public class Cuboid : Shape3D
    {
        //Auto-Implemented Properties
        public override float Area { get; }
        public override Vector3 Center { get; }
        public override float Volume { get; }
        public Vector3 Size { get; }
        public bool IsCube { get; }

        //Constructors
        public Cuboid(Vector3 center, Vector3 size)
        {
            Center = center;
            Size = size;
            Area = 2 * (Size.Z * Size.X + Size.X * Size.Y + Size.Y * Size.Z);
            Volume = Size.X * Size.Y * Size.Z;
            IsCube = Size.X == Size.Y && Size.Y == Size.Z;
        }
        public Cuboid(Vector3 center, float width)
        {
            Center = center;
            Size = new Vector3(width);
            Area = 2 * (Size.Z * Size.X + Size.X * Size.Y + Size.Y * Size.Z);
            Volume = Size.X * Size.Y * Size.Z;
            IsCube = Size.X == Size.Y && Size.Y == Size.Z;
        }
        //Methods
        public override string ToString()
        {
            if (!IsCube)
            {
                return String.Format("cuboid @({0:0.0}, {1:0.0}, {2:0.0}): w = {3:0.0}, h = {4:0.0}, l = {5:0.0}",
                    Center.X, Center.Y, Center.Z, Size.X, Size.Y, Size.Z);
            }
            else
            {
                return String.Format("cube @({0:0.0}, {1:0.0}, {2:0.0}): w = {3:0.0}, h = {4:0.0}, l = {5:0.0}",
                    Center.X, Center.Y, Center.Z, Size.X, Size.Y, Size.Z);
            }
        }
    }
}
