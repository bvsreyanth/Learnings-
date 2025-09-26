namespace CodingPractice
{
    /*Given an array of integers, identify and count the occurrences of duplicate elements within the array.
     * Utilize a C# program that employs a Dictionary<int, int> to store the counts of each integer occurrence
     * and then display the duplicate numbers along with their counts.

   Sample Input:

   csharp

   int[] numbers = { 1, 2, 3, 2, 4, 3, 5, 6, 5, 5 };
   Expected Output:

   bash

   Duplicates using Dictionary:
   2 (2 times)
   3 (2 times)
   5 (3 times)
   Write a C# program that takes an array of integers as input and implements a method
    to find duplicate integers within the array.
    Display the duplicates along with their occurrence count using a Dictionary<int, int> approach.*/
    public class ToFindDuplicates
    {
        public void FindDuplicateUsingDict()
        {
            int[] numbers = { 1, 2, 3, 2, 4, 3, 5, 6, 5, 5 };
            Dictionary<int, int> numberCounts = new Dictionary<int, int>();
            foreach (int num in numbers)
            {
                if (numberCounts.ContainsKey(num))
                {
                    numberCounts[num]++;
                }
                else
                {
                    numberCounts[num] = 1;
                }
                Console.WriteLine("Duplicates using Dictionary:");
                foreach (var pair in numberCounts)
                {
                    if (pair.Value > 1)
                    {
                        Console.WriteLine($"{pair.Key} ({pair.Value} times)");
                    }
                }
            }

        }
        public void UsingHashSet()
        {
            var numbers = new List<object> { 1, 2, 3.5, 2, 4.2, 3.5, 5, 6, "2", "test", "test" };
            HashSet<string> uniqueNumbers = new HashSet<string>();
            HashSet<string> duplicates = new HashSet<string>();
            Dictionary<object, int> countMap = new Dictionary<object, int>();

            foreach (var number in numbers)
            {
                var strNumber = number.ToString();

                #region WITHOUT USING TOSTRING

                if (!uniqueNumbers.Contains(number))
                {
                    uniqueNumbers.Add(strNumber);
                }
                else
                {
                    duplicates.Add(strNumber);
                }


                #endregion

                if (!uniqueNumbers.Contains(strNumber))
                {
                    duplicates.Add(strNumber);
                }

                if (countMap.ContainsKey(number))
                {
                    countMap[number]++;
                }
                else
                {
                    countMap[number] = 1;
                }
                foreach (var duplicate in duplicates)
                {
                    Console.WriteLine($"{duplicate} (Count: {countMap[duplicate]})");

                }
            }
        }
        #region Without using InBuilt Method
        #endregion
        public void WithoutInBuiltMethod()
        {
            int[] arr = new int[] { 1, 2, 1, 4, 2, 7, 8, 8, 3 };
            Console.WriteLine("Duplicate elements in given array: ");
            for (int i=0;i<arr.Length; i++)
            {
                for(int j = i + 1; j < arr.Length; j++) 
                {
                    if (arr[i] == arr[j]) 
                    {
                        Console.WriteLine(arr[j]);//1,2,3,4
                    }
                }
            }
        }
    }
}
