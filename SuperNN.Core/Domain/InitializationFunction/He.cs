namespace SuperNN.Core.Domain.InitializationFunction
{
    // He's Initialization Function is good to work with ReLU
    public class He : IInitializationFunction
    {
        public double[] Execute(long nodesQuantity, long entriesQuantity)
        {
            long totalWeightsOrBiases = nodesQuantity * entriesQuantity;

            Random rand = new Random();
            double[] weightsOrBiases = new double[totalWeightsOrBiases];
            double heStandardDeviation = Math.Sqrt(2.0 / entriesQuantity);  // He's standard deviation

            for (int i = 0; i < totalWeightsOrBiases; i++)
            {
                // Random distribution 
                var negativeAdjustment = rand.Next() % 2 == 0 ? -1 : 1;
                weightsOrBiases[i] = rand.NextDouble() * heStandardDeviation * negativeAdjustment * rand.Next(100);
              
            }

            return weightsOrBiases;
        }
    }
}
