using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGraphicEditor
{
    interface IPalitra
    {
        int MainColor { get; }
        int SecondaryColor { get; }

        void Invalidate();
    }
}
