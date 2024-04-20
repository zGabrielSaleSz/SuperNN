namespace SuperNN.Core.Domain.Nodes
{
    public interface INode
    {
        void AssignWeights(long index, double weight);
        void AssignBias(double bias);

        double ExecuteActivationFunction(double[] inputs);

        double GetLastOutput();
    }
}
