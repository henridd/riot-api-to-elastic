namespace RiotApiToElasticExporter.Requests.Matches.GetMatchIds
{
    internal struct GetMatchIdsResponse
    {
        public IEnumerable<string> Ids { get; set; }
    }
}
