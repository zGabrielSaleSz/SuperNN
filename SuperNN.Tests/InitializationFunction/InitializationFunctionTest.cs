using SuperNN.Core.Domain;
using SuperNN.Core.Domain.InitializationFunction;

namespace SuperNN.Tests.InitializationFunction
{
    public class InitializationFunctionTest
    {
        [Fact]
        public void HeTest()
        {
            IInitializationFunction initializationFunction = new He();
            int nodes = 10;
            int entries = 10;
            int ocurrencies = nodes * entries;

            double[] weights = initializationFunction.Execute(nodes, entries);

            double mean = weights.Average();
            double standardDeviation = StandardDeviationOf(weights);

            // todo: assert something here
            Assert.True(false);
        }

        [Fact]
        public void XavierTest()
        {
            IInitializationFunction initializationFunction = new Xavier();
            int nodes = 100;
            int entries = 10000;
            int ocurrencies = nodes * entries;

            double[] weights = initializationFunction.Execute(nodes, entries);

            double mean = weights.Average();
            double standardDeviation = StandardDeviationOf(weights);

            // todo: assert something here
            Assert.True(false);
        }

        private double StandardDeviationOf(double[] valores)
        {
            double average = valores.Average();
            double sumOfEachValueMinusAveragePow2 = valores.Sum(x => Math.Pow(x - average, 2));
            return Math.Sqrt(sumOfEachValueMinusAveragePow2 / valores.Length);
        }
    }
}
