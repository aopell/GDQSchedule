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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timeLabel
            // 
            this.timeLabel.BackColor = System.Drawing.Color.Black;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.Color.White;
            this.timeLabel.Location = new System.Drawing.Point(12, 88);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(328, 42);
            this.timeLabel.TabIndex = 2;
            this.timeLabel.Text = "[Loading...]";
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
            // 
            // currentGameLabel
            // 
            this.currentGameLabel.BackColor = System.Drawing.Color.Black;
            this.currentGameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentGameLabel.ForeColor = System.Drawing.Color.White;
            this.currentGameLabel.Location = new System.Drawing.Point(12, 145);
            this.currentGameLabel.Name = "currentGameLabel";
            this.currentGameLabel.Size = new System.Drawing.Size(328, 42);
            this.currentGameLabel.TabIndex = 6;
            this.currentGameLabel.Text = "[Loading...]";
            this.currentGameLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.currentGameLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.currentGameLabel_MouseUp);
            // 
            // nextGameLabel
            // 
            this.nextGameLabel.BackColor = System.Drawing.Color.Black;
            this.nextGameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextGameLabel.ForeColor = System.Drawing.Color.White;
            this.nextGameLabel.Location = new System.Drawing.Point(12, 202);
            this.nextGameLabel.Name = "nextGameLabel";
            this.nextGameLabel.Size = new System.Drawing.Size(328, 62);
            this.nextGameLabel.TabIndex = 7;
            this.nextGameLabel.Text = "[Loading...]";
            this.nextGameLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.nextGameLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.currentGameLabel_MouseUp);
            // 
            // followingGameLabel
            // 
            this.followingGameLabel.BackColor = System.Drawing.Color.Black;
            this.followingGameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.followingGameLabel.ForeColor = System.Drawing.Color.White;
            this.followingGameLabel.Location = new System.Drawing.Point(11, 279);
            this.followingGameLabel.Name = "followingGameLabel";
            this.followingGameLabel.Size = new System.Drawing.Size(328, 62);
            this.followingGameLabel.TabIndex = 8;
            this.followingGameLabel.Text = "[Loading...]";
            this.followingGameLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.followingGameLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.currentGameLabel_MouseUp);
            // 
            // afterThatLabel
            // 
            this.afterThatLabel.BackColor = System.Drawing.Color.Black;
            this.afterThatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afterThatLabel.ForeColor = System.Drawing.Color.White;
            this.afterThatLabel.Location = new System.Drawing.Point(12, 356);
            this.afterThatLabel.Name = "afterThatLabel";
            this.afterThatLabel.Size = new System.Drawing.Size(328, 62);
            this.afterThatLabel.TabIndex = 9;
            this.afterThatLabel.Text = "[Loading...]";
            this.afterThatLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.afterThatLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.currentGameLabel_MouseUp);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(346, 88);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(332, 349);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(690, 449);
            this.Controls.Add(this.richTextBox1);
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
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

