using B4Payment.SEPAexpress.Client.Demo.Utils;
using B4Payment.SEPAexpress.Client.Identity;

namespace B4Payment.SEPAexpress.Client.Demo.Identity
{
    internal class SampleUserAuthentication
    {
        private const string SecurityTokenKey = "Bearer";
        private const int TokenExpirationInSeconds = 1000;

        public async Task GetAccessTokenAsync()
        {
            ConsoleUtils.DisplayActionStart("User authentication");

            var sepaExpressIdentityApiClient = new SepaExpressIdentityClient(Globals.BaseUrl, Globals.HttpClient);

            var authenticateRequest = new AuthenticateHttpRequest
            {
                TenantName = Globals.Tenant,
                UserName = Globals.UserName,
                Password = Globals.Password,
                ExpireInSeconds = TokenExpirationInSeconds
            };

            try
            {
                var authenticateResponse = await sepaExpressIdentityApiClient.AuthenticateAsync(authenticateRequest);

                Globals.HttpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue(SecurityTokenKey, authenticateResponse.AccessToken);
            }
            catch (ApiException apix)
            {
                ConsoleUtils.DisplayException(apix);
                throw;
                throw;
            }
        }
    }
}
