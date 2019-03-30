using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotAPI
{
    class APIurls
    {
        public static string SavedFilesDirectory = @".\SavedResults\";
        public static string APIKeyBase = "?api_key=";
        public static string APIKeyValue = "";
        public static string APIKey = APIKeyBase + APIKeyValue;
        public static string BaseURL = "https://na1.api.riotgames.com";
        public static string SummonerLookupURL = BaseURL + "/lol/summoner/v4/summoners/by-name/";
        public static string MatchListURL = BaseURL + "/lol/match/v4/matchlists/by-account/";
        public static string MatchURL = BaseURL + "/lol/match/v4/matches/";
        public static string ChampionInfoURL = "http://ddragon.leagueoflegends.com/cdn/6.24.1/data/en_US/champion.json";
    }
}
