using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Force_Directed_Maps
{
    public class ThickLine : Drawable
    {
        //this drawable class allows you to have lines that are thicker than a single pixel
        //SFML lines are thin (1 pixel) by default
        
        public ThickLine(Vector2f point1, Vector2f point2, Color color, float thickness)
        {
            Color = color;
            Thickness = thickness;
            Update(point1, point2);
        }

        public ThickLine() { }

        public ThickLine(Vector2f[] points, Color color, float thickness)
        {
            for (int i = 0; i < points.Length; i++)
            {
                vertex[i].Position = points[i];
                vertex[i].Color = color;
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(vertex, PrimitiveType.Quads, states);
        }

        Vertex[] vertex = new Vertex[4];
        public Color Color;
        public float Thickness;
        public void Update(Vector2f point1, Vector2f point2)

        {
            Vector2f direction = point2 - point1;
            float fac = (float)Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);
            Vector2f Parallel = new Vector2f(direction.X / fac, direction.Y / fac);
            Vector2f Perp = new Vector2f(-Parallel.Y, Parallel.X);
            Vector2f offset = (Thickness / 2f) * Perp;
            vertex[0].Position = point1 + offset;
            vertex[1].Position = point2 + offset;
            vertex[2].Position = point2 - offset;
            vertex[3].Position = point1 - offset;
            for (int i = 0; i < 4; ++i) vertex[i].Color = Color;
        }
    }
}
