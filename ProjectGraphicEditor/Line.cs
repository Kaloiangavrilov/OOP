using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrapicsEditor;
using GdiGraphicsEditor;

namespace ProjectGraphicEditor
{
    class Line : IFigureshape
    {
        public float X, Y, X1, Y1;
        public int OutLineColor;

        public void DrawOn(IRenderer r)
        {
            r.DrawLine(X, Y, X1, Y1, OutLineColor);
        }

        public bool Intersects(float x, float y, float eps)
        {
            int t = Convert.ToInt32(x);
            int P = Convert.ToInt32(y);
            return x >= X
                && y >= Y
                && x <= X1
                && y <= Y1;
        }

        public void MoveBy(float dx, float dy)
        {
            X += dx;
            Y += dy;
            X1 += dx;
            Y1 += dy;
        }

        public override string ToString()
        {
            return $"2 {X} {Y} {X1} {Y1} {OutLineColor}";
        }

    }
    class LineMove : IMouse
    {
        bool active;
        Sheet sheet;
        IPalitra palitra;
        Line e;
        float StartX, StartY;

        public LineMove(IPalitra pali, Sheet s)
        {
            sheet = s;
            palitra = pali;
        }

        public void MouseDownHandler(float x, float y)
        {
            StartX = x;
            StartY = y;
            active = true;
            e = new Line()
            {
                X = x,
                Y = y,
                X1 = x,
                Y1 = y,
                OutLineColor = palitra.MainColor
            };
            sheet.Add(e);
        }

        public void MouseMoveHandler(float x, float y)
        {
            if(active)
            {
                e.X1 = x;
                e.Y1 = y;
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
