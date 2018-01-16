using System.Drawing;
using System.Windows.Forms;

namespace Figures
{
    public interface IFigure
    {
        void Draw(MyDrawer drawer);
        string Serialize();
    }

    public class MyDrawer
    {
        System.Windows.Forms.Panel drawingPanel;
        Color drawingColor;
        public MyDrawer(System.Windows.Forms.Panel _drawingPanel)
        {
            drawingPanel = _drawingPanel;
        }
        public void drawLine(int x1, int y1, int x2, int y2)
        {
            Graphics g = drawingPanel.CreateGraphics();
            g.DrawLine(new Pen(new SolidBrush(drawingColor),3), new Point(x1, y1), new Point(x2, y2));
        }

        public void SetColor(Color dc)
        {
            drawingColor = dc;
        }
    }

    public class Line : IFigure
    {
        int fromX, fromY, toX, toY;
        public Line(int x1, int y1, int x2, int y2)
        {
            fromX = x1;
            fromY = y1;
            toX = x2;
            toY = y2;
        }
        void IFigure.Draw(MyDrawer drawer)
        {
            drawer.drawLine(fromX, fromY, toX, toY);
        }

        string IFigure.Serialize()
        {
            
            return string.Empty;
        }
    }


}
