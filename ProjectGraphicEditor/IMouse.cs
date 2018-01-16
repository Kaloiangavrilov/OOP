using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GdiGraphicsEditor;
using GrapicsEditor;

namespace ProjectGraphicEditor
{
    interface IMouse
    {
        void MouseDownHandler(float x, float y);
        void MouseUpHandler(float x, float y);
        void MouseMoveHandler(float x, float y);

    }
}
