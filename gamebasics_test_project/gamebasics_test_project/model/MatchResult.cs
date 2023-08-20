using gamebasics_test_project.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamebasics_test_project.model
{
    public class MatchResult
    {
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public int Team1Goals { get; set; }
        public int Team2Goals { get;set; }
    }
}
