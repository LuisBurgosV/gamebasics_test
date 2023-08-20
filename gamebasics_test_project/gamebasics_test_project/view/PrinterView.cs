using gamebasics_test_project.model;
using gamebasics_test_project.models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamebasics_test_project.view
{
    public class PrinterView
    {
        public static void PrintInitialization()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            string message = "Welcome to Simulator!";
            int width = message.Length + 10;
            int height = 7;

            Console.WriteLine(new string('*', width));

            int padding = (width - message.Length) / 2;
            for (int i = 0; i < (height - 3) / 2; i++)
            {
                Console.WriteLine("*" + new string(' ', width - 2) + "*");
            }

            Console.WriteLine("*" + new string(' ', padding) + message + new string(' ', width - padding - message.Length - 2) + "*");

            for (int i = 0; i < (height - 3) / 2; i++)
            {
                Console.WriteLine("*" + new string(' ', width - 2) + "*");
            }

            Console.WriteLine(new string('*', width) + "\n");
            Console.ResetColor();
        }

        public static void PrintFakeLoading()
        {
            Thread.Sleep(500);
            Console.WriteLine("Loading Teams...");
            Thread.Sleep(500);
            Console.WriteLine("Teams Loaded!" + "\n");
            Console.WriteLine("-----------------------" + "\n");

            Thread.Sleep(500);
            Console.WriteLine("Loading Players...");
            Thread.Sleep(500);
            Console.WriteLine("players Loaded!" + "\n");
            Console.WriteLine("-----------------------" + "\n");

            Thread.Sleep(500);
            Console.WriteLine("Simulating...");
            Thread.Sleep(500);
            Console.WriteLine("-----------------------" + "\n");
        }

        public static void DisplayRoundMatchResults(List<MatchResult> matchResults)
        {
            foreach (MatchResult match in matchResults)
            {
                Console.WriteLine($"{match.Team1.Name}  {match.Team1Goals} - {match.Team2Goals}  {match.Team2.Name}");
            }
            Console.WriteLine();
        }

        public static void DisplayFinalResults(List<MatchResult> finalMatchResults)
        {
            Dictionary<Team, TeamResult> teamInfoMap = new Dictionary<Team, TeamResult>();

            foreach (var result in finalMatchResults)
            {
                if (!teamInfoMap.ContainsKey(result.Team1))
                {
                    teamInfoMap[result.Team1] = new TeamResult(result.Team1);
                }

                if (!teamInfoMap.ContainsKey(result.Team2))
                {
                    teamInfoMap[result.Team2] = new TeamResult(result.Team2);
                }

                teamInfoMap[result.Team1].GoalsScored += result.Team1Goals;
                teamInfoMap[result.Team1].GoalsConceded += result.Team2Goals;

                teamInfoMap[result.Team2].GoalsScored += result.Team2Goals;
                teamInfoMap[result.Team2].GoalsConceded += result.Team1Goals;

                if (result.Team1Goals > result.Team2Goals)
                {
                    teamInfoMap[result.Team1].Wins++;
                    teamInfoMap[result.Team2].Losses++;
                }
                else if (result.Team2Goals > result.Team1Goals)
                {
                    teamInfoMap[result.Team2].Wins++;
                    teamInfoMap[result.Team1].Losses++;
                }
                else if (result.Team2Goals == result.Team1Goals)
                {
                    teamInfoMap[result.Team2].Wins++;
                    teamInfoMap[result.Team2].Wins++;
                }
            }

            var rankedTeams = teamInfoMap.Values.OrderByDescending(info => info.Wins)
                                            .ThenBy(info => info.Losses)
                                            .ThenByDescending(info => info.GoalsScored - info.GoalsConceded)
                                            .ToList();

            Console.WriteLine("{0,-10} {1,-20} {2,-10} {3,-10}", "Position", "Team", "Win", "Lose");
            for (int i = 0; i < rankedTeams.Count; i++)
            {
                var teamInfo = rankedTeams[i];
                Console.WriteLine("{0,-10} {1,-20} {2,-10} {3,-10}", i + 1, teamInfo.Team.Name, teamInfo.Wins, teamInfo.Losses);
            }

            Console.WriteLine("\n\n");
        }

        internal static void PrintFinalization()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGreen;

            string message = "Simulation Completed!";
            int width = message.Length + 10;
            int height = 7;

            Console.WriteLine(new string('*', width));

            int padding = (width - message.Length) / 2;
            for (int i = 0; i < (height - 3) / 2; i++)
            {
                Console.WriteLine("*" + new string(' ', width - 2) + "*");
            }

            Console.WriteLine("*" + new string(' ', padding) + message + new string(' ', width - padding - message.Length - 2) + "*");

            for (int i = 0; i < (height - 3) / 2; i++)
            {
                Console.WriteLine("*" + new string(' ', width - 2) + "*");
            }

            Console.WriteLine(new string('*', width) + "\n");
            Console.ResetColor();
        }
    }
}
