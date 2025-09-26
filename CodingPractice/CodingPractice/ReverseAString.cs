using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice
{
    public class ReverseAString
    {
        public void Reverse()
        {
            Console.Write("Enter a String : ");
            string originalString = Console.ReadLine();
            string orstr = originalString.ToLower();
            string reverseString = string.Empty;
            for (int i = orstr.Length - 1; i >= 0; i--)
            {
                reverseString += orstr[i];
            }
            Console.Write($"Reverse String is : {reverseString} ");
            Console.ReadLine();
        }

    }
}
