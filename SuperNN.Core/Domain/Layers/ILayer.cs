namespace SuperNN.Core.Domain.Layers
{
    public interface ILayer
    {
        void Initialize(IInitializationFunction initializationFunction);
        double[] FeedForward(double[] inputs);
        void AssignBackpropagationReference(ILayer? previousLayer);
        bool IsFirstLayer();
        double[] GetLastResults();
    }
}
