using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormScene : Form
    {
        private List<Shape> _shapes = new List<Shape>();
        private Point _mouseCaptureLocation;
        private Rectangle _frame;
        public FormScene()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (var s in _shapes)
                s.Paint(e.Graphics, 1);
            _frame?.Paint(e.Graphics, 2);
            
        }

        private void FormScene_MouseDown(object sender, MouseEventArgs e)
        { 
              _mouseCaptureLocation = e.Location;
              _frame = new Rectangle
               { 
                   ColorBorder = Color.LightGray
               };


            foreach (var selectedShape in _shapes)
            if (selectedShape.PointInShape(e.Location))
            {
                    selectedShape.Selected = true;
                    break;
            }
            else
              selectedShape.Selected = false;
            
                Invalidate();
        }
        private void FormScene_MouseMove(object sender, MouseEventArgs e)
        {
            if (_frame == null)
                return;
            _frame.Location = new Point
            {
                X = Math.Min(_mouseCaptureLocation.X, e.Location.X),
                Y = Math.Min(_mouseCaptureLocation.Y, e.Location.Y),
            };
            _frame.Width = Math.Abs(_mouseCaptureLocation.X - e.Location.X);
            _frame.Height = Math.Abs(_mouseCaptureLocation.Y - e.Location.Y);

            if(e.Button == MouseButtons.Left)
                foreach (var shape in _shapes)
                  shape.Selected = shape.Intersect(_frame);
                
            
            Invalidate();
        }

        private void FormScene_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && _frame != null)
            {
                    int area = 0;
                foreach (var shape in _shapes)
                {
                    shape.Selected = false;
                    area += shape.Area;
                }
                    var r = new Random();
                    _frame.ColorBorder = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
                    _frame.ColorFill = Color.FromArgb(100, _frame.ColorBorder);
                    _shapes.Add(_frame);
                    _frame.Selected = true;
                    area += _frame.Area;
                toolStripStatusLabelArea.Text = area.ToString();
            } 
            _frame = null;
            Invalidate();
        }

        private void FormScene_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode != Keys.Delete)
                return;
            var area = 0;
            for (int s = _shapes.Count() - 1; s >= 0; s--)
            {
                if (_shapes[s].Selected)
                    _shapes.RemoveAt(s);
                else
                    area += _shapes[s].Area;
                
            }
            toolStripStatusLabelArea.Text = area.ToString();
            Invalidate();
        }

        private void FormScene_DoubleClick(object sender, EventArgs e)
        {
            foreach (var shape in _shapes)
            if(shape.Selected)
            {
                    var fp = new FormProperties();
                    fp.Rectangle = (Rectangle)shape;

                    fp.ShowDialog();
                    Invalidate();
                    break;
            }
        }
    }
}
