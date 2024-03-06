
namespace WindowsFormsApp1
{
    partial class FormScene
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelArea = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonRect = new System.Windows.Forms.Button();
            this.buttonCircle = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelArea});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelArea
            // 
            this.toolStripStatusLabelArea.Name = "toolStripStatusLabelArea";
            this.toolStripStatusLabelArea.Size = new System.Drawing.Size(174, 20);
            this.toolStripStatusLabelArea.Text = "toolStripStatusLabelArea";
            // 
            // buttonRect
            // 
            this.buttonRect.AutoSize = true;
            this.buttonRect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRect.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonRect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRect.Location = new System.Drawing.Point(753, 0);
            this.buttonRect.Name = "buttonRect";
            this.buttonRect.Size = new System.Drawing.Size(47, 424);
            this.buttonRect.TabIndex = 1;
            this.buttonRect.Text = "Rect";
            this.buttonRect.UseVisualStyleBackColor = true;
            this.buttonRect.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonRect_MouseClick);
            // 
            // buttonCircle
            // 
            this.buttonCircle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCircle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCircle.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCircle.Location = new System.Drawing.Point(694, 0);
            this.buttonCircle.Name = "buttonCircle";
            this.buttonCircle.Size = new System.Drawing.Size(59, 424);
            this.buttonCircle.TabIndex = 2;
            this.buttonCircle.Text = "Circle";
            this.buttonCircle.UseVisualStyleBackColor = true;
            this.buttonCircle.Click += new System.EventHandler(this.buttonCircle_Click);
            // 
            // FormScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCircle);
            this.Controls.Add(this.buttonRect);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FormScene";
            this.Text = "FormScene";
            this.DoubleClick += new System.EventHandler(this.FormScene_DoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormScene_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormScene_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormScene_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormScene_MouseUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelArea;
        private System.Windows.Forms.Button buttonRect;
        private System.Windows.Forms.Button buttonCircle;
    }
}

