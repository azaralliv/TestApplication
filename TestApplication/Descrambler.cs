
namespace TestApplication;
public class Descrambler
{
    public string Descramble(string input, string key)
    {
        var keyInt = ConvertKeyToInteger(key);
        var swappedCharacters = SwapCharacters(input, keyInt);
        return new string(swappedCharacters);
    }

    private int ConvertKeyToInteger(string key)
    {
        var keyInt = 0;
        Int32.TryParse(key, out keyInt);
        if (keyInt == 0)
        {
            throw new Exception("invalid key");
        }

        return keyInt;
    }

    private char[] SwapCharacters(string input, int keyInt)
    {
        var random = new Random(keyInt);
        var inputLength = input.Length;
        var inputCharacters = input.ToCharArray();
        var randomIndexes = inputCharacters.Select((character => random.Next(0, inputLength))).ToArray();
        for (int i = inputLength - 1; i >= 0; i--)
        {
            char temp = inputCharacters[randomIndexes[i]];
            inputCharacters[randomIndexes[i]] = inputCharacters[i];
            inputCharacters[i] = temp;
        }

        return inputCharacters;
    }
}
