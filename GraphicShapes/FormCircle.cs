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
    public partial class FormCircle : Form
    {
        public Circle Circle { get; set; }
        public FormCircle()
        {
            InitializeComponent();
        }

        private void FormCircle_Load(object sender, EventArgs e)
        {
            textBoxDiameter.Text = Circle.Diameter.ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Circle.Diameter = int.Parse(textBoxDiameter.Text);
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
