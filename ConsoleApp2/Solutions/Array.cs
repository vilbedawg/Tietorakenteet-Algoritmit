namespace Algoritmit
{
    public class Array
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
                if(!myDict.ContainsKey(nums[i]))
                {
                    myDict.Add(nums[i], i);
                }
            }
            return new int[] { };
        }
        public void ReverseString(char[] s)
        {
            if(s.Length == 0 || s == null)
            {
                return;
            }

            for (int i = 0, j = s.Length - 1; i <= j; i++, j--)
            {
                char temp = s[i];
                s[i] = s[j];
                s[j] = temp;
            }
            return;
        }
        public string ReverseStrII(string s, int k)
        {
            
            char[] arr = s.ToCharArray();

            // Every 2k characters i.e. i = i+2*k - step function
            for (int i = 0; i < s.Length; i = i + 2 * k)
            {
                int l = i;
                //If there are less than k characters left, reverse all of them, ensure we don't cross the array boundary 
                int r = Math.Min(s.Length - 1, i + k - 1);
                while (l < r)
                {
                    // Swap the variable and Move the two pointers in opposite direction
                    char t = s[l];
                    arr[l++] = s[r];
                    arr[r--] = t;
                }
            }
            Console.WriteLine(arr);
            return new string(arr);
        }

    }
}
