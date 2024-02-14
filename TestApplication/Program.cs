using TestApplication;

Console.Clear();
MainOption();

void MainOption()
{
    Console.WriteLine("Choose an option then press Enter:");
    Console.WriteLine("[1] Scramble");
    Console.WriteLine("[2] Descramble");
    Console.WriteLine("[*] Any key exit");


    switch (Console.ReadLine())
    {
        case "1":
            SelectedScramble();
            break;
        case "2":
            SelectedDescramble();
            break;
    }
}

void SelectedScramble()
{
    try
    {        
        Console.WriteLine("Enter string then press Enter:");
        var input = Console.ReadLine();        
        var scrambler = new Scrambler(new KeyGenerator());
        var result = scrambler.Scramble(input);

        Console.WriteLine("Output:");
        Console.Write("Scrambled: ");
        Console.WriteLine(result.Scrambled);
        Console.Write("Key: ");
        Console.WriteLine(result.Key);


    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }

    MainOption();
}

void SelectedDescramble()
{
    try
    {
        Console.WriteLine("Enter scrambled string then press Enter:");
        var input = Console.ReadLine();
        Console.WriteLine("Enter key then press Enter:");
        var key = Console.ReadLine();
        
        var descrambler = new Descrambler();
        var result = descrambler.Descramble(input, key);

        Console.WriteLine("Output:");
        Console.Write("Original: ");
        Console.WriteLine(result);

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }

    MainOption();
}