namespace CodingPractice
{
    public class problem
    {
        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { };

        }
        public void PrintTwoSumIndices(int[] nums, int target)
        {
            int[] result = TwoSum(nums, target);

            if (result.Length == 2)
            {
                Console.WriteLine($"The indices of the two numbers that add up to {target} are: [{result[0]}, {result[1]}]");
            }
            else
            {
                Console.WriteLine("No such pair found.");
            }
        }

    }
}
