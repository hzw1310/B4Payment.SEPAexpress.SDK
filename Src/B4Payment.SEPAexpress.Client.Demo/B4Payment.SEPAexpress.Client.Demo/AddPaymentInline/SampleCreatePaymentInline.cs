namespace B4Payment.SEPAexpress.Client.Demo.AddPaymentInline
{
    internal class SampleCreatePaymentInline
    {
        internal async Task CreatePaymentInlineAsync()
        {
            /// 2.1 create a new payment referencing on this mandate
            var createNewPayment = new CreateNewPaymentActionInlineAction();
            await createNewPayment.ExecuteAsync();

            Console.WriteLine("== Scenario is done - payment is created ==");
        }
    }
}