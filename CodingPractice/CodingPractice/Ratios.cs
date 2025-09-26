/*
Function Description

Complete the plusMinus function in the editor below.

plusMinus has the following parameter(s):

int arr[n]: an array of integers
Print
Print the ratios of positive, negative and zero values in the array. Each value should be printed on a separate line with  digits after the decimal. The function should not return a value.

Input Format

The first line contains an integer, , the size of the array.
The second line contains  space-separated integers that describe .

Constraints

Output Format

Print the following  lines, each to  decimals:

proportion of positive values
proportion of negative values
proportion of zeros
Sample Input

STDIN           Function
-----           --------
6               arr[] size n = 6
-4 3 -9 0 4 1   arr = [-4, 3, -9, 0, 4, 1]

Sample Output

0.500000
0.333333
0.166667
Explanation

There are 3 positive numbers, 2 negative numbers, and 1 zero in the array.
The proportions of occurrence are positive:0.500000 , negative:0.333333  and zeros:0.166667 .

 */

namespace CodingPractice
{
    public class Ratios
    {
        public void CalculateRatios()
        {
            List<int> arr = new List<int> { -4, 3, -9, 0, 4, 1 };

            int total = arr.Count;
            int positiveCount = 0, negativeCount = 0, zeroCount = 0;

            foreach (int num in arr)
            {
                if (num > 0)
                    positiveCount++;
                else if (num < 0)
                    negativeCount++;
                else
                    zeroCount++;
            }

            double positiveRatio = (double)positiveCount / total;
            double negativeRatio = (double)negativeCount / total;
            double zeroRatio = (double)zeroCount / total;

            Console.WriteLine(positiveRatio.ToString("F6"));
            Console.WriteLine(negativeRatio.ToString("F6"));
            Console.WriteLine(zeroRatio.ToString("F6"));
        }
    }
}
