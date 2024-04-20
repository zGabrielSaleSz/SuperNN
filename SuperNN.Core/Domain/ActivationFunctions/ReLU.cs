namespace SuperNN.Core.Domain.ActivationFunctions
{
    public class ReLU : IActivationFunction
    {
        public double Execute(double input)
        {
            if (input < 0)
            {
                return 0;
            }
            return input;
        }
    }
}
