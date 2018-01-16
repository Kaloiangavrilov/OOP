using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GdiGraphicsEditor;
using GrapicsEditor;

namespace ProjectGraphicEditor
{
    class Circle : IFigureshape
    {
        public float X, Y, Width;
        public int OutLineColor, FillColor;
        
        public void DrawOn(IRenderer r)
        {
            r.DrawCircle(X, Y, Width, OutLineColor, FillColor);
        }

        public bool Intersects(float x, float y, float eps)
        {
            return x + eps >= X
                && y + eps >= Y
                && x - eps <= X + Width
                && y - eps <= Y + Width;
        }

        public void MoveBy(float dx, float dy)
        {
            X += dx;
            Y += dy;
        }

        public override string ToString()
        {
            return $"1 {X} {Y} {Width} {OutLineColor} {FillColor}";
        }
    }

    class CircleMove : IMouse
    {
        bool active;
        Sheet sheet;
        IPalitra palitra;
        Circle c;
        float StartX, StartY;

        public CircleMove(IPalitra pali, Sheet s)
        {
            sheet = s;
            palitra = pali;
        }

        public void MouseDownHandler(float x, float y)
        {
            StartX = x;
            StartY = y;
            active = true;
            c = new Circle()
            {
                X = x,
                Y = y,
                Width = 0,
                FillColor = palitra.SecondaryColor,
                OutLineColor = palitra.MainColor
            };
            sheet.Add(c);
        }

        public void MouseMoveHandler(float x, float y)
        {
            if (active != false)
            {
                float xMin = Math.Min(StartX, x);
                float yMin = Math.Min(StartY, y);
                float xMax = Math.Max(StartX, x);
                float yMax = Math.Max(StartY, y);
                c.X = xMin;
                c.Y = yMin;
                c.Width = xMax - xMin;
                palitra.Invalidate();
            }
        }
    
        public void MouseUpHandler(float x, float y)
        {
            float xMin = Math.Min(StartX, x);
            float yMin = Math.Min(StartY, y);
            float xMax = Math.Max(StartX, x);
            float yMax = Math.Max(StartY, y);           
            c.Width = xMax - xMin;
            palitra.Invalidate();

            active = false;
            palitra.Invalidate();
        }
    }
}
