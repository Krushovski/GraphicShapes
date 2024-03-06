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
        private bool rectBtn = false;
        private bool circleBtn = false;


        private double area;
        private List<Shape> _shapes = new List<Shape>();
        private Point _mouseCaptureLocation;
        private Shape _frame;
        public FormScene()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);
            KeyPreview = true;
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
            if (MouseButtons.Left == e.Button || (MouseButtons.Right == e.Button && rectBtn))
            {
                _frame = new Rectangle
                {
                    ColorBorder = Color.LightGray
                };
                rectBtn = false;
            }
            if (MouseButtons.Right == e.Button && circleBtn)
            {
                _frame = new Circle
                {
                    ColorBorder = Color.LightGray
                };
                circleBtn = false;
            }

            if (MouseButtons.Left == e.Button)
            {
                foreach (var selectedShape in _shapes)
                    if (selectedShape.PointInShape(_mouseCaptureLocation))
                    {
                        selectedShape.Selected = true;
                        break;
                    }
                    else
                        selectedShape.Selected = false;
            }
            Invalidate();
        }
        private void FormScene_MouseMove(object sender, MouseEventArgs e)
        {
            if (_frame == null)
                return;


            Type type = _frame.GetType();
            if (type.Equals(typeof(Rectangle)))
            {
                _frame.Location = new Point
                {
                    X = Math.Min(_mouseCaptureLocation.X, e.X),
                    Y = Math.Min(_mouseCaptureLocation.Y, e.Y),
                };
                ((Rectangle)_frame).Width = Math.Abs(_mouseCaptureLocation.X - e.X);
                ((Rectangle)_frame).Height = Math.Abs(_mouseCaptureLocation.Y - e.Y);
            }
            else if (type.Equals(typeof(Circle)))
            {
                _frame.Location = new Point
                {
                    X = _mouseCaptureLocation.X,
                    Y = _mouseCaptureLocation.Y,
                };
                int x = Math.Abs(_mouseCaptureLocation.X - e.X) * 2;
                int y = Math.Abs(_mouseCaptureLocation.Y - e.Y) * 2;
                if (x > y)
                    ((Circle)_frame).Diameter = x;
                else if (y > x)
                    ((Circle)_frame).Diameter = y;
                else
                    ((Circle)_frame).Diameter = x;

            }

            if (e.Button == MouseButtons.Left)
                foreach (var shape in _shapes)
                {
                    if (shape.PointInShape(_mouseCaptureLocation))
                    {
                        int dx = e.X - _mouseCaptureLocation.X;
                        int dy = e.Y - _mouseCaptureLocation.Y;
                        _mouseCaptureLocation = e.Location;

                        Point point = new Point
                        {
                            X = shape.Location.X + dx,
                            Y = shape.Location.Y + dy
                        };
                        shape.Location = point;
                    }
                    else
                    {
                        shape.Selected = shape.Intersect((Rectangle)_frame);
                    }
                }

            Invalidate();
        }

        private void FormScene_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && _frame != null)
            {
                foreach (var shape in _shapes)
                {
                    shape.Selected = false;
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
            for (int s = _shapes.Count() - 1; s >= 0; s--)
            {
                if (_shapes[s].Selected)
                {
                    area -= _shapes[s].Area;
                    _shapes.RemoveAt(s);

                }

            }
            toolStripStatusLabelArea.Text = area.ToString();
            Invalidate();
        }

        private void FormScene_DoubleClick(object sender, EventArgs e)
        {
            foreach (var shape in _shapes)
                if (shape.Selected)
                {
                    Type tp = shape.GetType();
                    if (tp.Equals(typeof(Rectangle)))
                    {                                       
                        FormProperties fp = new FormProperties();
                        fp.Rectangle = (Rectangle)shape;
                        area -= shape.Area;
                        fp.ShowDialog();                    
                    }
                    else if (tp.Equals(typeof(Circle)))
                    {
                        FormCircle fc = new FormCircle();
                        fc.Circle = (Circle)shape;
                        area -= shape.Area;
                        fc.ShowDialog();
                    }
                    area += shape.Area;
                    toolStripStatusLabelArea.Text = area.ToString();
                    Invalidate();
                    break;
                }
        }

        private void buttonRect_MouseClick(object sender, MouseEventArgs e)
        {
            rectBtn = true;
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            circleBtn = true;
        }
    }
}
