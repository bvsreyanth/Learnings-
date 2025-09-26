namespace CodingPractice
{
    #region Question
    /*Given two strings s and t, return true if t is an anagram of s, and false otherwise.

    An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase,
    typically using all the original letters exactly once.

 

    Example 1:

    Input: s = "anagram", t = "nagaram"
    Output: true
    Example 2:

    Input: s = "rat", t = "car"
    Output: false
 

    Constraints:

    1 <= s.length, t.length <= 5 * 104
    s and t consist of lowercase English letters.*/
    #endregion
    public class Anagrams
    {
        public void isAnagram()
        {
            string str1 = "Anagram";
            string str2 = "Nagaram";

            string string1 = str1.ToLower();
            string string2 = str2.ToLower();

            if (string1.Length != string2.Length)
            {
                Console.WriteLine("Both the strings are not anagram");
                return;
            }

            char[] char1 = string1.ToCharArray();
            char[] char2 = string2.ToCharArray();

            Array.Sort(char1);
            Array.Sort(char2);

            bool result = true;
            for (int i = 0; i < string1.Length; i++)
            {
                if (char1[i] != char2[i])
                {
                    result = false;
                    break;
                }
            }

            if (result)
            {
                Console.WriteLine($"\"{str1}\" and \"{str2}\" are anagrams");
            }
            else
            {
                Console.WriteLine($"\"{str1}\" and \"{str2}\" are not anagrams");
            }
        }
    }
}

