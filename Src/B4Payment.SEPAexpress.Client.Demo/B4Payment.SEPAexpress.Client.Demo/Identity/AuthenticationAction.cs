namespace B4Payment.SEPAexpress.Client.Demo.Identity
{
    internal class AuthenticationAction
    {
        private const string SecurityTokenKey = "Bearer";
        public async Task GetAccessTokenAsync()
        {
            var identityClient = new Client(Globals.BaseUrl, Globals.HttpClient);

            var authenticateRequest = new AuthenticateHttpRequest
            {
                TenantName = Globals.UserAuthorizationData.Tenant,
                UserName = Globals.UserAuthorizationData.UserName,
                Password = Globals.UserAuthorizationData.Password,
                ExpireInSeconds = 1000
            };

            var authenticateResponse = await identityClient.AuthenticateAsync(authenticateRequest);

            Globals.HttpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue(SecurityTokenKey, authenticateResponse.AccessToken);
        }
    }
}
