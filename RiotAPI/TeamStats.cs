using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiotAPI
{
    public class TeamStats
    {
        public bool firstDragon = false;
        public bool firstInhibitor = false;
        public string[] bans;
        public int baronKills = 0;
        public bool firstRiftHerald = false;
        public bool firstBaron = false;
        public int riftHeraldKills = 0;
        public bool firstBlood = false;
        public int teamId = 0;
        public bool firstTower = false;
        public int vilemawKills = 0;
        public int inhibitorKills = 0;
        public int towerKills = 0;
        public int dominionVictoryScore = 0;
        public string win = "";
        public int dragonKills = 0;

        public TeamStats()
        {

        }
    }
}
