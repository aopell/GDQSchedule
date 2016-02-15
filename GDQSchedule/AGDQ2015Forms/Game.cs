using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDQSchedule
{
    public class Game
    {
        public string Name;
        public DateTime StartTime;
        public TimeSpan EstimatedLength;
        public string Participants;
        public string Console;
        public string Comment;

        public Game(string name, DateTime startTime, TimeSpan estLength, string participants, string console, string comment)
        {
            Name = name;
            StartTime = startTime;
            EstimatedLength = estLength;
            Participants = participants;
            Console = console;
            Comment = comment;
        }
    }
}
