namespace RiotApiToElasticExporter.Requests.Matches.GetMatch
{
    internal class GetMatchRequest : BaseGetRequest<GetMatchResponse>
    {
        private string _matchId;

        public override string Url => $"/lol/match/v5/matches/{_matchId}";

        public GetMatchRequest(HttpClient httpClient, string matchId) : base(httpClient)
        {
            _matchId = matchId;
        }
    }
}
