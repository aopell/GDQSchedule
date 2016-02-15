using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ExtMethods;
using System.Runtime.InteropServices;

namespace GDQSchedule
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void w(string text)
        {
            timeLabel.Text += text + "\r\n";
        }

        public void w2(string text)
        {
            richTextBox1.Text += text + "\r\n";
        }

        Game currentGame;
        Game nextGame;
        Game thirdGame;
        Game fourthGame;
        int gameNumber;

        public void LoadGameInfoStuff()
        {
            gameNumber = Info.FindCurrentGameByTime(DateTime.Now);
            if (gameNumber != -1)
            {
                currentGame = Info.AllGames[gameNumber];
                nextGame = Info.AllGames.Count > gameNumber + 1 ? Info.AllGames[gameNumber + 1] : new Game("No Game", DateTime.Now.AddYears(1), new TimeSpan(365, 0, 0, 0, 0), "None", "None", "No Comment");
                thirdGame = Info.AllGames.Count > gameNumber + 2 ? Info.AllGames[gameNumber + 2] : new Game("No Game", DateTime.Now.AddYears(2), new TimeSpan(365, 0, 0, 0, 0), "None", "None", "No Comment");
                fourthGame = Info.AllGames.Count > gameNumber + 3 ? Info.AllGames[gameNumber + 3] : new Game("No Game", DateTime.Now.AddYears(3), new TimeSpan(365, 0, 0, 0, 0), "None", "None", "No Comment");
            }
            else
            {
                currentGame = new Game("No Game", DateTime.Now, new TimeSpan(365, 0, 0, 0, 0), "None", "None", "No Comment");
                nextGame = new Game("No Game", DateTime.Now.AddYears(1), new TimeSpan(365, 0, 0, 0, 0), "None", "None", "No Comment");
                thirdGame = new Game("No Game", DateTime.Now.AddYears(2), new TimeSpan(365, 0, 0, 0, 0), "None", "None", "No Comment");
                fourthGame = new Game("No Game", DateTime.Now.AddYears(3), new TimeSpan(365, 0, 0, 0, 0), "None", "None", "No Comment");
            }
        }


        public void ResetAll()
        {
            label2.Text = "[Loading...]";
            label3.Text = "Runner(s): [Loading...]\nRunning for approx. [Loading...] / Est. [Loading...]";
            timeLabel.Text = "[Loading...]";
            currentGameLabel.Text = "[Loading...]";
            nextGameLabel.Text = "[Loading...]";
            followingGameLabel.Text = "[Loading...]";
            afterThatLabel.Text = "[Loading...]";

            Info.LoadSchedule();
            LoadGameInfoStuff();
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();

            this.CenterToScreen();

            foreach (string s in File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GDQ\Info.txt"))
            {
                w2(s);
            }
            ResetAll();
            toolTip1.Active = false;
            HideCaret(this.Handle);
        }

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!Info.editing)
            {
                if (currentGame == nextGame)
                {

                }
                else if (DateTime.Now < nextGame.StartTime)
                {
                    try
                    {
                        gameNumber = Info.FindCurrentGameByTime(DateTime.Now);
                        timeLabel.Text = "";

                        TimeSpan approxRunLength = DateTime.Now - currentGame.StartTime;
                        timeLabel.Text = "Current Time: " + DateTime.Now.ToString();
                        timeLabel.Text += "\nCurrently Operating " + (Info.ManualTimeOffset == 0 ? "On Schedule" : (Info.ManualTimeOffset > 0 ? (Info.ManualTimeOffset + " Minutes Behind") : (-1 * Info.ManualTimeOffset + " Minutes Ahead")));
                        currentGameLabel.Text = "Current Game: " + currentGame.Name.Truncate(24);
                        currentGameLabel.Text += "\nStarted At: " + currentGame.StartTime;
                        toolTip1.SetToolTip(currentGameLabel, "Game: " + currentGame.Name + "\nRunners: " + currentGame.Participants + "\nConsole: " + currentGame.Console + "\nComments: " + currentGame.Comment);
                        nextGameLabel.Text = "Next Game: " + nextGame.Name.Truncate(28);
                        nextGameLabel.Text += "\nWill Start At: " + nextGame.StartTime;
                        nextGameLabel.Text += "\nEstimated Length: " + nextGame.EstimatedLength;
                        toolTip1.SetToolTip(nextGameLabel, "Game: " + nextGame.Name + "\nRunners: " + nextGame.Participants + "\nConsole: " + nextGame.Console + "\nComments: " + nextGame.Comment);
                        followingGameLabel.Text = "Following Game: " + thirdGame.Name.Truncate(24);
                        followingGameLabel.Text += "\nWill Start At: " + thirdGame.StartTime;
                        followingGameLabel.Text += "\nEstimated Length: " + thirdGame.EstimatedLength;
                        toolTip1.SetToolTip(followingGameLabel, "Game: " + thirdGame.Name + "\nRunners: " + thirdGame.Participants + "\nConsole: " + thirdGame.Console + "\nComments: " + thirdGame.Comment);
                        afterThatLabel.Text = "After That: " + fourthGame.Name.Truncate(26);
                        afterThatLabel.Text += "\nWill Start At: " + fourthGame.StartTime;
                        afterThatLabel.Text += "\nEstimated Length: " + fourthGame.EstimatedLength;
                        toolTip1.SetToolTip(afterThatLabel, "Game: " + fourthGame.Name + "\nRunners: " + fourthGame.Participants + "\nConsole: " + fourthGame.Console + "\nComments: " + fourthGame.Comment);
                        this.Text = currentGame.Name + " @ " + Info.CurrentEventName;
                        this.Select();

                        label3.Text = "Runners: " + currentGame.Participants + ((approxRunLength < currentGame.EstimatedLength) ? "\nRunning for Approximately: " + approxRunLength.Hours + ":" + (approxRunLength.Minutes < 10 ? "0" : "") + approxRunLength.Minutes + ":" + (approxRunLength.Seconds < 10 ? "0" : "") + approxRunLength.Seconds + " / " + currentGame.EstimatedLength + " Estimated Length" : "\nRun Estimated to be Completed, Next game starts on " + nextGame.StartTime.ToString("ddd dd MMM @ hh:mm tt"));

                        if (currentGame.Name == "Waiting")
                        {
                            label2.Text = currentGame.Name + " for " + Info.CurrentEventName + " to Begin";
                            label3.Text = "Time Until Event:\n" + (nextGame.StartTime - DateTime.Now).ToString(@"d' Days 'h' Hours 'm' Minutes 's' Seconds'");
                            this.Text = "Waiting for " + Info.CurrentEventName + " to Begin";
                        }
                        else
                        {
                            label2.Text = currentGame.Name + " on " + currentGame.Console;
                        }
                        return;
                    }
                    catch
                    {
                        LoadGameInfoStuff();
                    }
                }
                LoadGameInfoStuff();
            }
            else
            {
                timeLabel.Text = "Loading...";
                LoadGameInfoStuff();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                timer1.Enabled = false;
                Form2 f = new Form2();
                f.ShowDialog();
                ResetAll();
            }
            else if (e.Button == MouseButtons.Middle)
            {
                Process.Start("http://twitch.tv/gamesdonequick");
            }
            else if (e.Button == MouseButtons.Left)
            {
                timer1.Enabled = false;
                Form3 f3 = new Form3();
                f3.ShowDialog();
                timer1.Enabled = true;
            }
        }

        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
        {
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            toolTip1.Active = true;
        }

        private void currentGameLabel_MouseUp(object sender, MouseEventArgs e)
        {
            toolTip1.Active = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

namespace ExtMethods
{
    public static class ExtMethods
    {
        public static string Truncate(this string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
        }
    }
}
