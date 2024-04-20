namespace SuperNN.Core.Domain.ErrorFunctions
{
    public class MeanSquaredError : IErrorFunction
    {
        public double Execute(double expected, double actual)
        {
            double error = actual - expected;
            return error * error;
        }

        public decimal Execute(decimal expected, decimal actual)
        {
            decimal error = actual - expected;
            return error * error;
        }
    }
}
