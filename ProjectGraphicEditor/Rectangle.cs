using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrapicsEditor;
using GdiGraphicsEditor;

namespace ProjectGraphicEditor
{
    class Rectangle : IFigureshape
    {
        public float X, Y, Width, Height;
        public int OutLineColor, FillColor;

        public void DrawOn(IRenderer g)
        {
            g.DrawRectangle(X, Y, Width, Height, OutLineColor, FillColor);

        }

        public bool Intersects(float x, float y, float eps)
        {
            return x + eps >= X
                && y + eps >= Y
                && x - eps <= X + Width
                && y - eps <= Y + Height;
        }

         public void MoveBy(float dx, float dy)
        {
            X += dx;
            Y += dy;
        }

        public override string ToString()
        {
            return $"0 {X} {Y} {Width} {Height} {OutLineColor} {FillColor}";
        }
    }

    class RectangleMove:IMouse
    {
        bool active;
        Sheet sheet;
        IPalitra palitra;
        Rectangle r;
        float StartX, StartY;

        public RectangleMove(IPalitra pali, Sheet s)
        {
            sheet = s;
            palitra = pali;
        }

        public void MouseDownHandler(float x, float y)
        {

            StartX = x;
            StartY = y;
            active = true;
            r = new Rectangle()
            {
                X = x,
                Y = y,
                Width = 0,
                Height = 0,
                FillColor = palitra.SecondaryColor,
                OutLineColor = palitra.MainColor
            };
            sheet.Add(r);
        }

        public void MouseMoveHandler(float x, float y)
        {
            if (active != false)
            {
                float xMin = Math.Min(StartX, x);
                float yMin = Math.Min(StartY, y);
                float xMax = Math.Max(StartX, x);
                float yMax = Math.Max(StartY, y);
                r.X = xMin;
                r.Y = yMin;
                r.Width = xMax - xMin;
                r.Height = yMax - yMin;
                palitra.Invalidate();
            }
        }

        public void MouseUpHandler(float x, float y)
        {
            active = false;
            palitra.Invalidate();
        }
    }

}
