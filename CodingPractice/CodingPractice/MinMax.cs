using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice
{
    internal class MinMax
    {
        #region Params
        /// <summary>
        /// The params keyword in C# allows you to specify a method parameter that takes a variable number of arguments. 
        /// </summary>
        #endregion
        public void MinMaxSum(params int[] arr)

        {
            Array.Sort(arr);
            long minsum = arr.Take(4).Select(x=>(long)x).Sum();
            long maxsum = arr.Skip(1).Select(x=>(long)x).Sum();
            Console.WriteLine($"{minsum} {maxsum}");
            
        }
    }
}
