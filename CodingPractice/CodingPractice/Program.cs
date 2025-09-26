using CodingPractice;

internal class Program
{
    public static void Main(string[] args)
    {
        //    Ratios ratios = new Ratios();
        //    ratios.CalculateRatios();
   
        //MinMax minMax = new MinMax();
        //Console.WriteLine("The integer values{1,3,5,7,9}");
        //minMax.MinMaxSum(1, 3, 5, 7, 9);
        //int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);
        //minMax.MinMaxSum(arr);

        //Duplicates
        ToFindDuplicates dupli = new ToFindDuplicates();
        //dupli.FindDuplicateUsingDict();
        //dupli.UsingHashSet();
        //dupli.WithoutInBuiltMethod();

        //Anagram
        //Anagrams anagrams = new Anagrams();
        //anagrams.isAnagram();

        //ReverseString
        //ReverseAString str = new ReverseAString();
        //str.Reverse();

        int[] nums = { 2, 11, 15,7 };
        int target = 9;

        problem solution = new problem();
        solution.PrintTwoSumIndices(nums, target);


    }
}