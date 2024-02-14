using TestApplication.Contracts;
using TestApplication.Models;

namespace TestApplication;
public class Scrambler(IGenerate generator)
{
    public ScrambleResult Scramble(string input)
    {
        ValidateInputLength(input);
        ValidateInputCharacters(input);

        var key = generator.GenerateKey(input);
        var swappedCharacters = SwapCharacters(input, key);

        var scrambledInput = ConvertCharArrayToString(swappedCharacters);
        var result = GenerateResult(scrambledInput, key);

        result = MakeSureInputIsNotEqualToOutput(result, input);

        return result;
    }

    private ScrambleResult MakeSureInputIsNotEqualToOutput(ScrambleResult result, string input)
    {
        var newResult = new ScrambleResult
        {
            Key = result.Key,
            Scrambled = result.Scrambled
        };

        while (newResult.Scrambled == input)
        {
            newResult = Scramble(input);
        }

        return newResult;
    }

    private void ValidateInputLength(string input)
    {
        if (input.Length <= 1)
        {
            throw new Exception("must be at least 2 characters");
        }
    }

    private void ValidateInputCharacters(string input)
    {
        if (input.Distinct().Count() == 1)
        {
            throw new Exception("all characters must not be the same");
        }
    }

    private string ConvertCharArrayToString(char[] inputCharacters)
    {
        return new string(inputCharacters);
    }

    private char[] SwapCharacters(string input, string key)
    {       
        var random = new Random(Convert.ToInt32(key));
        var inputCharacters = input.ToCharArray();
        var inputLength = input.Length;
        var index = 0;
        foreach (var character in inputCharacters)
        {
            var randomIndex = random.Next(0, inputLength);

            var tempCharacter = inputCharacters[randomIndex];
            inputCharacters[randomIndex] = inputCharacters[index];
            inputCharacters[index] = tempCharacter;
            index++;
        }

        return inputCharacters;
    }

    private ScrambleResult GenerateResult(string scrambledInput, string key)
    {
        return new ScrambleResult
        {
            Scrambled = scrambledInput,
            Key = key
        };
    }
}
