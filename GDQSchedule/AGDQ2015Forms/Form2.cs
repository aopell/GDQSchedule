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

        private void Form2_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            numericUpDown1.Value = Info.ManualTimeOffset;
            textBox1.Text = Properties.Settings.Default.EventName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.TimeOffset = (int)numericUpDown1.Value;
            Properties.Settings.Default.EventName = textBox1.Text;
            Properties.Settings.Default.Save();
            Info.CurrentEventName = textBox1.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
