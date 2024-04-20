namespace SuperNN.Core.Domain.ActivationFunctions
{
    public class Sigmoid : IActivationFunction
    {
        public double Execute(double input)
        {
            return 1.0 / (1.0 + Math.Exp(input * -1));
        }
    }
}
