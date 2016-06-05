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
    public partial class Form4 : Form
    {
        Game Game;

        public Form4(Game game)
        {
            InitializeComponent();
            Game = game;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = Game.Name;
            label7.Text = Game.StartTime.ToLongDateString() + " @ " + Game.StartTime.ToShortTimeString();
            label8.Text = Game.EstimatedLength.ToString();
            label9.Text = Game.Participants;
            label10.Text = Game.Category;
            label11.Text = Game.Comment;
            label13.Text = $"{Info.AllGames.IndexOf(Game) + 1}/{Info.AllGames.Count}";
            CenterToScreen();
        }
    }
}
