using B4Payment.SEPAexpress.Client.Demo;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using System.Threading.Tasks;
using Xunit;

namespace B4Payment.SEPAexpress.Client.TestIntegration
{
    public class RunAllCodesTest : IClassFixture<LoginContext>
    {
        [Theory]
        [InlineData('1')]
        [InlineData('2')]
        [InlineData('3')]
        [InlineData('4')]
        [InlineData('5')]
        [InlineData('6')]
        [InlineData('7')]
        [InlineData('8')]
        [InlineData('9')]
        [InlineData('t')]
        [InlineData('m')]
        [InlineData('p')]
        public async Task RunTestAsync(char selectedScenario)
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