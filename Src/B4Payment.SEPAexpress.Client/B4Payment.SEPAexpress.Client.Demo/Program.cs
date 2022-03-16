﻿using B4Payment.SEPAexpress.Client.Demo;
using B4Payment.SEPAexpress.Client.Demo.Identity;
using B4Payment.SEPAexpress.Client.Demo.Utils;

ConsoleUtils.ShowTitle();

while (true)
{
    ConsoleUtils.ShowScenarios();
    var selectedScenario = ConsoleUtils.ReadCharFromUser();
    Console.WriteLine();

    /// <summary>
    /// authenticate user first
    /// </summary>
    var authenticationAction = new SampleUserAuthentication();
    await authenticationAction.GetAccessTokenAsync();

    switch (selectedScenario)
    {
        case '1':
            /// <summary>
            /// create payment in steps one-by-one
            /// </summary>
            var sampleCreatePaymentInSteps = new SampleCreatePaymentInSteps();
            await sampleCreatePaymentInSteps.CreatePaymentInStepsAsync();
            break;

        case '2':
            /// <summary>
            /// create payment in steps in-line
            /// </summary>
            var sampleCreatePaymentInline = new SampleCreatePaymentInline();
            await sampleCreatePaymentInline.CreatePaymentInlineAsync();
            break;

        case '3':
            /// <summary>
            /// get payment data
            /// </summary>
            var sampleGetPaymentData = new SampleGetPaymentData();
            await sampleGetPaymentData.GetPaymentDataAsync();
            break;

        case '4':
            /// <summary>
            /// create recurring payment
            /// </summary>
            var sampleRecurringPayment = new SampleCreateRecurringPayment();
            await sampleRecurringPayment.ExecuteAsync();
            break;

        case '5':
            /// <summary>
            /// get reconciliations
            /// </summary>
            var sampleGetReconciliations = new SampleGetReconciliations();
            await sampleGetReconciliations.ExecuteAsync();
            break;

        case '6':
            /// <summary>
            /// create refund
            /// </summary>
            var sampleCreateRefund = new SampleCreateRefund();
            await sampleCreateRefund.ExecuteAsync();
            break;

        case 'X' or 'x':
            return;
    }
}