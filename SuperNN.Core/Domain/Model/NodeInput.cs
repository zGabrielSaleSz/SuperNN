namespace SuperNN.Core.Domain.Model
{
    public class NodeInput
    {
        public NodeInput()
        {

        }

        public NodeInput(double input, double weight)
        {
            Input = input;
            Weight = weight;
        }

        public double Input { get; set; }
        public double Weight { get; set; }
    }
}
