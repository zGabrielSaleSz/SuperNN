using SuperNN.Core.Domain.ActivationFunctions;

namespace SuperNN.Tests.ActivationFunctions
{
    public class ActivationFunctionsTest
    {
        [Fact]
        public void ReLUTest()
        {
            ReLU relu = new ReLU();
            Assert.Equal(0, relu.Execute(-3));
            Assert.Equal(0, 0);
            Assert.Equal(6, relu.Execute(6));
        }
    }
}