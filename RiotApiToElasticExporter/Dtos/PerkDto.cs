namespace RiotApiToElasticExporter.Dtos
{
    internal class PerkDto
    {
        public PerkStatsDto StatPerks { get; set; }
        public IEnumerable<PerkStyleDto> Styles { get; set; }
    }
}
