namespace RiotApiToElasticExporter.Dtos
{
    internal class InfoDto
    {
        public long GameCreation { get; set; }
        public DateTimeOffset GameCreationDate => DateTimeOffset.FromUnixTimeMilliseconds(GameCreation);
        public long GameDuration { get; set; }
        public long GameEndTimestamp { get; set; }
        public DateTimeOffset GameEndDate => DateTimeOffset.FromUnixTimeMilliseconds(GameEndTimestamp);
        public long GameId { get; set; }
        public string GameMode { get; set; }
        public string GameName { get; set; }
        public long GameStartTimestamp { get; set; }
        public DateTimeOffset GameStartDate => DateTimeOffset.FromUnixTimeMilliseconds(GameStartTimestamp);
        public string GameType { get; set; }
        public string GameVersion { get; set; }
        public int MapId { get; set; }
        public IEnumerable<ParticipantDto> Participants { get; set; }
        public string PlatformId { get; set; }
        public int QueueId { get; set; }
        public IEnumerable<TeamDto> Teams { get; set; }
        public string TournamentCode { get; set; }
    }
}
