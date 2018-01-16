using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrapicsEditor;
using GdiGraphicsEditor;

namespace ProjectGraphicEditor
{
    class MouseMove:IMouse
    {
        Sheet sheet;
        IPalitra palitra;
        IFigureshape r;
        float eps;
        float LastX, LastY;

        public MouseMove(IPalitra pali, Sheet s, float eps)
        {
            this.eps = eps;
            sheet = s;
            palitra = pali;
            r = null;
        }
        public void MouseDownHandler(float x, float y)
        {
            var shapes = sheet.FindShapes(x, y, eps);
            if (shapes.Count > 0)
            {
                LastX = x;
                LastY = y;
                r = shapes[shapes.Count - 1];
            }
        }

        public void MouseMoveHandler(float x, float y)
        {
            if (r != null)
            {
                r.MoveBy(x - LastX, y - LastY);
                LastX = x;
                LastY = y;
                palitra.Invalidate();
            }
        }
        public void MouseUpHandler(float x, float y)
        {
            if(r != null)
            {
                r.MoveBy(x - LastX, y - LastY);
                LastX = x;
                LastY = y;
                r = null;
                palitra.Invalidate();
            }
        }       
    }
}
