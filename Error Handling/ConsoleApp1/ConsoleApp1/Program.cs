using ConsoleApp1;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter first number");
        int number1 = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter second number");
        int number2 = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter operation");
        string operation = Console.ReadLine()!.ToUpperInvariant();

        try
        {
            var calculator = new Calculator();
            int result = calculator.Calculate(number1, number2, null!);
            DisplayResult(result);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine($"Operation was not provided.{ex}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Sorry,something went wrong.{ex}");
        }

        Console.WriteLine("\nPress enter to exit.");
        Console.ReadLine();

        static void DisplayResult(int result) => Console.WriteLine($"Result is: {result}");


        //Test test = new Test();
        //test.Ques();
    }
}