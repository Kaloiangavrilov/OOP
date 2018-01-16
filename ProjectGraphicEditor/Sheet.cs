using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GdiGraphicsEditor;
using GrapicsEditor;

namespace ProjectGraphicEditor
{
    class Sheet
    {
        protected List<IFigureshape> shapes = new List<IFigureshape>();

        public void DrawOn(IRenderer r)
        {
            foreach (var s in shapes)
                s.DrawOn(r);
        }
        public List<IFigureshape> FindShapes(float x, float y, float eps)
        {
            var result = new List<IFigureshape>();
            foreach (var s in shapes)
                if (s.Intersects(x, y, eps))
                    result.Add(s);
            return result;
        }

        public void Add(IFigureshape shape)
        {
            shapes.Add(shape);
        }
        public void Remove()
        {
            shapes.RemoveRange(0, shapes.Count);
        }

        public void Save(string filePath)
        {
            using (StreamWriter sw = File.CreateText(filePath))
            {
                foreach (var shape in shapes)
                {
                    sw.WriteLine(shape.ToString());
                }
            }
        }
        public void Load(string filePath)
        {
            shapes.Clear();
            var lines = File.ReadAllLines(filePath);

            foreach (var textLine in lines)
            {
                var arguments = textLine.Split(' ');

                if (arguments[0] == "0")
                {
                    var rectangle = new Rectangle()
                    {
                        X = float.Parse(arguments[1]),
                        Y = float.Parse(arguments[2]),
                        Width = float.Parse(arguments[3]),
                        Height = float.Parse(arguments[4]),
                        OutLineColor = int.Parse(arguments[5]),
                        FillColor = int.Parse(arguments[6])
                    };
                    shapes.Add(rectangle);
                }
                else if (arguments[0] == "1")
                {
                    var c = new Circle()
                    {
                        X = float.Parse(arguments[1]),
                        Y = float.Parse(arguments[2]),
                        Width = float.Parse(arguments[3]),
                        OutLineColor = int.Parse(arguments[4]),
                        FillColor = int.Parse(arguments[5])
                    };
                    shapes.Add(c);
                }
                else if (arguments[0] == "2")
                {
                    var line = new Line()
                    {
                        X = float.Parse(arguments[1]),
                        Y = float.Parse(arguments[2]),
                        X1 = float.Parse(arguments[3]),
                        Y1 = float.Parse(arguments[4]),
                        OutLineColor = int.Parse(arguments[5])
                    };
                    shapes.Add(line);
                }
                    
            }
        }
    }
}
