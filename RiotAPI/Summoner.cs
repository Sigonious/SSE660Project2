﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotAPI
{
    public class Summoner
    {
        public int profileIconID { get; set; }
        public string name { get; set; }
        public string puuid { get; set; }
        public long summmonerLevel { get; set; }
        public long revisionDate { get; set; }
        public string id { get; set; }
        public string accountID { get; set; }
    }
}
