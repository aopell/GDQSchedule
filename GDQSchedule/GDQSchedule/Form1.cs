using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Linq;

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

        Game currentGame;
        Game nextGame;
        Game thirdGame;
        Game fourthGame;
        int gameNumber;
        List<string> info = new List<string>();
        bool showAllInfo = false;

        public void LoadGameInfoStuff()
        {
            gameNumber = Info.FindGameIDByTime(DateTime.Now);
            if (gameNumber != -1)
            {
                currentGame = Info.AllGames[gameNumber];
                nextGame = Info.AllGames.Count > gameNumber + 1 ? Info.AllGames[gameNumber + 1] : new Game(Strings.NoScheduleItem, DateTime.Now.AddYears(1), new TimeSpan(365, 0, 0, 0, 0), Strings.Missing, Strings.Missing, Strings.Missing);
                thirdGame = Info.AllGames.Count > gameNumber + 2 ? Info.AllGames[gameNumber + 2] : new Game(Strings.NoScheduleItem, DateTime.Now.AddYears(2), new TimeSpan(365, 0, 0, 0, 0), Strings.Missing, Strings.Missing, Strings.Missing);
                fourthGame = Info.AllGames.Count > gameNumber + 3 ? Info.AllGames[gameNumber + 3] : new Game(Strings.NoScheduleItem, DateTime.Now.AddYears(3), new TimeSpan(365, 0, 0, 0, 0), Strings.Missing, Strings.Missing, Strings.Missing);
            }
            else
            {
                currentGame = new Game(Strings.NoScheduleItem, DateTime.Now, new TimeSpan(365, 0, 0, 0, 0), Strings.Missing, Strings.Missing, Strings.Missing);
                nextGame = new Game(Strings.NoScheduleItem, DateTime.Now.AddYears(1), new TimeSpan(365, 0, 0, 0, 0), Strings.Missing, Strings.Missing, Strings.Missing);
                thirdGame = new Game(Strings.NoScheduleItem, DateTime.Now.AddYears(2), new TimeSpan(365, 0, 0, 0, 0), Strings.Missing, Strings.Missing, Strings.Missing);
                fourthGame = new Game(Strings.NoScheduleItem, DateTime.Now.AddYears(3), new TimeSpan(365, 0, 0, 0, 0), Strings.Missing, Strings.Missing, Strings.Missing);
            }
        }


        public void ResetAll()
        {
            label2.Text = Strings.Loading;
            label3.Text = $"{Strings.People}: {Strings.Loading}\n{Strings.CurrentProgress} {Strings.Loading} / {Strings.EstLength} {Strings.Loading}";
            timeLabel.Text = Strings.Loading;
            currentGameLabel.Text = Strings.Loading;
            nextGameLabel.Text = Strings.Loading;
            followingGameLabel.Text = Strings.Loading;
            afterThatLabel.Text = Strings.Loading;

            Info.LoadSchedule();
            LoadGameInfoStuff();

            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();

            CenterToScreen();

            ResetAll();
            toolTip1.Active = false;

            UpdateInfoPanel();
        }

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
                        gameNumber = Info.FindGameIDByTime(DateTime.Now);
                        timeLabel.Text = "";

                        TimeSpan approxRunLength = DateTime.Now - currentGame.StartTime;
                        timeLabel.Text = $"{Strings.CurrentTime}: " + DateTime.Now.AddSeconds(1).ToString();
                        timeLabel.Text += $"\n{Strings.BaseStatus}" + (Info.ManualTimeOffset == 0 ? Strings.OnTimeStatus : (Info.ManualTimeOffset > 0 ? (Info.ManualTimeOffset + Strings.BehindStatus) : (-1 * Info.ManualTimeOffset + Strings.AheadStatus)));
                        currentGameLabel.Text = Strings.Current + ": " + currentGame.Name.Truncate(24);
                        currentGameLabel.Text += $"\n{Strings.Started}: " + currentGame.StartTime;
                        currentGameLabel.Text += $"\n{Strings.ScheduleItem} {Info.AllGames.IndexOf(currentGame) + 1}/{Info.AllGames.Count}";

                        nextGameLabel.Text = Strings.Next + ": " + nextGame.Name.Truncate(28);
                        nextGameLabel.Text += $"\n{Strings.WillStart}: " + nextGame.StartTime;
                        nextGameLabel.Text += $"\n{Strings.EstLength}: " + nextGame.EstimatedLength;

                        followingGameLabel.Text = Strings.Following + ": " + thirdGame.Name.Truncate(23);
                        followingGameLabel.Text += $"\n{Strings.WillStart}: " + thirdGame.StartTime;
                        followingGameLabel.Text += $"\n{Strings.EstLength}: " + thirdGame.EstimatedLength;

                        afterThatLabel.Text = Strings.After + ": " + fourthGame.Name.Truncate(26);
                        afterThatLabel.Text += $"\n{Strings.WillStart}: " + fourthGame.StartTime;
                        afterThatLabel.Text += $"\n{Strings.EstLength}: " + fourthGame.EstimatedLength;

                        Select();

                        label3.Text = $"{Strings.People}: " + currentGame.Participants + ((approxRunLength < currentGame.EstimatedLength) ? $"\n{Strings.CurrentProgress}: " + approxRunLength.Hours + ":" + (approxRunLength.Minutes < 10 ? "0" : "") + approxRunLength.Minutes + ":" + (approxRunLength.Seconds < 10 ? "0" : "") + approxRunLength.Seconds + " / " + currentGame.EstimatedLength.ToString(@"h':'mm':'ss") + $" {Strings.EstLength}" : $"\n{Strings.NextScheduleItem} " + (nextGame.StartTime - DateTime.Now).ToString(@"dd':'hh':'mm':'ss"));

                        label2.ForeColor = label3.Text.Contains(Strings.CompletedKeyword) ? Color.Orange : Color.White;
                        label3.ForeColor = label3.Text.Contains(Strings.CompletedKeyword) ? Color.Orange : Color.White;

                        if (currentGame.Name == Strings.Waiting)
                        {
                            label2.ForeColor = Color.Red;
                            label3.ForeColor = Color.Red;
                            label2.Text = currentGame.Name + " for " + Info.CurrentEventName + " to Begin";
                            label3.Text = $"{Strings.TimeUntilEvent}:\n" + (nextGame.StartTime - DateTime.Now).ToString(@"d' Days 'h' Hours 'm' Minutes 's' Seconds'");
                            Text = Strings.WaitingStatus;
                        }
                        else
                        {
                            Text = currentGame.Name + " @ " + Info.CurrentEventName;
                            label2.Text = (currentGame.Name + " | " + currentGame.Category).Truncate(48);
                        }

                        UpdateInfoPanel();

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
                timeLabel.Text = Strings.Loading;
                LoadGameInfoStuff();
            }
        }

        private void UpdateInfoPanel()
        {
            List<string> temp = new List<string>();

            foreach (string s in File.ReadAllLines(Strings.InfoPanelPath))
            {
                string game;
                string category = null;
                try
                {
                    game = s.Split('\t')[0];
                    category = s.Split('\t')[1];
                }
                catch
                {
                    game = s;
                }
                Game g = Info.FindGameByName(game, category);
                if (!showAllInfo && g != null && (g == Info.AllGames[Info.FindGameIDByTime(DateTime.Now)] || g.StartTime >= DateTime.Now))
                {
                    temp.Add(g.StartTime.ToString("ddd dd MMM @ hh:mmtt") + " — " + g.Name + " {" + g.Category + "}");
                }
                else if (showAllInfo && g != null)
                {
                    temp.Add(g.StartTime.ToString("ddd dd MMM @ hh:mmtt") + " — " + g.Name + " {" + g.Category + "}");
                }
            }

            if (!temp.SequenceEqual(info))
            {
                listBox1.Items.Clear();
                listBox1.SelectedItems.Clear();
                info = temp;
                listBox1.Items.AddRange(temp.ToArray());
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
                Process.Start(Properties.Settings.Default.Link);
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

        private void currentGameLabel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            (new Form4(currentGame)).ShowDialog();
        }

        private void nextGameLabel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            (new Form4(nextGame)).ShowDialog();
        }

        private void followingGameLabel_DoubleClick(object sender, EventArgs e)
        {
            (new Form4(thirdGame)).ShowDialog();
        }

        private void afterThatLabel_DoubleClick(object sender, EventArgs e)
        {
            (new Form4(fourthGame)).ShowDialog();
        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            (new Form4(currentGame)).ShowDialog();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                (new Form4(Info.FindGameByName(listBox1.SelectedItem.ToString().Split('—')[1].Split('{')[0].Trim(), listBox1.SelectedItem.ToString().Split('{')[1].Split('}')[0].Trim()))).ShowDialog();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void listBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                showAllInfo = !showAllInfo;
            }
        }
    }

    public static class ExtMethods
    {
        public static string Truncate(this string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
        }
    }
}
