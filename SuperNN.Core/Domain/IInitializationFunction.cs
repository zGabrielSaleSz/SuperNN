namespace SuperNN.Core.Domain
{
    public interface IInitializationFunction
    {
        double[] Execute(long nodesQuantity, long entriesQuantity);
    }
}
