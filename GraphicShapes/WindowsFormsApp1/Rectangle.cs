using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Rectangle : Shape
    {   

        public int Width { get; set; }
        public int Height { get; set; }

        public override int Area => Width * Height;

        public override void Paint(Graphics graphics, int thickness = 1)
        {
            var colorBorder = Selected
                ? Color.Red
                : ColorBorder;

            using (var brush = new SolidBrush(ColorFill))
                graphics.FillRectangle(brush, Location.X, Location.Y, Width, Height);
            using (var pen = new Pen(colorBorder, thickness))
                graphics.DrawRectangle(pen, Location.X, Location.Y, Width, Height);
        }
        public override bool PointInShape(Point point)
        {
            return
                Location.X <= point.X && point.X <= Location.X + Width &&
                Location.Y <= point.Y && point.Y <= Location.Y + Height;
        }
        public override bool Intersect(Rectangle rectangle)
        {
            return
                Location.X < rectangle.Location.X + rectangle.Width && rectangle.Location.X < Location.X + Width &&
                Location.Y < rectangle.Location.Y + rectangle.Height && rectangle.Location.Y < Location.Y + Height;
        }
        
    }
}
