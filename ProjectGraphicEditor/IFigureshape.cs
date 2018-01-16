using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrapicsEditor;
using GdiGraphicsEditor;

namespace ProjectGraphicEditor
{
    interface IFigureshape
    {
        void DrawOn(IRenderer r);
        void MoveBy(float dx, float dy);
        bool Intersects(float x, float y, float eps);
    }
}
