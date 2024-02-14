namespace TestApplication.Test;
public class DescramblerTests
{
    private Scrambler CreateDefaultScrambler()
    {
        return new Scrambler(new KeyGenerator());
    }

    private Descrambler CreateDefaultDescrambler()
    {
        return new Descrambler();
    }

    [Theory]
    [InlineData("acdb", "196", "abcd")]
    [InlineData("bca", "18", "abc")]
    public void Descramble_MultipleInput_ShouldReturnExpectedResult(string input, string key, string expectedResult)
    {
        var descrambler = CreateDefaultDescrambler();
        var result = descrambler.Descramble(input, key);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("acdb", "196", "abcde")]
    [InlineData("bca", "18", "abcd")]
    public void Descramble_MultipleInput_ShouldNotReturnExpectedResult(string input, string key, string expectedResult)
    {
        var descrambler = CreateDefaultDescrambler();
        var result = descrambler.Descramble(input, key);

        Assert.NotEqual(expectedResult, result);
    }

    [Theory]
    [InlineData("abcdefghijklmnopqrstuvxyz")]
    [InlineData("abcd")]
    [InlineData("abc")]
    public void Descramble_Input_ShouldReturnEqualToOuput(string input)
    {
        var scrambler = CreateDefaultScrambler();
        var result = scrambler.Scramble(input);

        var descrambler = CreateDefaultDescrambler();
        var output = descrambler.Descramble(result.Scrambled, result.Key);

        Assert.Equal(input, output);
    }

    [Fact]
    public void Descramble_NonNumericKey_ShouldThrowError()
    {
        var descrambler = CreateDefaultDescrambler();
        Action actual = () => descrambler.Descramble("abc","abc");

        Assert.Throws<Exception>(actual);
    }

    [Fact]
    public void Descramble_GreaterThanInt32Key_ShouldThrowError()
    {
        var descrambler = CreateDefaultDescrambler();
        var key = $"9{Int32.MaxValue.ToString()}";
        Action actual = () => descrambler.Descramble("abc", key);

        Assert.Throws<Exception>(actual);
    }
}
