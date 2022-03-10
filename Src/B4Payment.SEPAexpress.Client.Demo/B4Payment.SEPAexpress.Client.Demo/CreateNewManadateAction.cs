namespace B4Payment.SEPAexpress.Client.Demo
{
    internal class CreateNewManadateAction
    {
        public async Task ExecuteAsync(string bankAccountId)
        {
            try
            {
                Globals.DisplayActionStart("Creating mandate");

                // create mandate
                var createMandateRequest = CreateMandateRequest(bankAccountId);
                var client = new Client(Globals.BaseUrl, Globals.HttpClient);
                var createMandateRespons = await client.MandatesPOSTAsync(createMandateRequest);

                // display result
                Globals.DisplayResponseObject("Mandate created", createMandateRespons);
            }
            catch (ApiException apiex)
            {
                Globals.DisplayException(apiex);
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
                CurrencyCode = "EUR"
            };
    }
}