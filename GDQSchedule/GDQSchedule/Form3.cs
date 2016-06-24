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
            textBox1.Clear();

            this.CenterToScreen();
            listBox1.Items.Clear();
            string prev = "";
            bool first = true;
            foreach (Game g in Info.AllGames)
            {
                if (g.StartTime >= DateTime.Now)
                {
                    if (first)
                    {
                        if (prev != "")
                        {
                            listBox1.Items.Add(prev);
                        }
                        first = false;
                    }
                    listBox1.Items.Add(g.StartTime.ToString("ddd dd MMM @ hh:mmtt") + "\t" + g.Name + " {" + g.Category + "} [" + g.EstimatedLength + "]\r\n");
                }
                else
                {
                    prev = g.StartTime.ToString("ddd dd MMM @ hh:mmtt") + "\t" + g.Name + " {" + g.Category + "} [" + g.EstimatedLength + "]\r\n";
                }
            }
        }

        bool showall = false;

        private void Form3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UpdateBox();
            }
        }

        private void UpdateBox()
        {
            textBox1.Clear();

            if (showall)
            {
                showall = false;
                listBox1.Items.Clear();
                string prev = "";
                bool first = true;
                this.Text = "Schedule: Current and Future Events";
                foreach (Game g in Info.AllGames)
                {
                    if (g.StartTime >= DateTime.Now)
                    {
                        if (first)
                        {
                            if (prev != "")
                            {
                                listBox1.Items.Add(prev);
                            }
                            first = false;
                        }
                        listBox1.Items.Add(g.StartTime.ToString("ddd dd MMM @ hh:mmtt") + "\t" + g.Name + " {" + g.Category + "} [" + g.EstimatedLength + "]\r\n");
                    }
                    else
                    {
                        prev = g.StartTime.ToString("ddd dd MMM @ hh:mmtt") + "\t" + g.Name + " {" + g.Category + "} [" + g.EstimatedLength + "]\r\n";
                    }
                }
            }
            else
            {
                showall = true;
                listBox1.Items.Clear();
                this.Text = "Schedule: All Events";
                foreach (Game g in Info.AllGames)
                {
                    listBox1.Items.Add(g.StartTime.ToString("ddd dd MMM @ hh:mmtt") + "\t" + g.Name + " {" + g.Category + "} [" + g.EstimatedLength + "]\r\n");
                }
            }

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form4 f = new Form4(Info.FindGameByName(listBox1.SelectedItem.ToString().Split('\t')[1].Split('{')[0].Trim(), listBox1.SelectedItem.ToString().Split('{')[1].Split('}')[0].Trim()));
            f.ShowDialog();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //Form4 f = new Form4(Info.FindGameByName(listBox1.SelectedItem.ToString().Split('\t')[1].Split('[')[0].Trim()));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            if (textBox1.Text != "")
            {
                foreach (Game g in Info.AllGames)
                {
                    string gamestring = g.StartTime.ToString("ddd dd MMM @ hh:mmtt") + "\t" + g.Name + " {" + g.Category + "} [" + g.EstimatedLength + "]\r\n";
                    if (gamestring.ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        if (showall || g == Info.AllGames[Info.FindGameIDByTime(DateTime.Now)] || g.StartTime >= DateTime.Now)
                        {
                            listBox1.Items.Add(gamestring);
                        }
                    }
                }
            }
            else
            {
                showall = !showall;
                UpdateBox();
            }
        }
    }
}
