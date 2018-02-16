using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Force_Directed_Maps
{
    public class Vector
    {
        private float X;
        private float Y;

        public Vector(float x, float y)
        {
            X = x;
            Y = y;
        }
        public Vector()
        {
            X = 0;
            Y = 0;
        }
        public double Mag()
        {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }
        public static implicit operator Vector(float d)
        {
            return new Vector(d, d);
        }
        public static bool IsNegligible(Vector a)
        {
            if (a.X < Globals.STOP_CONDITION && a.Y < Globals.STOP_CONDITION) return true;
            else return false;
        }

        #region Public Fields
        public float Ycomp
        {
            get { return Y; }
            set { Y = value; }
        }
        public float Xcomp
        {
            get { return X; }
            set { X = value; }
        }
        public string StringFormat()
        {
            return (Math.Round(X, 2) + ", " + Math.Round(Y, 2));
        }
        #endregion

        #region Operators
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }
        public static Vector operator *(Vector a, float k)
        {
            return new Vector(a.X * k, a.Y * k);
        }
        public static Vector operator *(Vector a, double k)
        {
            return new Vector(a.X * (float)k, a.Y * (float)k);
        }
        public static Vector operator /(Vector a, double k)
        {
            return new Vector(a.X / (float)k, a.Y / (float)k);
        }
        public static Vector operator ^(Vector a, int b)
        {
            Vector r = new Vector((float)Math.Pow(a.X, b), (float)Math.Pow(a.Y, b));
            if (a.X < 0) r.X *= -1;
            if (a.Y < 0) r.Y *= -1;
            return r;
        }
        //public static implicit operator Vector(Vector2f a)
        //{
        //    return new Vector(a.X, a.Y);
        //}
        public static explicit operator Vector(Vector2f a)
        {
            return new Vector(a.X, a.Y);
        }
        public static explicit operator Vector2f(Vector a)
        {
            return new Vector2f(a.X, a.Y);
        }
        #endregion
    }
}
