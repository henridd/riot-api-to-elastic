using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using RiotApiToElasticExporter;
using RiotApiToElasticExporter.Dtos;
using RiotApiToElasticExporter.Elasticsearch;
using RiotApiToElasticExporter.Requests.GetAccount;
using RiotApiToElasticExporter.Requests.Matches.GetMatch;
using RiotApiToElasticExporter.Requests.Matches.GetMatchIds;

var apiKey = "{insert key}";
var apiAddress = "https://europe.api.riotgames.com";

var elasticsearchClient = CreateElasticsearchClient();
var indexer = new MatchIndexer(elasticsearchClient);
var httpClient = new HttpClient();

httpClient.BaseAddress = new Uri(apiAddress);
httpClient.DefaultRequestHeaders.Add("X-Riot-Token", apiKey);

var account = GetAccount();

var puuid = await GetPuuidAsync(account, httpClient);

var matchesIds = await GetMatchesIdsAsync(puuid, httpClient);
Console.WriteLine($"Got {matchesIds.Count} matches");

await MigrateMatches(indexer, httpClient, puuid, matchesIds);

static Account GetAccount()
{
    while (true)
    {
        Console.WriteLine("Inform the username (ie.: Name#0000):");
        var user = Console.ReadLine();
        Account account;
        try
        {
            account = new Account(user);
            return account;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Invalid username. " + ex.Message);
        }
    }
}

static async Task<string> GetPuuidAsync(Account account, HttpClient httpClient)
{
    var request = new GetAccountDtoRequest(account, httpClient);

    return (await request.ExecuteAsync()).Puuid;
}

static async Task<List<string>> GetMatchesIdsAsync(string puuid, HttpClient httpClient)
{
    var current = 0;
    bool hasMoreItems;
    var itemsPerRequest = 100;
    var matchesIds = new List<string>();
    do
    {
        var request = new GetMatchIdsRequest(httpClient, puuid, current, itemsPerRequest);
        var response = await request.ExecuteAsync();
        matchesIds.AddRange(response);
        current += itemsPerRequest;

        hasMoreItems = response.Count() == itemsPerRequest;
    }
    while (hasMoreItems);

    return matchesIds;
}

static async Task<InfoDto> GetMatchInfoAsync(string matchId, HttpClient httpClient)
{
    var request = new GetMatchRequest(httpClient, matchId);

    return (await request.ExecuteAsync()).Info;
}

static ElasticsearchClient CreateElasticsearchClient()
{
    var settings = new ElasticsearchClientSettings(new Uri("https://localhost:9200"))
        .ServerCertificateValidationCallback((_, _, _, _) => true) // Beware: very risky! 
        .Authentication(new BasicAuthentication("elastic", "elastic"));
    return new ElasticsearchClient(settings);
}

static async Task MigrateMatches(MatchIndexer indexer, HttpClient httpClient, string puuid, List<string> matchesIds)
{
    foreach (var matchId in matchesIds)
    {
        Console.WriteLine($"Importing {matchId}");

        if (await indexer.MatchAlreadyIndexedAsync(matchId))
        {
            Console.WriteLine($"{matchId} already exists, ignoring...");
            continue;
        }

        var match = await GetMatchInfoAsync(matchId, httpClient);

        await indexer.IndexAsync(matchId, match, puuid);
    }

    Console.WriteLine($"{matchesIds.Count} matches imported!");
}