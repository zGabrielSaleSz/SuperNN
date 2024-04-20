namespace SuperNN.Core.Domain
{
    public interface IErrorFunction
    {
        double Execute(double expected, double actual);
    }
}
