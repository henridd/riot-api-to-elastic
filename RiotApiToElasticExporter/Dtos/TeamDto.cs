namespace RiotApiToElasticExporter.Dtos
{
    internal class TeamDto
    {
        public IEnumerable<BanDto> BanDto { get; set; }
        public ObjectivesDto Objectives { get; set; }
        public int TeamId { get; set; }
        public bool Win { get; set; }
    }
}
