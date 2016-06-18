using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDQSchedule
{
    public static class Strings
    {
        public static string SchedulePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GDQ\Schedule.txt";
        public static string InfoPanelPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GDQ\Info.txt";

        public static string Event = "Event";
        public static string ScheduleItem = "Game";
        public static string BaseStatus = "Currently Operating ";
        public static string OnTimeStatus = "On Schedule";
        public static string BehindStatus = " Minutes Behind";
        public static string AheadStatus = " Minutes Ahead";
        public static string Current = "Current " + ScheduleItem;
        public static string Next = "Next " + ScheduleItem;
        public static string Following = "Following " + ScheduleItem;
        public static string After = "After That";
        public static string Started = "Started At";
        public static string WillStart = "Will Start At";
        public static string EstLength = "Estimated Length";
        public static string People = "Runner(s)";
        public static string CurrentProgress = "Running for Approximately";
        public static string NextScheduleItem = "Run Estimated to be Completed, Next game starts in";
        /// <summary>
        /// NextScheduleItem should contain this keyword
        /// </summary>
        public static string CompletedKeyword = "Completed";
        public static string CurrentTime = "Current Time";
        public static string Loading = "[Loading...]";
        public static string NoScheduleItem = "No Game";
        public static string Missing = "None";
        public static string Waiting = "Waiting";
        public static string TimeUntilEvent = "Time Until Event";
        private static string WaitingStatusOverride = null;
        public static string WaitingStatus
        {
            get
            {
                if (WaitingStatusOverride == null)
                {
                    return Waiting + " for " + Info.CurrentEventName + " to Begin";
                }
                else
                {
                    return WaitingStatusOverride;
                }
            }
            set
            {
                WaitingStatusOverride = value;
            }
        }
    }
}
