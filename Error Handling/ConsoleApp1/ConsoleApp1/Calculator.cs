using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp1
{
    public class Calculator
    {
        public int Calculate(int number1, int number2, string operation)
        {
            string nonnull = operation ?? throw new ArgumentNullException(nameof(operation));
            if (nonnull == "/")
            {
                try
                {
                    return Divide(number1, number2);
                }
                catch (DivideByZeroException ex)
                {                  
                    Console.WriteLine("Exception occued by dividing by 0");
                    throw new ArithmeticException("It is an Arithmatic exception",ex);
                }
            }
            else
            {
                Console.WriteLine("Unknown operation.");
                return 0;
                
            }
        }

        private int Divide(int number, int divisor) => number / divisor;
    }
}

