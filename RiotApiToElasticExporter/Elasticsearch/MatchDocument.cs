using RiotApiToElasticExporter.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApiToElasticExporter.Elasticsearch
{
    internal class MatchDocument
    {
        public MatchDocument()
        {
            
        }

        public MatchDocument(string matchId, InfoDto info, string puuid)
        {
            Id = matchId;
            GameCreation = info.GameCreation;
            GameDuration = info.GameDuration;
            GameEndTimespan = info.GameEndTimestamp; 
            GameId = info.GameId;
            GameMode = info.GameMode;
            GameName = info.GameName;
            GameStartTimestamp = info.GameStartTimestamp;
            GameType = info.GameType;
            GameVersion = info.GameVersion;
            MapId = info.MapId;

            var participant = info.Participants.First(x => x.Puuid == puuid);
            Win = participant.Win;
            PlayerRole = participant.Role;
            GameEndedInEarlySurrender = participant.GameEndedInEarlySurrender;
            GameEndedInSurrender = participant.GameEndedInSurrender;
            PlayerAssists = participant.Assists;
            PlayerBaronKills = participant.BaronKills;
            PlayerBountyLevel = participant.BountyLevel;
            PlayerChampExperience = participant.ChampExperience;
            PlayerChampionId = participant.ChampionId;
            PlayerChampionName = participant.ChampionName;
            PlayerChampLevel = participant.ChampLevel;
            PlayerConsumablesPurchased = participant.ConsumablesPurchased;
            PlayerDamageDealtToBuildings = participant.DamageDealtToBuildings;
            PlayerDamageDealtToObjectives = participant.DamageDealtToObjectives;
            PlayerDamageDealtToTurrets = participant.DamageDealtToTurrets;
            PlayerDamageSelfMitigated = participant.DamageSelfMitigated;
            PlayerDeaths = participant.Deaths;
            PlayerDetectorWardsPlaces = participant.DetectorWardsPlaces;
            PlayerDoubleKills = participant.DoubleKills;
            PlayerDragonKills = participant.DragonKills;
            PlayerFirstBloodAssist = participant.FirstBloodAssist;
            PlayerFirstTowerAssist = participant.FirstTowerAssist;
            PlayerFirstTowerKill = participant.FirstTowerKill;
            PlayerGoldEarned = participant.GoldEarned;
            PlayerGoldSpent = participant.GoldSpent;
            PlayerIndividualPosition = participant.IndividualPosition;
            PlayerInhibitorKills = participant.InhibitorKills;
            PlayerInhibitorsLost = participant.InhibitorsLost;
            PlayerInhibitorTakedowns = participant.InhibitorTakedowns;
            //TODO: Get names
            //PlayerItem0 = participant.Item0;
            //PlayerItem1 = participant.Item1;
            //PlayerItem2 = participant.Item2;
            //PlayerItem3 = participant.Item3;
            //PlayerItem4 = participant.Item4;
            //PlayerItem5 = participant.Item5;
            //PlayerItem6 = participant.Item6;
            PlayerItemsPurchased = participant.ItemsPurchased;
            PlayerKillingSprees = participant.KillingSprees;
            PlayerLargestMultiKill = participant.LargestMultiKill;
            PlayerLongestTimeSpentLiving = participant.LongestTimeSpentLiving;
            PlayerMagicDamageDealt = participant.MagicDamageDealt;
            PlayerMagicDamageDealtToChampions = participant.MagicDamageDealtToChampions;
            PlayerMagicDamageTaken = participant.MagicDamageTaken;
            PlayerNeutralMinionsKilled = participant.NeutralMinionsKilled;
            PlayerNexusKills = participant.NexusKills;
            PlayerNexusLost = participant.NexusLost;
            PlayerNexusTakedowns = participant.NexusTakedowns;
            PlayerObjectivesStolen = participant.ObjectivesStolen;
            PlayerObjectivesStolenAssists = participant.ObjectivesStolenAssists;
            PlayerParticipantId = participant.ParticipantId;
            PlayerPentaKills = participant.PentalKills;
            PlayerPhysicalDamageDealt = participant.PhysicalDamageDealt;
            PlayerPhysicalDamageDealtToChampions = participant.PhysicalDamageDealtToChampions;
            PlayerPhysicalDamageTaken = participant.PhysicalDamageTaken;
            PlayerQuadraKills = participant.QuadraKills;
            PlayerSightWardsBoughtInGame = participant.SightWardsBoughtInGame;
            PlayerSpell1Casts = participant.Spell1Casts;
            PlayerSpell2Casts = participant.Spell2Casts;
            PlayerSpell3Casts = participant.Spell3Casts;
            PlayerSpell4Casts = participant.Spell4Casts;
            PlayerSummoner1Casts = participant.Summoner1Casts;
            PlayerSummoner1Id = participant.Summoner1Id;
            PlayerSummoner2Casts = participant.Summoner2Casts;
            PlayerSummoner2Id = participant.Summoner2Id;
            PlayerTimeCCingOthers = participant.TimeCCingOthers;
            PlayerTimePlayed = participant.TimePlayed;
            PlayerTotalDamageDealt = participant.TotalDamageDealt;
            PlayerTotalDamageDealtToChampions = participant.TotalDamageDealtToChampions;
            PlayerTotalDamageShieldedOnTeammates = participant.TotalDamageShieldedOnTeammates;
            PlayerTotalDamageTaken = participant.TotalDamageTaken;
            PlayerTotalHeal = participant.TotalHeal;
            PlayerTotalHealsOnTeammates = participant.TotalHealsOnTeammates;
            PlayerTotalMinionsKilled = participant.TotalMinionsKilled;
            PlayerTotalTimeCCDealt = participant.TotalTimeCCDealt;
            PlayerTotalTimeSpentDead = participant.TotalTimeSpentDead;
            PlayerTotalUnitsHealed = participant.TotalUnitsHealed;
            PlayerTripleKills = participant.TripleKills;
            PlayerTrueDamageDealt = participant.TrueDamageDealt;
            PlayerTrueDamageDealtToChampions = participant.TrueDamageDealtToChampions;
            PlayerTrueDamageTaken = participant.TrueDamageTaken;
            PlayerTurretKills = participant.TurretKills;
            PlayerTurretsLost = participant.TurretsLost;
            PlayerTurretTakedowns = participant.TurretTakedowns;
            PlayerUnrealKills = participant.UnrealKills;
            PlayerVisionScore = participant.VisionScore;
            PlayerVisionWardsBoughtInGame = participant.VisionWardsBoughtInGame;
            PlayerWardsKilled = participant.WardsKilled;
            PlayerWardsPlaced = participant.WardsPlaced;
            PlayerKills = participant.Kills;
        }

        public string Id { get; set; }
        public long GameCreation { get; set; }
        public DateTimeOffset GameCreationDate => DateTimeOffset.FromUnixTimeMilliseconds(GameCreation);
        public long GameDuration { get; set; }
        public long GameEndTimespan { get; set; }
        public DateTimeOffset GameEndDate => DateTimeOffset.FromUnixTimeMilliseconds(GameEndTimespan);
        public long GameId { get; set; }
        public string GameMode { get; set; }
        public string GameName { get; set; }
        public long GameStartTimestamp { get; set; }
        public DateTimeOffset GameStartDate => DateTimeOffset.FromUnixTimeMilliseconds(GameStartTimestamp);
        public string GameType { get; set; }
        public string GameVersion { get; set; }
        public int MapId { get; set; }
        public int PlayerAssists { get; set; }
        public int PlayerBaronKills { get; set; }
        public int PlayerBountyLevel { get; set; }
        public int PlayerChampExperience { get; set; }
        public int PlayerChampLevel { get; set; }
        public int PlayerChampionId { get; set; }
        public string PlayerChampionName { get; set; }
        public int PlayerConsumablesPurchased { get; set; }
        public int PlayerDamageDealtToBuildings { get; set; }
        public int PlayerDamageDealtToObjectives { get; set; }
        public int PlayerDamageDealtToTurrets { get; set; }
        public int PlayerDamageSelfMitigated { get; set; }
        public int PlayerDeaths { get; set; }
        public int PlayerDetectorWardsPlaces { get; set; }
        public int PlayerDoubleKills { get; set; }
        public int PlayerDragonKills { get; set; }
        public bool PlayerFirstBloodAssist { get; set; }
        public bool PlayerFirstTowerAssist { get; set; }
        public bool PlayerFirstTowerKill { get; set; }
        public bool GameEndedInEarlySurrender { get; set; }
        public bool GameEndedInSurrender { get; set; }
        public int PlayerGoldEarned { get; set; }
        public int PlayerGoldSpent { get; set; }
        public string PlayerIndividualPosition { get; set; }
        public int PlayerInhibitorKills { get; set; }
        public int PlayerInhibitorTakedowns { get; set; }
        public int PlayerInhibitorsLost { get; set; }        
        public int PlayerItemsPurchased { get; set; }
        public int PlayerKills { get; set; }
        public int PlayerKillingSprees { get; set; }
        public int PlayerLargestMultiKill { get; set; }
        public int PlayerLongestTimeSpentLiving { get; set; }
        public int PlayerMagicDamageDealt { get; set; }
        public int PlayerMagicDamageDealtToChampions { get; set; }
        public int PlayerMagicDamageTaken { get; set; }
        public int PlayerNeutralMinionsKilled { get; set; }
        public int PlayerNexusKills { get; set; }
        public int PlayerNexusTakedowns { get; set; }
        public int PlayerNexusLost { get; set; }
        public int PlayerObjectivesStolen { get; set; }
        public int PlayerObjectivesStolenAssists { get; set; }
        public int PlayerParticipantId { get; set; }
        public int PlayerPentaKills { get; set; }
        public int PlayerPhysicalDamageDealt { get; set; }
        public int PlayerPhysicalDamageDealtToChampions { get; set; }
        public int PlayerPhysicalDamageTaken { get; set; }
        public int PlayerQuadraKills { get; set; }
        public string PlayerRole { get; set; }
        public int PlayerSightWardsBoughtInGame { get; set; }
        public int PlayerSpell1Casts { get; set; }
        public int PlayerSpell2Casts { get; set; }
        public int PlayerSpell3Casts { get; set; }
        public int PlayerSpell4Casts { get; set; }
        public int PlayerSummoner1Casts { get; set; }
        public int PlayerSummoner2Casts { get; set; }
        public int PlayerSummoner1Id { get; set; }
        public int PlayerSummoner2Id { get; set; }
        public bool TeamEarlySurendered { get; set; }
        public string TeamPosition { get; set; }
        public int PlayerTimeCCingOthers { get; set; }
        public int PlayerTimePlayed { get; set; }
        public int PlayerTotalDamageDealt { get; set; }
        public int PlayerTotalDamageDealtToChampions { get; set; }
        public int PlayerTotalDamageShieldedOnTeammates { get; set; }
        public int PlayerTotalDamageTaken { get; set; }
        public int PlayerTotalHeal { get; set; }
        public int PlayerTotalHealsOnTeammates { get; set; }
        public int PlayerTotalMinionsKilled { get; set; }
        public int PlayerTotalTimeCCDealt { get; set; }
        public int PlayerTotalTimeSpentDead { get; set; }
        public int PlayerTotalUnitsHealed { get; set; }
        public int PlayerTripleKills { get; set; }
        public int PlayerTrueDamageDealt { get; set; }
        public int PlayerTrueDamageDealtToChampions { get; set; }
        public int PlayerTrueDamageTaken { get; set; }
        public int PlayerTurretKills { get; set; }
        public int PlayerTurretTakedowns { get; set; }
        public int PlayerTurretsLost { get; set; }
        public int PlayerUnrealKills { get; set; }
        public int PlayerVisionScore { get; set; }
        public int PlayerVisionWardsBoughtInGame { get; set; }
        public int PlayerWardsKilled { get; set; }
        public int PlayerWardsPlaced { get; set; }
        public bool Win { get; set; }

        //TODO: Convert to string
        //public int PlayerItem0 { get; set; }
        //public int PlayerItem1 { get; set; }
        //public int PlayerItem2 { get; set; }
        //public int PlayerItem3 { get; set; }
        //public int PlayerItem4 { get; set; }
        //public int PlayerItem5 { get; set; }
        //public int PlayerItem6 { get; set; }
    }
}
