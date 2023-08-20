using gamebasics_test_project.model;
using gamebasics_test_project.models;
using gamebasics_test_project.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace gamebasics_test_project.controller
{
    public class SimulatorController
    {
        List<Team> _teams;
        public SimulatorController(List<Team> teams)
        {
            _teams = teams;
        }

        public void InitializeSimulation()
        {
            List<MatchResult> roundMatchResults = new List<MatchResult>();
            List<MatchResult> finalMatchResults = new List<MatchResult>();

            for (int round = 1; round <= 3; round++)
            {
                Console.WriteLine($"--- Round {round} Matches ---");

                roundMatchResults = SimulateMatches(_teams);
                finalMatchResults.AddRange(roundMatchResults);

                // Display match results of this round
                PrinterView.DisplayRoundMatchResults(roundMatchResults);
            }

            PrinterView.DisplayFinalResults(finalMatchResults);
        }

        private List<MatchResult> SimulateMatches(List<Team> teams)
        {
            List<MatchResult> matchResults = new List<MatchResult>();
            Random random = new Random();

            List<Team> shuffledTeams = teams.OrderBy(x => random.Next()).ToList();

            while (shuffledTeams.Count >= 2)
            {
                Team team1 = shuffledTeams[0];
                shuffledTeams.RemoveAt(0);

                Team team2 = shuffledTeams[0];
                shuffledTeams.RemoveAt(0);

                matchResults.Add(StartMatch(team1, team2));
            }

            return matchResults;
        }

        private MatchResult StartMatch(Team team1, Team team2)
        {
            team1.TotalScore = team1.Players.Sum(player => player.Score);
            team2.TotalScore = team2.Players.Sum(player => player.Score);
            Random random = new Random();
            MatchResult matchResult = new()
            {
                Team1 = team1,
                Team2 = team2
            };

            //Every 10 minutes of real match will be a goal opportunity (in my world)
            for (int i = 0; i <= 90; i += 10)
            {
                Thread.Sleep(100);

                //First, the goal opportunity
                double goalOpportunityProbability = (double)team1.TotalScore / (double)(team1.TotalScore + team2.TotalScore);
                double randomValue = random.NextDouble();
                var oportunityGoalTeam = randomValue < goalOpportunityProbability ? team1 : team2;

                //Second, the goal
                double probabilidad = (double)oportunityGoalTeam.TotalScore / 700;
                random = new Random();
                if (random.NextDouble() < probabilidad)
                {
                    if (oportunityGoalTeam.Name == team1.Name)
                    {
                        matchResult.Team1Goals++;
                    }
                    else
                    {
                        matchResult.Team2Goals++;
                    }
                }
            }

            return matchResult;
        }
    }
}