﻿namespace B4Payment.SEPAexpress.Client.Demo.AddPaymentInSteps
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
                ConsoleUtils.DisplayActionStart("Creating bank account");

                // create bank account
                var createNewBankAccountRequest = CreateBankAccountRequest(customerId);
                var client = new Client(Globals.BaseUrl, Globals.HttpClient);
                var createBankAccountResponse = await client.BankAccountsPOSTAsync(createNewBankAccountRequest);

                return createBankAccountResponse.BankAccount.Id;
            }
            catch (ApiException apiex)
            {
                ConsoleUtils.DisplayException(apiex);
                throw;
            }
        }

        private CreateBankAccountHttpRequest CreateBankAccountRequest(string customerId) =>
            new CreateBankAccountHttpRequest
            {
                Memo = "test999",
                Iban = Globals.Iban,
                CustomerId = customerId,
                Customer = null
            };
    }
}