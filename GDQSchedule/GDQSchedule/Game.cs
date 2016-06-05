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
        public string Comment;
        public string Category;

        public Game(string name, DateTime startTime, TimeSpan estLength, string participants, string comment, string category)
        {
            Name = name;
            StartTime = startTime;
            EstimatedLength = estLength;
            Participants = participants;
            Comment = comment;
            Category = category;
        }
    }
}
