using GDQSchedule.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDQSchedule
{
    public static class Info
    {
        public static long ManualTimeOffset = Settings.Default.TimeOffset;
        public static bool editing = false;

        public static List<Game> AllGames = new List<Game>();

        public static DateTime firstTime;
        public static bool first = true;

        public static string CurrentEventName = Settings.Default.EventName;

        public static void LoadSchedule()
        {
            ManualTimeOffset = Settings.Default.TimeOffset;
            editing = false;

            string[] Schedule;

            List<DateTime> Times = new List<DateTime>();
            List<string> Games = new List<string>();
            List<string> People = new List<string>();
            List<string> EstTime = new List<string>();
            List<string> Categories = new List<string>();
            List<string> Comments = new List<string>();
            AllGames.Clear();

            Schedule = File.ReadAllLines(Strings.SchedulePath);

            foreach (string s in Schedule)
            {
                string[] g = s.Split('\t');
                Times.Add(Convert.ToDateTime(g[0].Trim()).AddMinutes(ManualTimeOffset));
                Games.Add(g[1].Trim());
                People.Add(g[2].Trim());
                EstTime.Add(g[3].Trim());
                try { Categories.Add(g[4].Trim()); } catch { Categories.Add(""); }
                try { Comments.Add(g[5].Trim()); } catch { Comments.Add(""); }
            }

            for (int i = 0; i < Games.Count; i++)
            {
                try
                {
                    AllGames.Add(new Game(Games[i], Times[i], TimeSpan.Parse(EstTime[i]), People[i], Comments[i], Categories[i]));
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.ToString(), e.GetType().ToString());
                }
            }

            AllGames.OrderBy(game => game.StartTime);
        }

        public static int FindGameIDByTime(DateTime t)
        {
            try
            {
                if (AllGames[0].StartTime > t)
                {
                    AllGames.Insert(0, new Game(Strings.Waiting, t.AddHours(-1), AllGames[0].StartTime - t, Strings.Waiting, Strings.WaitingStatus, Strings.Waiting));
                    return FindGameIDByTime(t);
                }
                for (int i = 1; i < AllGames.Count; i++)
                {
                    if (AllGames[i].StartTime < t && AllGames[i].StartTime + AllGames[i].EstimatedLength > t)
                    {
                        return i;
                    }
                    else if (AllGames[i - 1].StartTime < t && AllGames[i].StartTime > t)
                    {
                        return i - 1;
                    }
                }

                return -1;
            }
            catch
            {
                return -1;
            }
        }

        public static Game FindGameByName(string Name, string Category)
        {
            foreach (Game g in AllGames)
            {
                if (Category != null)
                {
                    if (g.Name == Name && g.Category == Category)
                    {
                        return g;
                    }
                }
                else
                {
                    if (g.Name == Name)
                    {
                        return g;
                    }
                }
            }

            return null;
        }

        public static void ChangeTimeBehind(int minutes)
        {
            LoadSchedule();
            editing = false;
        }
    }
}
