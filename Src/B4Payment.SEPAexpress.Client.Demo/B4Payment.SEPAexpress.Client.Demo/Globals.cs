namespace B4Payment.SEPAexpress.Client.Demo
{
    internal static class Globals
    {
        /// <summary>
        /// That is for demo environment. For production code use IHttpClientFactory
        /// <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests"/>
        /// </summary>
        public static HttpClient HttpClient { get; set; } = new HttpClient();

        /// <summary>
        /// That is for demo environment. For production read it from configuration 
        /// </summary>
        public const string BaseUrl = "https://sepaexpress-sand-fx.azurewebsites.net";

        public static UserAuthorizationData UserAuthorizationData { get; set; } = new UserAuthorizationData
        {
            Tenant = "QuickStartTenant",
            UserName = "admin",
            Password = "password"
        };
    }

    internal class UserAuthorizationData
    {
        public string Tenant { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
