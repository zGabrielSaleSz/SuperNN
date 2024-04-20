using SuperNN.Core.Domain;
using SuperNN.Core.Domain.ActivationFunctions;
using SuperNN.Core.Domain.ErrorFunctions;
using SuperNN.Core.Domain.InitializationFunction;
using SuperNN.Core.Domain.Layers;
using SuperNN.Core.Domain.Network.MLP;
using SuperNN.Core.Domain.Network.Neural;
using SuperNN.Core.Providers;

namespace TicTacToeNN
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
            0 - Empty
            1 = X
            2 = O
           
            Input Table
            [0] - 0 or 1 or 2 (empty or X or O)
            [1] - 0 or 1 or 2 (empty or X or O)
            [2] - 0 or 1 or 2 (empty or X or O)
            [3] - 0 or 1 or 2 (empty or X or O)
            [4] - 0 or 1 or 2 (empty or X or O)
            [5] - 0 or 1 or 2 (empty or X or O)
            [6] - 0 or 1 or 2 (empty or X or O)
            [7] - 0 or 1 or 2 (empty or X or O)
            [8] - 0 or 1 or 2 (empty or X or O)

            IA next move type
            [9] 1 ou 2 (X ou O)
            */

            FunctionProvider functionProvider = new FunctionProvider();

            IInitializationFunction he = functionProvider.GetInitializationFunction<He>();
            IInitializationFunction xavier = functionProvider.GetInitializationFunction<Xavier>();

            IActivationFunction relu = functionProvider.GetActivationFunction<ReLU>();
            IActivationFunction sigmoid = functionProvider.GetActivationFunction<Sigmoid>();

            IErrorFunction meanSquaredError = functionProvider.GetErrorFunction<MeanSquaredError>(); 

            Layer firstReluLayer = new Layer( relu, 10, 10);
            firstReluLayer.Initialize(he);

            Layer secondSigmoidLayer = new Layer(sigmoid, 10, 10);
            secondSigmoidLayer.Initialize(xavier);
            
            Layer thirdSigmoidLayer = new Layer(sigmoid, 9, 10);
            secondSigmoidLayer.Initialize(xavier);

            List<ILayer> layers = new List<ILayer>
            {
                firstReluLayer,
                secondSigmoidLayer,
                thirdSigmoidLayer
            };
            IMultiLayerPerceptron multiLayerPerceptron = new MultiLayerPerceptron();
            multiLayerPerceptron.Initialize(layers);

            /*
            (defense)
            0 1 2
            0 1 0
            0 0 0
            AI player as: 2
            expected [7] = 1 others 0
            */
            double[] firstInput = { 0, 1, 2, 0, 1, 0, 0, 0, 0, 2, };
            double[] expectedOutput = { 0, 0, 0, 0, 0, 0, 0, 1, 0 };
            multiLayerPerceptron.FeedForward(firstInput);
            multiLayerPerceptron.Backpropagation(expectedOutput, meanSquaredError);
        }
    }
}