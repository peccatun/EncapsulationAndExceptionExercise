using System;

namespace FootBallTeamGenerator
{
    public class Stat
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stat(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                HasValidStats(value, "Endurance");
                this.endurance = value;

            }
        }

        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                HasValidStats(value, "Sprint");
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                HasValidStats(value, "Dribble");
                this.dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                HasValidStats(value, "Passing");
                this.passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                HasValidStats(value,"Shooting");
                this.shooting = value;
            }
        }


        #region private

        private void HasValidStats(int value, string statName)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{statName} should be between 0 and 100.");
            }
        }

        #endregion
    }
}
