using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deligates_And_Events
{
    public delegate void AddDeligate(int a1, int b1);
    public delegate string sayHello(string name);
    class MyDeligate
    {
        public void Add(string a, int b)
        {
            Console.WriteLine(a + b);
        }
        public void Add(int a, int b)
        {
            Console.WriteLine(a + b);
        }
        public static string sayHello(string name)
        {
            return "Hello" + name;
        }
    }
}
