using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotAPI
{
    public class GlobalClass
    {
        public int APIcalls = 0;

        public string APIKeyValue { get; set; }
        public string APIKey
        {
            get
            {
                return APIurls.APIKeyBase + APIKeyValue;
            }
            set
            {
                APIKeyValue = value;
            }
        }

        public Dictionary<int, string> Champions = new Dictionary<int, string>();
        public List<MatchSchema> matches = new List<MatchSchema>();
        public List<MatchDto> detailedMatches = new List<MatchDto>();
        public List<PlayerStats> stats = new List<PlayerStats>();

        public Player player = new Player();
        public Summoner summoner = new Summoner();
        public List<MatchPreview> matchList = new List<MatchPreview>(20);

        public MainWindow mainWindow;
        public UserLookup userLookup;
        public MatchListPage matchListPage;
        public MatchDetailsPage matchDetails;
        public ErrorPage errorPage;

        public void PopulateChampionList()
        {

        }
    }
}
