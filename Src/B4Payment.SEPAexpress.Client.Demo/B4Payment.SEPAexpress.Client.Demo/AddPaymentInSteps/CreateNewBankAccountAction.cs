namespace B4Payment.SEPAexpress.Client.Demo.AddPaymentInSteps
{
    internal class CreateNewBankAccountAction
    {
        /// <summary>
        /// Creates new bank account
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>New created bank ID</returns>
        public async Task<string> ExecuteAsync(string customerId)
        {
            try
            {
                Globals.DisplayActionStart("Creating bank account");

                // create bank account
                var createNewBankAccountRequest = CreateBankAccountRequest(customerId);
                var client = new Client(Globals.BaseUrl, Globals.HttpClient);
                var createBankAccountResponse = await client.BankAccountsPOSTAsync(createNewBankAccountRequest);

                // display result
                Globals.DisplayResponseObject("Bank account created", createBankAccountResponse);

                return createBankAccountResponse.BankAccount.Id;
            }
            catch (ApiException apiex)
            {
                Globals.DisplayException(apiex);
                throw;
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