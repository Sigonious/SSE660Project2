﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotAPI
{
    public class JSONObjectSchema
    {
        [JsonProperty("matches")]
        public MatchSchema Match { get; set; }
    }

    public class MatchlistDto
    {
        public List<MatchSchema> matches { get; set; }
        public int totalGames { get; set; }
        public int startIndex { get; set; }
        public int endIndex { get; set; }
    }

    public class MatchSchema
    {
        public string platformId { get; set; }
        public long gameId { get; set; }
        public int champion { get; set; }
        public int queue { get; set; } 
        public int season { get; set; }
        public long timestamp { get; set; }
        public string role { get; set; }
        public string lane { get; set; }
    }

    public class MatchDto
    {
        public int seasonId { get; set; }
        public int queueId { get; set; }
        public long gameId { get; set; }
        public List<ParticipantIdentityDto> participantIdentities { get; set; }
        public string gameVersion { get; set; }
        public string platformId { get; set; }
        public string gameMode { get; set; }
        public int mapId { get; set; }
        public string gameType { get; set; }
        public List<TeamStatsDto> teams { get; set; }
        public List<ParticipantDto> participants { get; set; }
        public long gameDuration { get; set; }
        public long gameCreation { get; set; }
    }

    public class ParticipantIdentityDto
    {
        public PlayerDto player { get; set; }
        public int participantId { get; set; }
    }

    public class PlayerDto
    {
        public string currentPlatformId { get; set; }
        public string summonerName { get; set; }
        public string matchHistoryUri { get; set; }
        public string platformId { get; set; }
        public string currentAccountId { get; set; }
        public int profileIcon { get; set; }
        public string summonerId { get; set; }
        public string accountId { get; set; }
    }

    public class TeamStatsDto
    {
        public bool firstDragon { get; set; }
        public bool firstInhibitor { get; set; }
        public List<TeamBansDto> bans { get; set; }
        public int baronKills { get; set; }
        public bool firstRiftHerald { get; set; }
        public bool firstBaron { get; set; }
        public int riftHeraldKills { get; set; }
        public bool firstBlood { get; set; }
        public int teamId { get; set; }
        public bool firstTower { get; set; }
        public int vilemawKills { get; set; }
        public int inhibitorKills { get; set; }
        public int towerKills { get; set; }
        public int dominionVictoryScore { get; set; }
        public string win { get; set; }
        public int dragonKills { get; set; }
}

    public class TeamBansDto
    {
        public int pickTurn { get; set; }
        public int championId { get; set; }
    }

    public class ParticipantDto
    {
        public PlayerStats stats { get; set; }
        public int participantId { get; set; }
        public List<RuneDto> runes { get; set; }
        public ParticipantTimelineDto timeline { get; set; }
        public int teamId { get; set; }
        public int spell2Id { get; set; }
        public List<MasteryDto> masteries { get; set; }
        public string highestAchievedSeasonTier { get; set; }
        public int spell1Id { get; set; }
        public int championId { get; set; }
    }

    public class PlayerStats
    {
        public bool firstBloodAssist { get; set; }
        public long visionScore { get; set; }
        public long magicDamageDealtToChampions { get; set; }
        public long damageDealtToObjectives { get; set; }
        public int totalTimeCrowdControlDealt { get; set; }
        public int longestTimeSpentLiving { get; set; }
        public int perk1Var1 { get; set; }
        public int perk1Var3 { get; set; }
        public int perk1Var2 { get; set; }
        public int tripleKills { get; set; }
        public int perk3Var3 { get; set; }
        public int nodeNeutralizeAssist { get; set; }
        public int perk3Var2 { get; set; }
        public int playerScore9 { get; set; }
        public int playerScore8 { get; set; }
        public int kills { get; set; }
        public int playerScore1 { get; set; }
        public int playerScore0 { get; set; }
        public int playerScore3 { get; set; }
        public int playerScore2 { get; set; }
        public int playerScore5 { get; set; }
        public int playerScore4 { get; set; }
        public int playerScore7 { get; set; }
        public int playerScore6 { get; set; }
        public int perk5Var1 { get; set; }
        public int perk5Var3 { get; set; }
        public int perk5Var2 { get; set; }
        public int totalScoreRank { get; set; }
        public int neutralMinionsKilled { get; set; }
        public long damageDealtToTurrets { get; set; }
        public long physicalDamageDealtToChampions { get; set; }
        public int nodeCapture { get; set; }
        public int largestMultiKill { get; set; }
        public int perk2Var2 { get; set; }
        public int perk2Var3 { get; set; }
        public int totalUnitsHealed { get; set; }
        public int perk2Var1 { get; set; }
        public int perk4Var1 { get; set; }
        public int perk4Var2 { get; set; }
        public int perk4Var3 { get; set; }
        public int wardsKilled { get; set; }
        public int largestCriticalStrike { get; set; }
        public int largestKillingSpree { get; set; }
        public int quadraKills { get; set; }
        public int teamObjective { get; set; }
        public int magicDamageDealt { get; set; }
        public int item2 { get; set; }
        public int item3 { get; set; }
        public int item0 { get; set; }
        public int neutralMinionsKilledTeamJungle { get; set; }
        public int item6 { get; set; }
        public int item4 { get; set; }
        public int item5 { get; set; }
        public int perk1 { get; set; }
        public int perk0 { get; set; }
        public int perk3 { get; set; }
        public int perk2 { get; set; }
        public int perk5 { get; set; }
        public int perk4 { get; set; }
        public int perk3Var1 { get; set; }
        public long damageSelfMitigated { get; set; }
        public long magicalDamageTaken { get; set; }
        public bool firstInhibitorKill { get; set; }
        public long trueDamageTaken { get; set; }
        public int nodeNeutralize { get; set; }
        public int assists { get; set; }
        public int combatPlayerScore { get; set; }
        public int perkPrimaryStyle { get; set; }
        public int goldSpent { get; set; }
        public long trueDamageDealt { get; set; }
        public int participantId { get; set; }
        public long totalDamageTaken { get; set; }
        public long physicalDamageDealt { get; set; }
        public int sightWardsBoughtInGame { get; set; }
        public long totalDamageDealtToChampions { get; set; }
        public long physicalDamageTaken { get; set; }
        public int totalPlayerScore { get; set; }
        public bool win { get; set; }
        public int objectivePlayerScore { get; set; }
        public long totalDamageDealt { get; set; }
        public int item1 { get; set; }
        public int neutralMinionsKilledEnemyJungle { get; set; }
        public int deaths { get; set; }
        public int wardsPlaced { get; set; }
        public int perkSubStyle { get; set; }
        public int turretKills { get; set; }
        public bool firstBloodKill { get; set; }
        public long trueDamageDealtToChampions { get; set; }
        public int goldEarned { get; set; }
        public int killingSprees { get; set; }
        public int unrealKills { get; set; }
        public int altarsCaptured { get; set; }
        public bool firstTowerAssist { get; set; }
        public bool firstTowerKill { get; set; }
        public int champLevel { get; set; }
        public int doubleKills { get; set; }
        public int nodeCaptureAssist { get; set; }
        public int inhibitorKills { get; set; }
        public bool firstInhibitorAssist { get; set; }
        public int perk0Var1 { get; set; }
        public int perk0Var2 { get; set; }
        public int perk0Var3 { get; set; }
        public int visionWardsBoughtInGame { get; set; }
        public int altarsNeutralized { get; set; }
        public int pentaKills { get; set; }
        public long totalHeal { get; set; }
        public int totalMinionsKilled { get; set; }
        public long timeCCingOthers { get; set; }
    }

    public class ParticipantTimelineDto
    {
        public string lane { get; set; }
        public int participantId { get; set; }
        public Dictionary<string, double> csDiffPerMinDeltas { get; set; }
        public Dictionary<string, double> goldPerMinDeltas { get; set; }
        public Dictionary<string, double> xpDiffPerMinDeltas { get; set; }
        public Dictionary<string, double> creepsPerMinDeltas { get; set; }
        public Dictionary<string, double> xpPerMinDeltas { get; set; }
        public string role { get; set; }
        public Dictionary<string, double> damageTakenDiffPerMinDeltas { get; set; }
        public Dictionary<string, double> damageTakenPerMinDeltas { get; set; }
    }

    public class RuneDto
    {
        public int runeId { get; set; }
        public int rank { get; set; }
    }

    public class MasteryDto
    {
        public int masteryId { get; set; }
        public int rank { get; set; }
    }
}
