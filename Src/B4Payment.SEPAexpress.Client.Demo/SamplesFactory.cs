using B4Payment.SEPAexpress.Client.Demo.SampleBase;

namespace B4Payment.SEPAexpress.Client.Demo
{
    internal static class SamplesFactory
    {
        public static IScenario? CreateSample(char selectedScenario) =>
            selectedScenario switch
            {
                '1' => new SampleCreatePaymentInSteps(),
                '2' => new SampleCreatePaymentInline(),
                '3' => new SampleGetPaymentData(),
                '4' => new SampleCreateRecurringPayment(),
                '5' => new SampleGetReconciliations(),
                '6' => new SampleCreateRefund(),
                '7' => new SampleUseIdempotentKeys(),
                '8' => new SampleGetData(),
                '9' => new SampleHostedPages(),
                't' => new SampleGetLocalizationText(),
                'm' => new SampleMandates(),
                'p' => new SamplePayout(),
                _ => null
            };
    }
}
