using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using B4Payment.SEPAexpress.Client.Demo;
using B4Payment.SEPAexpress.Client.Demo.Identity;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using B4Payment.SEPAexpress.Client.Demo.Utils;

namespace B4Payment.SEPAexpress.Client.Demo.NETFramework
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ConsoleUtils.ShowTitle();

            while (true)
            {
                ConsoleUtils.ShowScenarios();
                var selectedScenario = ConsoleUtils.ReadCharFromUser();
                Console.WriteLine();

                if (selectedScenario == 'X' || selectedScenario == 'x')
                {
                    return;
                }

                /// <summary>
                /// authenticate user first
                /// </summary>
                var authenticationAction = new SampleUserAuthentication();
                await authenticationAction.GetAccessTokenAsync();

                IScenario scenario = null;

                switch (selectedScenario)
                { 
                    case '1' : scenario = new SampleCreatePaymentInSteps(); break;
                    case '2' : scenario = new SampleCreatePaymentInline(); break;
                    case '3' : scenario = new SampleGetPaymentData(); break;
                    case '4' : scenario = new SampleCreateRecurringPayment(); break;
                    case '5' : scenario = new SampleGetReconciliations(); break;
                    case '6' : scenario = new SampleCreateRefund(); break;
                    case '7' : scenario = new SampleUseIdempotentKeys(); break;
                    case '8' : scenario = new SampleGetData(); break;
                }

                if (scenario != null)
                {
                    var executor = new SampleScenarioExecutor(scenario);
                    await executor.ExecuteAsync();
                }
            }

        }
    }
}
