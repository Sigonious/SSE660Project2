using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiotAPI
{
    public class Match
    {
        public int seasonID = 0;
        public int queueID = 0;
        public double gameID = 0;
        public string[] participantIdentities;
        public string gameVersion = "";
        public string platformId = "";
        public string gameMode = "";
        public int mapId = 0;
        public string gameType = "";
        public string[] teams;
        public string[] participants;
        public long gameDuration = 0;
        public long gameCreation = 0;

        public Match()
        {

        }
    }
}
