using GrapicsEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace GdiGraphicsEditor
{
    public class GDIRenderer : IRenderer
    {
        protected Graphics g;

        public GDIRenderer(Graphics g)
        {
            this.g = g;
        }
        public void DrawRectangle(float x, float y, float Width, float Height, int outline, int fill)
        {
            using (var p = new Pen(Color.FromArgb(outline)))
                g.DrawRectangle(p, x, y, Width, Height);
            using (var b = new SolidBrush(Color.FromArgb(fill)))
                g.FillRectangle(b, x + 1, y + 1, Width - 1, Height - 1);
        }
        public void DrawCircle(float x, float y, float r, int outline, int fill)
        {
            using (var p = new Pen(Color.FromArgb(outline)))
                g.DrawEllipse(p, x, y, r, r);
            using (var b = new SolidBrush(Color.FromArgb(fill)))
                g.FillEllipse(b, x, y, r - 1, r - 1);
        }
        public void DrawLine(float x, float y, float x1, float y1, int outline)
        {
            using (var p = new Pen(Color.FromArgb(outline)))
                g.DrawLine(p, x, y, x1, y1);
        }

        
    }
}
