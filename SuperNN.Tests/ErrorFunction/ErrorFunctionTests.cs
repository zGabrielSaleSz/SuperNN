using SuperNN.Core.Domain.ErrorFunctions;

namespace SuperNN.Tests.ErrorFunction
{
    public class ErrorFunctionTests
    {
        [Fact]
        public void MeanSquareErrorTest()
        {
            double expected = 0.5;
            double actual = 0.61744;
            MeanSquaredError meanSquareError = new MeanSquaredError();
            var result = meanSquareError.Execute(expected, actual);
            Assert.Equal(0.01379, result, 5);
        }
    }
}
