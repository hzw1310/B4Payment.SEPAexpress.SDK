namespace B4Payment.SEPAexpress.Client.Demo.AddPaymentInSteps
{
    internal class SampleCreatePaymentInSteps
    {
        /// <summary>
        /// Scenarios:
        /// 1. Create a payment. <see href="https://sepaexpress-prod-fx.azurewebsites.net/redoc#tag/Quick-Start"/>
        /// </summary>
        public async Task CreatePaymentInStepsAsync()
        {
            /// 1.1 create a new customer
            var createNewCustomerAction = new CreateNewCustomerAction();
            var customerId = await createNewCustomerAction.ExecuteAsync();

            /// 1.2 create a new bank account for this customer
            var createNewBankAccount = new CreateNewBankAccountAction();
            var bankAccountId = await createNewBankAccount.ExecuteAsync(customerId);

            /// 1.3 create a new mandate for this bank account
            var createMandate = new CreateNewManadateAction();
            var mandateId = await createMandate.ExecuteAsync(bankAccountId);

            /// 1.4 create a new payment referencing on this mandate
            var createNewPayment = new CreateNewPaymentAction();
            await createNewPayment.ExecuteAsync(mandateId);

            Console.WriteLine("== Scenario is done - payment is created ==");
        }
    }
}