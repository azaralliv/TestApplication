namespace TestApplication.Test;
public class ScramblerTests
{
    private Scrambler CreateDefaultScrambler()
    {
        return new Scrambler(new KeyGenerator());
    }

    [Theory]
    [InlineData("abcdefghijklmnopqrstuvxyz")]
    [InlineData("abcd")]
    [InlineData("abc")]
    public void Scramble_MultipleInput_ShouldReturnNotEqualToInput(string input)
    {
        var scrambler = CreateDefaultScrambler();
        var result = scrambler.Scramble(input);

        Assert.NotEqual(input, result.Scrambled);
    }

    [Theory]
    [InlineData("abcdefghijklmnopqrstuvxyz")]
    [InlineData("abcd")]
    [InlineData("abc")]
    public void Scramble_MultipleInput_ShouldReturnKey(string input)
    {
        var scrambler = CreateDefaultScrambler();
        var result = scrambler.Scramble(input);

        var numericKey = 0;
        Int32.TryParse(result.Key, out numericKey);

        Assert.True(numericKey > 0);
    }

    [Theory]
    [InlineData("abcdefghijklmnopqrstuvxyz")]
    [InlineData("abcd")]
    [InlineData("abc")]
    public void Scramble_MultipleInput_ShouldNotBeBlank(string input)
    {
        var scrambler = CreateDefaultScrambler();
        var result = scrambler.Scramble(input);

        Assert.NotEqual("", result.Scrambled);
    }

    [Theory]
    [InlineData("a")]
    [InlineData("")]
    public void Scramble_LessThanTwoCharactersInput_ShouldThrowError(string input)
    {
        var scrambler = CreateDefaultScrambler();
        Action actual = () => scrambler.Scramble(input);

        Assert.Throws<Exception>(actual);
    }

    [Fact]
    public void Scramble_TwoSameCharactersInput_ShouldThrowError()
    {
        var scrambler = CreateDefaultScrambler();
        Action actual = () => scrambler.Scramble("aa");

        Assert.Throws<Exception>(actual);
    }
}
