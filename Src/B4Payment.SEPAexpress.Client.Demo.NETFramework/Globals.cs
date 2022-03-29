using System;
using System.Net.Http;

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

        public const string Tenant = "QuickStartTenant";

        public const string UserName = "admin";

        public const string Password = "password";

        public const string MerchandId = "ed2a8e8a87f2e7a6093a8969b3874d65";

        public const string ConnectorId = "6f1cebbb863ffe22d4f73ac2aebedaf3";

        public const string Iban = "DE86100000001234400013";

        public static string GetUniqueString() => Guid.NewGuid().ToString().Replace("-", string.Empty);
    }
}
