using Xunit;
using Exercise4Library;

namespace Ex4Test
{
    public class Exercise4Tests
    {
        [Theory]
        [InlineData(4, "2 x 2")]
        [InlineData(6, "2 x 3")]
        [InlineData(10, "2 x 5")]
        [InlineData(20, "2 x 2 x 5")]
        [InlineData(30, "2 x 3 x 5")]
        [InlineData(1, "No prime factors available for this number.")]
        public void TestExercise4(int input, string expected)
        {
            string result = PrimeFactorization.PrimeFactors(input);
            Assert.Equal(expected, result);
        }
    }
}
