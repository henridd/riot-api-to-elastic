using System.Text.Json;

namespace RiotApiToElasticExporter.Requests.GetAccount
{
    internal class GetAccountDtoRequest : BaseGetRequest<GetAccountDtoResponse>
    {
        private readonly Account _account;

        public override string Url => $"/riot/account/v1/accounts/by-riot-id/{_account.GameName}/{_account.TagLine}";

        public GetAccountDtoRequest(Account account, HttpClient httpClient) : base(httpClient) 
        {
            _account = account;
        }
    }
}
