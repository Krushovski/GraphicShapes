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
    public partial class FormProperties : Form
    {
        public Rectangle Rectangle { get; set; }
        public FormProperties()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Rectangle.Width = int.Parse(textBoxWidth.Text);
            Rectangle.Height = int.Parse(textBoxHeight.Text);
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void FormProperties_Load(object sender, EventArgs e)
        {
            textBoxWidth.Text = Rectangle.Width.ToString();
            textBoxHeight.Text = Rectangle.Height.ToString();

        }

       
    }
}
