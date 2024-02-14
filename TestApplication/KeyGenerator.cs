using TestApplication.Contracts;

namespace TestApplication;
public  class KeyGenerator : IGenerate
{
    public string GenerateKey(string input)
    {
        var key = GenerateRandomNumber();
        return ReturnLessThanOneLengthFromInput(key, input.Length);
    }

    private int GenerateRandomNumber()
    {
        var random = new Random();
        return random.Next(1000000000, Int32.MaxValue);
    }

    private string ReturnLessThanOneLengthFromInput(int key, int inputLength) 
    {
        if(key.ToString().Length < inputLength)
        {
            return key.ToString().Substring(0, key.ToString().Length - 1);
        }

        return key.ToString().Substring(0, inputLength - 1);
    }
}
