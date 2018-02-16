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
        //this allows you to have lines that are thicker than a single pixel
        //SFML lines are thin
        public void Update(Vector2f point1, Vector2f point2)
        {
            Vector2f direction = point2 - point1;
            float fac = (float)Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);
            Vector2f unitDirection = new Vector2f(direction.X / fac, direction.Y / fac);
            Vector2f unitPerpendicular = new Vector2f(-unitDirection.Y, unitDirection.X);

            Vector2f offset = (Thickness / 2f) * unitPerpendicular;

            vertices[0].Position = point1 + offset;
            vertices[1].Position = point2 + offset;
            vertices[2].Position = point2 - offset;
            vertices[3].Position = point1 - offset;

            for (int i = 0; i < 4; ++i)
                vertices[i].Color = Color;
        }
        public ThickLine(Vector2f point1, Vector2f point2, Color color, float thickness)
        {
            Color = color;
            Thickness = thickness;
            Init();
            Update(point1, point2);
        }
        public ThickLine() { }

        public void Init()
        {

        }
        public ThickLine(Vector2f[] points, Color color, float thickness)
        {
            Init();
            if (points.Length != 4)
            {
                throw new Exception("We shouldn't have a line with not 4 vertices");
            }
            for (int i = 0; i < points.Length; i++)
            {
                vertices[i].Position = points[i];
                vertices[i].Color = color;
            }
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            //states.Texture = tex;
            target.Draw(vertices, PrimitiveType.Quads, states);
        }

        Vertex[] vertices = new Vertex[4];
        public Color Color;
        public float Thickness;
    }
}
