using System;
using System.Collections.Generic;
using System.Linq;

namespace FootBallTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();

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

        public int NumberOfPlayers
        {
            get
            {
                return this.players.Count; 
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(p => p.Name.Equals(playerName));

            if (player == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {name} team.");
            }

            if (players.Contains(player))
            {
                players.Remove(player);
            }
        }

        public double GetTeamRate()
        {
            double sumAllPlayers = 0;

            foreach (var player in players)
            {
                sumAllPlayers += player.EveragePlayerStats();
            }

            if (players.Count == 0)
            {
                return 0;
            }

            return Math.Round(sumAllPlayers / players.Count);
        }


    }
}
