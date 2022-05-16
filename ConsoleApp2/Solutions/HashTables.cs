namespace Algoritmit
{
    public class HashTables
    {
        
        public int[] TwoSum(int[] nums, int target)
        {

            Dictionary<int, int> myDict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (myDict.ContainsKey(complement))
                {
                    Console.WriteLine("Found at {0} and {1}", myDict[complement], i);
                    return new int[2] { myDict[complement], i };
                }
                if (!myDict.ContainsKey(nums[i]))
                {
                    myDict.Add(nums[i], i);
                }
            }
            return new int[] { };
        }
    }
}
