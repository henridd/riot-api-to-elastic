namespace RiotApiToElasticExporter.Requests.Matches.GetMatchIds
{
    internal class GetMatchIdsRequest : BaseGetRequest<IEnumerable<string>>
    {
        private readonly string _puuid;
        private readonly int _start;
        private readonly int _count;

        public override string Url => $"/lol/match/v5/matches/by-puuid/{_puuid}/ids?start={_start}&count={_count}";

        public GetMatchIdsRequest(HttpClient httpClient, string puuid, int start, int count) : base(httpClient)
        {
            _puuid = puuid;
            _start = start;
            _count = count;
        }
    }
}
