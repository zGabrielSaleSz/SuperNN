namespace SuperNN.Core.Domain.InitializationFunction
{
    // He's Initialization Function is good to work with Sigmoid
    public class Xavier : IInitializationFunction
    {
        public double[] Execute(long nodesQuantity, long entriesQuantity)
        {
            long ocurrencies = nodesQuantity * entriesQuantity;

            Random rand = new Random();
            double[] weightsOrBiases = new double[ocurrencies];
            double xavierStandardDeviation = Math.Sqrt(1.0 / ocurrencies); // xavier 's standard deviation

            for (int i = 0; i < ocurrencies; i++)
            {
                weightsOrBiases[i] = rand.NextDouble() * xavierStandardDeviation;
            }

            return weightsOrBiases;
        }
    }
}
