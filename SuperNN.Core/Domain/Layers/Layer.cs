using SuperNN.Core.Domain.Model;
using SuperNN.Core.Domain.Nodes;
using SuperNN.Core.Exceptions;

namespace SuperNN.Core.Domain.Layers
{
    public class Layer : ILayer
    {
        private readonly IActivationFunction _activationFunction;
        private readonly long _nodesQuantity;
        private readonly long _entriesQuantity;

        private ILayer? _feededByLayer;
        private INode[] _nodes;
        private double[] _lastResult;

        public Layer(IActivationFunction activationFunction, long nodesQuantity, long entriesQuantity) {
            _activationFunction = activationFunction;
            _nodesQuantity = nodesQuantity;
            _entriesQuantity = entriesQuantity;
            _lastResult = new double[nodesQuantity];
            _nodes = new INode[_nodesQuantity];
            BuildNodes();
        }

        private void BuildNodes()
        {
            for (long i = 0; i < _nodesQuantity; i++)
            {
                INode node = new Node(_activationFunction, _entriesQuantity);
                _nodes[i] = node;
            }
        }

        public void Initialize(IInitializationFunction initializationFunction)
        {
            double[] weights = initializationFunction.Execute(_nodesQuantity, _entriesQuantity);
            long weightsUsed = 0;
            for (long i = 0; i < _nodesQuantity; i++)
            {
                INode node = _nodes[i];
                for (long j = 0; j < _entriesQuantity; j++)
                {
                    node.AssignWeights(j, weights[weightsUsed]);
                    weightsUsed++;
                }
            }
        }

        public double[] FeedForward(double[] inputs)
        {
            if (inputs.Length != _entriesQuantity)
            {
                throw new InvalidLayerInputException($"Layer is expecting receive {inputs.Length}, but received {_entriesQuantity}");
            }
           
            for (long i = 0; i < _nodesQuantity; i++)
            {
                _lastResult[i] = _nodes[i].ExecuteActivationFunction(inputs);
            }
            return _lastResult;
        }

        public void AssignBackpropagationReference(ILayer? previousLayer)
        {
            _feededByLayer = previousLayer;
        }

        public bool IsFirstLayer()
        {
            return _feededByLayer == null;
        }

        public double[] GetLastResults()
        {
            return _lastResult;
        }
    }
}
