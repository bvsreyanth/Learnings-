using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingPractice
{
    public class CharacterOccurance
    {
        public void charoccuranceofstring()
        {
            string text = "Hello Greate to see you ";
            Dictionary<char,int> map = new Dictionary<char,int>();
            foreach(char c in text)
            {
                if (map.ContainsKey(c))
                {
                    map[c]++;
                }
                else
                {
                    map[c] = 1;
                }
                Console.WriteLine("Character count");
                foreach (var pair in map)
                {
                    Console.WriteLine($"'{pair.Key}' : {pair.Value}");
                }
            }
        }
    }
}
