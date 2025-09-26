using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deligates_And_Events
{
    public delegate void Transform(int x);

    internal class MyEvents
    {
        static void Square(int x)
        {
            Console.WriteLine($"Square: {x * x}");
        }

        static void Cube(int x)
        {
            Console.WriteLine($"Cube: {x * x * x}");
        }
    }
}
