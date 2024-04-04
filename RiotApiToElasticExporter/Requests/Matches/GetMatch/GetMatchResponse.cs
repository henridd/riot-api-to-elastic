using RiotApiToElasticExporter.Dtos;

namespace RiotApiToElasticExporter.Requests.Matches.GetMatch
{
    internal class GetMatchResponse
    {
        public MetadataDto Metadata { get; set; }
        public InfoDto Info { get; set; }
    }
}
