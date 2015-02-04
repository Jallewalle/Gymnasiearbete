namespace Attempt1V2
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BreakBlocks = new System.Windows.Forms.Timer(this.components);
            this.updatetimer = new System.Windows.Forms.Timer(this.components);
            this.tbx_x = new System.Windows.Forms.TextBox();
            this.tbx_y = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BreakBlocks
            // 
            this.BreakBlocks.Interval = 1;
            this.BreakBlocks.Tick += new System.EventHandler(this.BreakBlocks_Tick);
            // 
            // updatetimer
            // 
            this.updatetimer.Enabled = true;
            this.updatetimer.Interval = 10000;
            this.updatetimer.Tick += new System.EventHandler(this.updatetimer_Tick);
            // 
            // tbx_x
            // 
            this.tbx_x.Location = new System.Drawing.Point(13, 492);
            this.tbx_x.Name = "tbx_x";
            this.tbx_x.Size = new System.Drawing.Size(100, 20);
            this.tbx_x.TabIndex = 0;
            this.tbx_x.TabStop = false;
            this.tbx_x.Visible = false;
            // 
            // tbx_y
            // 
            this.tbx_y.Location = new System.Drawing.Point(120, 491);
            this.tbx_y.Name = "tbx_y";
            this.tbx_y.Size = new System.Drawing.Size(100, 20);
            this.tbx_y.TabIndex = 0;
            this.tbx_y.TabStop = false;
            this.tbx_y.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(237, 488);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Text = "tp to";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(984, 524);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbx_y);
            this.Controls.Add(this.tbx_x);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "SuperSpel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer BreakBlocks;
        private System.Windows.Forms.Timer updatetimer;
        private System.Windows.Forms.TextBox tbx_x;
        private System.Windows.Forms.TextBox tbx_y;
        private System.Windows.Forms.Button button1;
    }
}

