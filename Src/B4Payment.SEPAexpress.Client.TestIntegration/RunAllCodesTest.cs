using B4Payment.SEPAexpress.Client.Demo;
using B4Payment.SEPAexpress.Client.Demo.Identity;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using System;
using System.Threading.Tasks;
using Xunit;

namespace B4Payment.SEPAexpress.Client.TestIntegration
{
    public class RunAllCodesTest
    {
        [Fact]
        public async Task RunTestAsync()
        {
            var authenticationAction = new SampleUserAuthentication();
            await authenticationAction.GetAccessTokenAsync();

            var keys = "123456789tmp";

            foreach (var selectedScenario in keys)
            {
                var scenario = SamplesFactory.CreateSample(selectedScenario);
                if (scenario != null)
                {
                    var executor = new SampleScenarioExecutor(scenario);
                    await executor.ExecuteAsync();
                }
            }
        }
    }
}
