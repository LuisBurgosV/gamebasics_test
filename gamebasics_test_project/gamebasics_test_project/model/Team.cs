using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamebasics_test_project.models
{
    public class Rootobject
    {
        public List<Team> Teams { get; set; }
    }

    public class Team
    { 
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public int TotalScore { get; set; }
        public int Goals { get; set; }
    }
}
