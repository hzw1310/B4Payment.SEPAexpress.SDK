namespace B4Payment.SEPAexpress.Client.Demo
{
    internal class CreateNewCustomerAction
    {
        /// <summary>
        /// Creates new customer and returns his ID.
        /// </summary>
        /// <returns>Created customerId</returns>
        public async Task<string> ExecuteAsync()
        {
            try
            {
                Globals.DisplayActionStart("Creating customer");

                // create customer
                var createCustomerHttpRequest = CreateCustomerHttpRequest();
                var client = new Client(Globals.BaseUrl, Globals.HttpClient);
                var createCustomerResponse = await client.CustomersPOSTAsync(createCustomerHttpRequest);

                // display result
                Globals.DisplayResponseObject("Customer created", createCustomerResponse);

                return createCustomerResponse.Customer.Id;
            }
            catch (ApiException apiex)
            {
                Globals.DisplayException(apiex);
                throw;
            }
        }

        private CreateCustomerHttpRequest CreateCustomerHttpRequest() =>
            new CreateCustomerHttpRequest
            {
                MerchantId = Globals.MerchandId,
                GivenName = "Max",
                FamilyName = "Mustermann",
                AddressLine1 = "Musterstraße 1",
                CountryCode = "DE",
                LanguageCode = "DE",
                EmailAddress = "max@mustermann.de"
            };
    }
}