using System;

namespace FootBallTeamGenerator
{
    public class Player
    {
        private string name;
        private Stat stats;

        public Player(string name, Stat stats)
        {
            Name = name;
            Stats = stats;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value == " " || value == null || value == string.Empty)
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public Stat Stats
        {
            get
            {
                return this.stats;
            }
            private set
            {
                this.stats = value;
            }
        }

        public double EveragePlayerStats()
        {
            return (double)(stats.Endurance + stats.Sprint + stats.Dribble + stats.Passing + stats.Shooting) / 5;
        }
    }
}
