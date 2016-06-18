namespace GDQSchedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.currentGameLabel = new System.Windows.Forms.Label();
            this.nextGameLabel = new System.Windows.Forms.Label();
            this.followingGameLabel = new System.Windows.Forms.Label();
            this.afterThatLabel = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timeLabel
            // 
            this.timeLabel.BackColor = System.Drawing.Color.Black;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.Color.Red;
            this.timeLabel.Location = new System.Drawing.Point(12, 88);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(328, 42);
            this.timeLabel.TabIndex = 2;
            this.timeLabel.Text = "[Loading...]\r\n[Loading...]";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Minecraft", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(662, 35);
            this.label2.TabIndex = 4;
            this.label2.Text = "[Loading...]";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            this.label2.DoubleClick += new System.EventHandler(this.label2_DoubleClick);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(666, 37);
            this.label3.TabIndex = 5;
            this.label3.Text = "Runner(s): [Loading...]\r\nRunning for approx. [Loading...] / Est. [Loading...]";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.DoubleClick += new System.EventHandler(this.label2_DoubleClick);
            // 
            // currentGameLabel
            // 
            this.currentGameLabel.BackColor = System.Drawing.Color.Black;
            this.currentGameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentGameLabel.ForeColor = System.Drawing.Color.Yellow;
            this.currentGameLabel.Location = new System.Drawing.Point(12, 135);
            this.currentGameLabel.Name = "currentGameLabel";
            this.currentGameLabel.Size = new System.Drawing.Size(328, 66);
            this.currentGameLabel.TabIndex = 6;
            this.currentGameLabel.Text = "[Loading...]\r\n[Loading...]\r\n[Loading...]";
            this.currentGameLabel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.currentGameLabel_MouseDoubleClick);
            this.currentGameLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.currentGameLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.currentGameLabel_MouseUp);
            // 
            // nextGameLabel
            // 
            this.nextGameLabel.BackColor = System.Drawing.Color.Black;
            this.nextGameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextGameLabel.ForeColor = System.Drawing.Color.Lime;
            this.nextGameLabel.Location = new System.Drawing.Point(12, 206);
            this.nextGameLabel.Name = "nextGameLabel";
            this.nextGameLabel.Size = new System.Drawing.Size(328, 64);
            this.nextGameLabel.TabIndex = 7;
            this.nextGameLabel.Text = "[Loading...]\r\n[Loading...]\r\n[Loading...]\r\n[Loading...]";
            this.nextGameLabel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nextGameLabel_MouseDoubleClick);
            this.nextGameLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.nextGameLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.currentGameLabel_MouseUp);
            // 
            // followingGameLabel
            // 
            this.followingGameLabel.BackColor = System.Drawing.Color.Black;
            this.followingGameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.followingGameLabel.ForeColor = System.Drawing.Color.Aqua;
            this.followingGameLabel.Location = new System.Drawing.Point(11, 276);
            this.followingGameLabel.Name = "followingGameLabel";
            this.followingGameLabel.Size = new System.Drawing.Size(328, 64);
            this.followingGameLabel.TabIndex = 8;
            this.followingGameLabel.Text = "[Loading...]\r\n[Loading...]\r\n[Loading...]\r\n[Loading...]";
            this.followingGameLabel.DoubleClick += new System.EventHandler(this.followingGameLabel_DoubleClick);
            this.followingGameLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.followingGameLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.currentGameLabel_MouseUp);
            // 
            // afterThatLabel
            // 
            this.afterThatLabel.BackColor = System.Drawing.Color.Black;
            this.afterThatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afterThatLabel.ForeColor = System.Drawing.Color.Fuchsia;
            this.afterThatLabel.Location = new System.Drawing.Point(11, 346);
            this.afterThatLabel.Name = "afterThatLabel";
            this.afterThatLabel.Size = new System.Drawing.Size(328, 64);
            this.afterThatLabel.TabIndex = 9;
            this.afterThatLabel.Text = "[Loading...]\r\n[Loading...]\r\n[Loading...]\r\n[Loading...]";
            this.afterThatLabel.DoubleClick += new System.EventHandler(this.afterThatLabel_DoubleClick);
            this.afterThatLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.afterThatLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.currentGameLabel_MouseUp);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(346, 88);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(332, 325);
            this.listBox1.TabIndex = 10;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            this.listBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(690, 423);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.afterThatLabel);
            this.Controls.Add(this.followingGameLabel);
            this.Controls.Add(this.nextGameLabel);
            this.Controls.Add(this.currentGameLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.timeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SQDQ 2015";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Form1_HelpButtonClicked);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label currentGameLabel;
        private System.Windows.Forms.Label nextGameLabel;
        private System.Windows.Forms.Label followingGameLabel;
        private System.Windows.Forms.Label afterThatLabel;
        private System.Windows.Forms.ListBox listBox1;
    }
}

