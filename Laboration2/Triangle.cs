using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Laboration2
{
    public class Triangle : Shape2D, IEnumerable, IEnumerator
    {
        //Field
        int position = -1;

        //Auto-Implemented Properties
        public override Vector3 Center { get; }
        public override float Circumference { get; }
        public override float Area { get; }
        public Vector2 P1 { get; }
        public Vector2 P2 { get; }
        public Vector2 P3 { get; }

        //IEnumerable, IEnumerator
        private Vector2[] VectorArray;
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Vector2 Current
        {
            get
            {
                try
                {
                    return VectorArray[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        //Constructor
        public Triangle(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            VectorArray = new Vector2[] { p1, p2, p3 };
            Center = new Vector3(new Vector2(((P1.X + P2.X + P3.X) / 3f), ((P1.Y + P2.Y + P3.Y) / 3f)), 0f);
            Circumference = Vector2.Distance(P1, P2) + Vector2.Distance(P2, P3) + Vector2.Distance(P3, P1);
            Area = Math.Abs((P1.X * (P2.Y - P3.Y) + P2.X * (P3.Y - P1.Y) + P3.X * (P1.Y - P2.Y)) / 2f);
        }

        public Triangle(Vector2 p1, Vector2 p2, Vector3 center)
        {
            P1 = p1;
            P2 = p2;
            Center = center;
            P3 = new Vector2(3f * Center.X - P1.X - P2.X, 3f * Center.Y - P1.Y - P2.Y);
            Circumference = Vector2.Distance(P1, P2) + Vector2.Distance(P2, P3) + Vector2.Distance(P3, P1);
            Area = Math.Abs((P1.X * (P2.Y - P3.Y) + P2.X * (P3.Y - P1.Y) + P3.X * (P1.Y - P2.Y)) / 2f);
        }

        //Methods
        public override string ToString()
        {
            return String.Format("triangle @({0:0.0}, {1:0.0}): p1({2:0.0}, {3:0.0}), p2({4:0.0}, {5:0.0}), p3({6:0.0}, {7:0.0})",
                Center.X, Center.Y, P1.X, P1.Y, P2.X, P2.Y, P3.X, P3.Y);
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable<Vector2>)VectorArray).GetEnumerator();
        }

        public bool MoveNext()
        {
            position++;
            return (position < VectorArray.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
