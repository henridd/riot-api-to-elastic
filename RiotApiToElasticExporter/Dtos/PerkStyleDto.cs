namespace RiotApiToElasticExporter.Dtos
{
    internal class PerkStyleDto
    {
        public string Description { get; set; }
        public IEnumerable<PerkStyleSelectionDto> Selections { get; set; }
        public int Style { get; set; }
    }
}
