using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deligates_And_Events
{
    public delegate void Multicasting(int x, int y);
    internal class MultiCastDeligate
    {
        public void Addmet(int x, int y)
        {
            int z = x + y;
            Console.WriteLine(z);
        }
        public void Mult(int x, int y)
        {
            int z = x * y;
            Console.WriteLine(z);
        }
    }
}
