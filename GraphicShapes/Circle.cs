using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Circle : Shape
    {
        public int Diameter { get; set; }
        public override void Paint(Graphics graphics, int thickness)
        {
            Color colorBorder;
            if (Selected)
            {
                colorBorder = Color.Red;
                thickness = 2;
            }
            else
                colorBorder = ColorBorder;
            using (var pen = new Pen(colorBorder, thickness))
                graphics.DrawEllipse(pen, Location.X - Diameter / 2, Location.Y - Diameter / 2, Diameter, Diameter);

            using (var brush = new SolidBrush(ColorFill))
                graphics.FillEllipse(brush, Location.X - Diameter / 2, Location.Y - Diameter / 2, Diameter, Diameter);
        }
        public override double Area => Math.PI * Diameter / 2 * Diameter / 2;

        public override bool PointInShape(Point point)
        {
            return
                Math.Sqrt(Math.Pow(point.X - Location.X, 2) + Math.Pow(point.Y - Location.Y, 2)) <= Diameter / 2;
        }
        public override bool Intersect(Rectangle rectangle)
        {
            return
            Location.X - Diameter / 2 < rectangle.Location.X + rectangle.Width && rectangle.Location.X < Location.X - Diameter / 2 + Diameter &&
            Location.Y - Diameter / 2 < rectangle.Location.Y + rectangle.Height && rectangle.Location.Y < Location.Y - Diameter / 2 + Diameter;


            //int circleDistanceX = Math.Abs(Location.X - rectangle.Location.X + rectangle.Width / 2);
            //int circleDistanceY = Math.Abs(Location.Y - rectangle.Location.Y + rectangle.Height / 2);
            //if (circleDistanceX > (rectangle.Width / 2 + Diameter / 2)) { return false; }
            //if (circleDistanceY > (rectangle.Height / 2 + Diameter / 2)) { return false; }
            //if (circleDistanceX <= (rectangle.Width / 2)) { return true; }
            //if (circleDistanceY <= (rectangle.Height / 2)) { return true; }
            //double cornerDistance_sq = Math.Pow(circleDistanceX - rectangle.Width / 2 + (rectangle.Location.X + rectangle.Width) / 2, 2) +
            //             Math.Pow(circleDistanceY - rectangle.Height / 2 + (rectangle.Location.Y + rectangle.Height) / 2, 2);
            //return cornerDistance_sq <= Math.Pow(Diameter / 2, 2);
        }
    }
}





