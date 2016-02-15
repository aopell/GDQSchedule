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
        public static int ManualTimeOffset = Settings.Default.TimeOffset;
        public static bool editing = false;

        public static List<Game> AllGames = new List<Game>();

        public static DateTime firstTime;
        public static bool first = true;

        public static string CurrentEventName = Settings.Default.EventName;

        public static void LoadSchedule()
        {
            ManualTimeOffset = Settings.Default.TimeOffset;
            editing = false;

            List<string> Games = new List<string>();
            List<DateTime> Times = new List<DateTime>();
            List<string> EstTime = new List<string>();
            List<string> People = new List<string>();
            List<string> Consoles = new List<string>();
            List<string> Comments = new List<string>();
            AllGames.Clear();
            first = true;

            StreamReader reader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GDQ\Games.txt");
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                Games.Add(line);
            }
            reader.Close();

            reader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GDQ\Times.txt");
            while ((line = reader.ReadLine()) != null)
            {
                if (first)
                {
                    firstTime = Convert.ToDateTime(line);
                    first = false;
                }
                Times.Add(Convert.ToDateTime(line).AddMinutes(ManualTimeOffset));
            }
            reader.Close();

            reader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GDQ\Est.txt");
            while ((line = reader.ReadLine()) != null)
            {
                EstTime.Add(line);
            }
            reader.Close();

            reader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GDQ\People.txt");
            while ((line = reader.ReadLine()) != null)
            {
                People.Add(line);
            }
            reader.Close();

            reader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GDQ\Consoles.txt");
            while ((line = reader.ReadLine()) != null)
            {
                Consoles.Add(line);
            }
            reader.Close();

            reader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GDQ\Comments.txt");
            while ((line = reader.ReadLine()) != null)
            {
                Comments.Add(line);
            }
            reader.Close();

            for (int i = 0; i < Games.Count; i++)
            {
                AllGames.Add(new Game(Games[i], Times[i], TimeSpan.Parse(EstTime[i]), People[i], Consoles[i], Comments[i]));
            }

            AllGames.OrderBy(EEEEEEEEEEEE => EEEEEEEEEEEE.StartTime);
        }

        public static int FindCurrentGameByTime(DateTime t)
        {
            try
            {
                if(AllGames[0].StartTime > t)
                {
                    AllGames.Insert(0, new Game("Waiting", t.AddHours(-1), new TimeSpan(1, 0, 0), "Waiting", "Waiting", "Waiting"));
                    return FindCurrentGameByTime(t);
                }
                for(int i = 1; i < AllGames.Count; i++)
                {
                    if(AllGames[i-1].StartTime < t && AllGames[i].StartTime > t)
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

        public static void ChangeTimeBehind(int minutes)
        {
            LoadSchedule();
            editing = false;
        }
    }
}
