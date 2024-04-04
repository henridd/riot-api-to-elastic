using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.IndexManagement;
using RiotApiToElasticExporter.Dtos;

namespace RiotApiToElasticExporter.Elasticsearch
{
    internal class MatchIndexer
    {
        private readonly ElasticsearchClient _elasticsearchClient;
        private const string _indexName = "matches";

        public MatchIndexer(ElasticsearchClient elasticsearchClient)
        {
            _elasticsearchClient = elasticsearchClient;

            CreateIndex();
        }

        private void CreateIndex()
        {
            if (_elasticsearchClient.Indices.Exists(_indexName).Exists)
            {
                return;
            }

            var createIndexRequest = new CreateIndexRequestDescriptor(_indexName)
                .Mappings(map =>
                    map.Properties<MatchDocument>(prop =>
                        prop.LongNumber(m => m.GameId)
                        .Date(m => m.GameCreationDate)
                        .LongNumber(m => m.GameDuration)
                        .Date(m => m.GameEndDate)
                        .Keyword(m => m.GameMode)
                        .Keyword(m => m.GameName)
                        .Keyword(m => m.GameType)
                        .Keyword(m => m.GameVersion)
                        .IntegerNumber(m => m.MapId)
                        .IntegerNumber(m => m.PlayerAssists)
                        .IntegerNumber(m => m.PlayerBaronKills)
                        .IntegerNumber(m => m.PlayerBountyLevel)
                        .IntegerNumber(m => m.PlayerChampExperience)
                        .IntegerNumber(m => m.PlayerChampionId)
                        .IntegerNumber(m => m.PlayerChampLevel)
                        .Keyword(m => m.PlayerChampionName)
                        .IntegerNumber(m => m.PlayerConsumablesPurchased)
                        .IntegerNumber(m => m.PlayerDamageDealtToBuildings)
                        .IntegerNumber(m => m.PlayerDamageDealtToObjectives)
                        .IntegerNumber(m => m.PlayerDamageDealtToTurrets)
                        .IntegerNumber(m => m.PlayerDamageSelfMitigated)
                        .IntegerNumber(m => m.PlayerDeaths)
                        .IntegerNumber(m => m.PlayerDetectorWardsPlaces)
                        .IntegerNumber(m => m.PlayerDoubleKills)
                        .IntegerNumber(m => m.PlayerDragonKills)
                        .Boolean(m => m.PlayerFirstBloodAssist)
                        .Boolean(m => m.PlayerFirstTowerAssist)
                        .Boolean(m => m.PlayerFirstTowerKill)
                        .IntegerNumber(m => m.PlayerGoldEarned)
                        .IntegerNumber(m => m.PlayerGoldSpent)
                        .Keyword(m => m.PlayerIndividualPosition)
                        .IntegerNumber(m => m.PlayerInhibitorKills)
                        .IntegerNumber(m => m.PlayerInhibitorsLost)
                        .IntegerNumber(m => m.PlayerInhibitorTakedowns)
                        .IntegerNumber(m => m.PlayerItemsPurchased)
                        .IntegerNumber(m => m.PlayerKillingSprees)
                        .IntegerNumber(m => m.PlayerLargestMultiKill)
                        .IntegerNumber(m => m.PlayerLongestTimeSpentLiving)
                        .IntegerNumber(m => m.PlayerMagicDamageDealt)
                        .IntegerNumber(m => m.PlayerMagicDamageDealtToChampions)
                        .IntegerNumber(m => m.PlayerMagicDamageTaken)
                        .IntegerNumber(m => m.PlayerNeutralMinionsKilled)
                        .IntegerNumber(m => m.PlayerNexusKills)
                        .IntegerNumber(m => m.PlayerNexusLost)
                        .IntegerNumber(m => m.PlayerNexusTakedowns)
                        .IntegerNumber(m => m.PlayerObjectivesStolen)
                        .IntegerNumber(m => m.PlayerObjectivesStolenAssists)
                        .IntegerNumber(m => m.PlayerParticipantId)
                        .IntegerNumber(m => m.PlayerPentaKills)
                        .IntegerNumber(m => m.PlayerPhysicalDamageDealt)
                        .IntegerNumber(m => m.PlayerPhysicalDamageDealtToChampions)
                        .IntegerNumber(m => m.PlayerPhysicalDamageTaken)
                        .IntegerNumber(m => m.PlayerQuadraKills)
                        .Keyword(m => m.PlayerRole)
                        .IntegerNumber(m => m.PlayerSightWardsBoughtInGame)
                        .IntegerNumber(m => m.PlayerSpell1Casts)
                        .IntegerNumber(m => m.PlayerSpell2Casts)
                        .IntegerNumber(m => m.PlayerSpell3Casts)
                        .IntegerNumber(m => m.PlayerSpell4Casts)
                        .IntegerNumber(m => m.PlayerSummoner1Casts)
                        .IntegerNumber(m => m.PlayerSummoner1Id)
                        .IntegerNumber(m => m.PlayerSummoner2Casts)
                        .IntegerNumber(m => m.PlayerSummoner2Id)
                        .IntegerNumber(m => m.PlayerTimeCCingOthers)
                        .IntegerNumber(m => m.PlayerTimePlayed)
                        .IntegerNumber(m => m.PlayerTotalDamageDealt)
                        .IntegerNumber(m => m.PlayerTotalDamageDealtToChampions)
                        .IntegerNumber(m => m.PlayerTotalDamageShieldedOnTeammates)
                        .IntegerNumber(m => m.PlayerTotalDamageTaken)
                        .IntegerNumber(m => m.PlayerTotalHeal)
                        .IntegerNumber(m => m.PlayerTotalHealsOnTeammates)
                        .IntegerNumber(m => m.PlayerTotalMinionsKilled)
                        .IntegerNumber(m => m.PlayerTotalTimeCCDealt)
                        .IntegerNumber(m => m.PlayerTotalTimeSpentDead)
                        .IntegerNumber(m => m.PlayerTotalUnitsHealed)
                        .IntegerNumber(m => m.PlayerTripleKills)
                        .IntegerNumber(m => m.PlayerTrueDamageDealt)
                        .IntegerNumber(m => m.PlayerTrueDamageDealtToChampions)
                        .IntegerNumber(m => m.PlayerTrueDamageTaken)
                        .IntegerNumber(m => m.PlayerTurretsLost)
                        .IntegerNumber(m => m.PlayerTurretKills)
                        .IntegerNumber(m => m.PlayerTurretTakedowns)
                        .IntegerNumber(m => m.PlayerUnrealKills)
                        .IntegerNumber(m => m.PlayerVisionScore)
                        .IntegerNumber(m => m.PlayerVisionWardsBoughtInGame)
                        .IntegerNumber(m => m.PlayerWardsKilled)
                        .IntegerNumber(m => m.PlayerWardsPlaced)
                        .Boolean(m => m.GameEndedInEarlySurrender)
                        .Boolean(m => m.GameEndedInSurrender)
                        .Boolean(m => m.Win)));

            _elasticsearchClient.Indices.Create(createIndexRequest);
        }

        internal async Task IndexAsync(string matchId, InfoDto match, string puuid)
        {
            await _elasticsearchClient.IndexAsync(new MatchDocument(matchId, match, puuid), _indexName);
        }

        internal async Task<bool> MatchAlreadyIndexedAsync(string matchId)
        {
            var match = await _elasticsearchClient.GetAsync<MatchDocument>(_indexName, matchId);
            return match.Found;
        }
    }
}
