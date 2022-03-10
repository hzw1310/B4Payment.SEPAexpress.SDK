namespace B4Payment.SEPAexpress.Client.Demo
{
    internal class CreateNewBankAccountAction
    {
        public async Task ExecuteAsync(string customerId)
        {
            try
            {
                Globals.DisplayActionStart("Creating bank account");

                // create customer
                var createNewBankAccountRequest = CreateBankAccountRequest(customerId);
                var client = new Client(Globals.BaseUrl, Globals.HttpClient);
                var createBankAccountResponse = await client.BankAccountsPOSTAsync(createNewBankAccountRequest);

                // display result
                Globals.DisplayResponseObject("Bank account created", createBankAccountResponse);
            }
            catch (ApiException apiex)
            {
                Globals.DisplayException(apiex);
            }
        }

        private CreateBankAccountHttpRequest CreateBankAccountRequest(string customerId) =>
            new CreateBankAccountHttpRequest
            {
               Memo = "test999",
               Iban = "DE86100000001234400013",
               CustomerId = customerId,
               Customer = null
            };
    }
}