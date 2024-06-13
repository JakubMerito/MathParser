using MathParser;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Wpisz działanie matematyczne: ");
        string? input = Console.ReadLine();

        Parser parser = new Parser(input);

    }
}