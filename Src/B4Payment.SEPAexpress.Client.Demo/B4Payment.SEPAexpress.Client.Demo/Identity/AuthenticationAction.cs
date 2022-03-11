namespace B4Payment.SEPAexpress.Client.Demo.Identity
{
    internal class AuthenticationAction
    {
        private const string SecurityTokenKey = "Bearer";
        public async Task GetAccessTokenAsync()
        {
            ConsoleUtils.DisplayActionStart("User authentication");

            var identityClient = new Client(Globals.BaseUrl, Globals.HttpClient);

            var authenticateRequest = new AuthenticateHttpRequest
            {
                TenantName = Globals.Tenant,
                UserName = Globals.UserName,
                Password = Globals.Password,
                ExpireInSeconds = 1000
            };

            var authenticateResponse = await identityClient.AuthenticateAsync(authenticateRequest);

            Globals.HttpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue(SecurityTokenKey, authenticateResponse.AccessToken);
        }
    }
}
