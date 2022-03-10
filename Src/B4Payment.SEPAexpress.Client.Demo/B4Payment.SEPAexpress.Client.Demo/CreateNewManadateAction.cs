namespace B4Payment.SEPAexpress.Client.Demo
{
    internal class CreateNewManadateAction
    {
        public async Task<string> ExecuteAsync(string bankAccountId)
        {
            try
            {
                Globals.DisplayActionStart("Creating mandate");

                // create mandate
                var createMandateRequest = CreateMandateRequest(bankAccountId);
                var client = new Client(Globals.BaseUrl, Globals.HttpClient);
                var createMandateResponse = await client.MandatesPOSTAsync(createMandateRequest);

                // display result
                Globals.DisplayResponseObject("Mandate created", createMandateResponse);

                return createMandateResponse.Mandate.Id;
            }
            catch (ApiException apiex)
            {
                Globals.DisplayException(apiex);
                throw;
            }
        }

        private CreateMandateHttpRequest CreateMandateRequest(string bankAccountId) =>
            new CreateMandateHttpRequest
            {
                BankAccountId = bankAccountId,
                ConnectorId = Globals.ConnectorId,
                Memo = "test999 1",
                ApprovalBy = "click",
                Amount = 1900,
                CurrencyCode = "EUR",
                BankAccount = null,
            };
    }
}