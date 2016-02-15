using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDQSchedule
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            richTextBox1.Text = "";
            string prev = "";
            bool first = true;
            foreach (Game g in Info.AllGames)
            {
                if (g.StartTime >= DateTime.Now)
                {
                    if (first)
                    {
                        richTextBox1.Text += prev;
                        first = false;
                    }
                    richTextBox1.Text += g.StartTime.ToString("ddd dd MMM @ hh:mmtt") + "\t" + g.Name + " [" + g.EstimatedLength + "]\r\n";
                }
                else
                {
                    prev = g.StartTime.ToString("ddd dd MMM @ hh:mmtt") + "\t" + g.Name + " [" + g.EstimatedLength + "]\r\n";
                }
            }
        }

        bool showall = false;

        private void Form3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (showall)
                {
                    showall = false;
                    richTextBox1.Text = "";
                    string prev = "";
                    bool first = true;
                    this.Text = "Schedule: Current and Future Events";
                    foreach (Game g in Info.AllGames)
                    {
                        if (g.StartTime >= DateTime.Now)
                        {
                            if (first)
                            {
                                richTextBox1.Text += prev;
                                first = false;
                            }
                            richTextBox1.Text += g.StartTime.ToString("ddd dd MMM @ hh:mmtt") + "\t" + g.Name + " [" + g.EstimatedLength + "]\r\n";
                        }
                        else
                        {
                            prev = g.StartTime.ToString("ddd dd MMM @ hh:mmtt") + "\t" + g.Name + " [" + g.EstimatedLength + "]\r\n";
                        }
                    }
                }
                else
                {
                    showall = true;
                    richTextBox1.Text = "";
                    this.Text = "Schedule: All Events";
                    foreach (Game g in Info.AllGames)
                    {
                        richTextBox1.Text += g.StartTime.ToString("ddd dd MMM @ hh:mmtt") + "\t" + g.Name + " [" + g.EstimatedLength + "]\r\n";
                    }
                }
            }
        }
    }
}
