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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        bool shouldClose = false;

        private void Form2_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            numericUpDown1.Value = Info.ManualTimeOffset;
            textBox1.Text = Properties.Settings.Default.EventName;
            textBox2.Text = Properties.Settings.Default.Link;
            textBox3.Text = Properties.Settings.Default.ScheduleFilePath;
            textBox4.Text = Properties.Settings.Default.InfoPanelFilePath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(textBox3.Text) || !System.IO.File.Exists(textBox4.Text))
            {
                MessageBox.Show("Please choose existant files for the schedule and info panels");
                return;
            }

            Properties.Settings.Default.TimeOffset = (long)numericUpDown1.Value;
            Properties.Settings.Default.Link = textBox2.Text;
            Properties.Settings.Default.EventName = textBox1.Text;
            Properties.Settings.Default.ScheduleFilePath = textBox3.Text;
            Properties.Settings.Default.InfoPanelFilePath = textBox4.Text;
            Strings.SchedulePath = textBox3.Text;
            Strings.InfoPanelPath = textBox4.Text;
            Properties.Settings.Default.Save();
            Info.CurrentEventName = textBox1.Text;
            shouldClose = true;
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!shouldClose)
            {
                e.Cancel = true;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = openFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = openFileDialog1.FileName;
            }
        }
    }
}
