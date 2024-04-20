using SuperNN.Core.Domain.Layers;
using SuperNN.Core.Exceptions;
using SuperNN.Core.Persistence;

namespace SuperNN.Core.Domain.Network.MLP
{
    public class MultiLayerPerceptron : IMultiLayerPerceptron
    {
        private IEnumerable<ILayer> _layers;
        private ILayer _lastLayer;
        private bool _isInitialized = false;
        public void Initialize(IEnumerable<ILayer> layers)
        {
            if (_isInitialized == true)
            {
                throw new SuperNNException("Already initialized");
            }
            _layers = layers;
            _lastLayer = layers.Last();
            _isInitialized = true;
        }

        public void Backpropagation(double[] expectedOutputs, IErrorFunction errorFunction)
        {
            var lastResult = _lastLayer.GetLastResults();
            double errorSum = 0;
            for(int i = 0; i < lastResult.Length; i++)
            {
                errorSum += errorFunction.Execute(expectedOutputs[i], lastResult[i]);
            }

            // lastResult.Length means nodes quantity since there is only a single output for each node
            double errorMean = errorSum / lastResult.Length;
        }

        public void FeedForward(double[] inputs)
        {
            ILayer? previousLayer = null;
            double[] valuesToInputNextLayer = inputs;
            foreach (var layer in _layers)
            {
                layer.AssignBackpropagationReference(previousLayer);

                // reference to next iteration
                previousLayer = layer;
                valuesToInputNextLayer = layer.FeedForward(valuesToInputNextLayer);
            }
        }

        public INeuralNetworkState GetState()
        {
            throw new SuperNNException("Not implemented");
        }
    }
}
