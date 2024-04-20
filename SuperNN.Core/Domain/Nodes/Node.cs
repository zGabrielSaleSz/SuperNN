using SuperNN.Core.Exceptions;

namespace SuperNN.Core.Domain.Nodes
{
    public class Node : INode
    {
        private readonly IActivationFunction _activationFunction;
        private readonly long _entriesQuantity;
        private double _bias;
        private double _lastOutput;
        private double[] _entries;
        private double[] _weights;

        public Node(IActivationFunction activationFunction, long entriesQuantity)
        {
            _activationFunction = activationFunction;
            _entriesQuantity = entriesQuantity;
            _entries = new double[entriesQuantity];
            _weights = new double[entriesQuantity];
        }

        public void AssignBias(double bias)
        {
            _bias = bias;
        }

        public void AssignWeights(long index, double weight)
        {
            _weights[index] = weight;
        }

        public double ExecuteActivationFunction(double[] inputs)
        {
            if (inputs.Length != _entries.Length)
            {
                throw new SuperNNException("Input lenght does not match the weights quantity");
            }

            double sum = 0;
            for (long i = 0; i < _entriesQuantity; i++)
            {
                sum += (inputs[i] * _weights[i]);
            }
            
            sum += _bias;
            _lastOutput = _activationFunction.Execute(sum);
            return _lastOutput;
        }

        public double GetLastOutput()
        {
            return _lastOutput;
        }
    }
}
