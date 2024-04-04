namespace RiotApiToElasticExporter.Dtos
{
    internal class MetadataDto
    {
        public string DataVersion { get; set; }
        public string MatchId { get; set; }
        public IEnumerable<string> Participants { get; set; }
    }
}
