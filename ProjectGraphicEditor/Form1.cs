using System;
using System.Drawing;
using System.Windows.Forms;
using GrapicsEditor;
using GdiGraphicsEditor;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectGraphicEditor
{
    public partial class Form1 : Form, IPalitra
    {
        Sheet sheet = new Sheet();
        IMouse activeCommand = null;
        Color IPalitra;       

        public Form1()
        {
            InitializeComponent();
            Type t = typeof(Control);

            var p = t.GetProperty("DoubleBuffered",
                BindingFlags.NonPublic
                | BindingFlags.Instance);
            p.SetValue(panel2, true);

            this.DoubleBuffered = true;
            this.Cursor = Cursors.Cross;
        }

        int IPalitra.MainColor
        {
            get
            {
               return OutLineC.Color.ToArgb();
                                    
            }
        }

        int IPalitra.SecondaryColor
        {
            get
            {
                return FillColor.Color.ToArgb();
            }

       }

        private void Main_ResizeBegin(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Value_Scroll(object sender, EventArgs e)
        {

        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if(activeCommand != null)
            {
                activeCommand.MouseDownHandler(e.X, e.Y);
            }

        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (activeCommand != null)
            {
                activeCommand.MouseMoveHandler(e.X, e.Y);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            if (activeCommand != null)
            {
                activeCommand.MouseUpHandler(e.X, e.Y);
            }
       
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            sheet.DrawOn(new GDIRenderer(e.Graphics));
        }

        void IPalitra.Invalidate()
        {
            panel2.Invalidate();
        }

        private void Rectangle(object sender, EventArgs e)
        {
            activeCommand = new RectangleMove(this, sheet);
            FillColor.Color = Color.Transparent;
            FillColorButton.Visible = true;
        }

        private void Circle(object sender, EventArgs e)
        {
            activeCommand = new CircleMove(this, sheet);
            FillColor.Color = Color.Transparent;
            FillColorButton.Visible = true;
        }

        private void Move(object sender, EventArgs e)
        {
            activeCommand = new MouseMove(this, sheet, 2);
            FillColorButton.Visible = true;
        }

        private void Save(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                sheet.Save(saveFileDialog.InitialDirectory + saveFileDialog.FileName);
            }
        }


        private void New(object sender, EventArgs e)
        {
            sheet.Remove();
            panel2.Refresh();
            activeCommand = null;
        }

        private void Line_Click(object sender, EventArgs e)
        {
            activeCommand = new LineMove(this, sheet);
            FillColorButton.Visible = false;
        }

        private void OutLineColorButton_Click(object sender, EventArgs e)
        {
            OutLineC.ShowDialog();
            pictureBox2.BackColor = OutLineC.Color;
 
        }

        private void FillColorButton_Click(object sender, EventArgs e)
        {
            FillColor.ShowDialog();
            pictureBox1.BackColor = FillColor.Color;
        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            if (open.ShowDialog() == DialogResult.OK)
            {
                sheet.Load(open.InitialDirectory + open.FileName);
            }
            Refresh();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
