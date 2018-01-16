using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GrapicsEditor
{
    public interface IRenderer
    {        
        void DrawRectangle(float x, float y, float Width, float Height, int outline, int fill);
        void DrawCircle(float x, float y, float r, int outline, int fill);
        void DrawLine(float x, float y, float x1, float y1, int outline);
    }    
}
