using gamebasics_test_project.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamebasics_test_project.model
{
    public class TeamResult
    {
        public Team Team { get; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }

        public TeamResult(Team team)
        {
            Team = team;
        }
    }
}
