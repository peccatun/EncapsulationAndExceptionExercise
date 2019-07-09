using System;
using System.Collections.Generic;
using System.Linq;

namespace FootBallTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            List<Team> teams = new List<Team>();


            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] input = command.Split(';', StringSplitOptions.RemoveEmptyEntries);

                    if (input[0] == "Team")
                    {
                        string teamName = input[1];

                        Team team = new Team(teamName);
                        teams.Add(team);
                    }
                    if (input[0] == "Add")
                    {
                        string teamName = input[1];
                        string playerName = input[2];
                        int endurance = int.Parse(input[3]);
                        int sprint = int.Parse(input[4]);
                        int dribble = int.Parse(input[5]);
                        int passing = int.Parse(input[6]);
                        int shooting = int.Parse(input[7]);
                        Team searchedTeam = teams.FirstOrDefault(t => t.Name.Equals(teamName));
                        if (searchedTeam == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            Stat stat = new Stat(endurance, sprint, dribble, passing, shooting);
                            Player player = new Player(playerName, stat);
                            searchedTeam.AddPlayer(player);
                        }
                    }
                    if (input[0] == "Remove")
                    {
                        string teamName = input[1];
                        string playerName = input[2];
                        Team removeFrom = teams.FirstOrDefault(t => t.Name.Equals(teamName));
                        if (removeFrom == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                        removeFrom.RemovePlayer(playerName);
                    }
                    if (input[0] == "Rating")
                    {
                        string teamName = input[1];

                        Team team = teams.FirstOrDefault(t => t.Name.Equals(teamName));
                        if (team == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                        Console.WriteLine($"{team.Name} - {team.GetTeamRate()}");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }


        }
    }
}
