namespace B4Payment.SEPAexpress.Client.Demo.Identity
{
    internal class AuthenticationAction
    {
        public async Task<string> GetAccessTokenAsync()
        {
            var identityClient = new Client(Globals.BaseUrl, Globals.HttpClient);

            var authenticateRequest = new AuthenticateHttpRequest
            {
                TenantName = "",
                UserName = "",
                Password = "",
                ExpireInSeconds = 1000
            };

            var authenticateResponse = await identityClient.AuthenticateAsync(authenticateRequest);

            return authenticateResponse.AccessToken;
        }
    }
}
