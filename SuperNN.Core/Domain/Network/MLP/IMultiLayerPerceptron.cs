using SuperNN.Core.Domain.Layers;
using SuperNN.Core.Persistence;

namespace SuperNN.Core.Domain.Network.MLP
{
    public interface IMultiLayerPerceptron
    {
        void Initialize(IEnumerable<ILayer> layers);
        void FeedForward(double[] inputs);
        void Backpropagation(double[] expectedOutputs, IErrorFunction errorFunction);
        INeuralNetworkState GetState();
    }
}
