namespace TestApplication;

public class KeyGeneratorTests
{
    private KeyGenerator CreateDefaultKeyGenerator()
    {
        return new KeyGenerator();
    }

    [Theory]
    [InlineData("abcde")]
    [InlineData("abcd")]
    [InlineData("abc")]
    public void Generate_MultipleInputLength_ShouldReturnKeyLengthLessThanInputLength(string input)
    {
        var keyGenerator = CreateDefaultKeyGenerator();
        var key = keyGenerator.GenerateKey(input);

        Assert.Equal(key.Length, input.Length - 1);
    }

    [Theory]
    [InlineData("abcde")]
    [InlineData("abcd")]
    [InlineData("abc")]
    public void Generate_AnyInput_ShouldReturnInteger(string input)
    {
        var keyGenerator = CreateDefaultKeyGenerator();
        var key = keyGenerator.GenerateKey(input);

        var result = 0;
        Int32.TryParse(key, out result);

        Assert.True(result > 0);
    }

    [Theory]
    [InlineData("abcdefghijklmnopqrstuv")]
    [InlineData("abcdefghijklmnopqrstuvxy")]
    [InlineData("abcdefghijklmnopqrstuvxyz")]
    public void Generate_LongInput_ShouldReturnValidInteger(string input)
    {
        var keyGenerator = CreateDefaultKeyGenerator();
        var key = keyGenerator.GenerateKey(input);

        var result = 0;
        Int32.TryParse(key, out result);

        Assert.True(result > 0 && result < Int32.MaxValue);
    }

    [Fact]
    public void Generate_OneCharacterInput_ShouldReturnBlank()
    {
        var keyGenerator = CreateDefaultKeyGenerator();
        var key = keyGenerator.GenerateKey("a");

        Assert.Equal("", key);
    }

    [Fact]
    public void Generate_BlankInput_ShouldThrowError()
    {
        var keyGenerator = CreateDefaultKeyGenerator();
        Action actual = () => keyGenerator.GenerateKey("");

        Assert.Throws<ArgumentOutOfRangeException>(actual);
    }


}

