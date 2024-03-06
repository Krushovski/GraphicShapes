using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class Shape
    {
        public Point Location { get; set; }
        public Color ColorBorder { get; set; }
        public Color ColorFill { get; set; }
        public bool Selected { get; set; }

        public abstract void Paint(Graphics graphics, int thickness);

        public abstract bool PointInShape(Point point);

        public abstract bool Intersect(Rectangle rectangle);

        public abstract int Area { get; }
    }
}
