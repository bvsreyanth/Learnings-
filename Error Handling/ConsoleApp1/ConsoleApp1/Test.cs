using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //logical question
    public class Test
    {
        public void Ques()
        {
            List<int> arr = new List<int> { 1, 2, 3, 4, 5, 6, 7 };

            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }

            foreach (var item in arr)
            {
                arr.Remove(item);
            }
              
        }
    }
}
