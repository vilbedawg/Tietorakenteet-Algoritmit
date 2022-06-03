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

        public int FirstRecurringCharacter(string s)
        {

            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (dic.ContainsKey(c))
                    dic[c] += 1;
                else
                    dic.Add(c, 1);
            }

            for (int i = 0; i < s.Length; i++)
                if (dic[s[i]] == 1)
                    return i;

            return -1;
        }

        public string FrequencySort(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            char[] chars = new char[26];

            foreach (char c in s)
            {
                if (dic.ContainsKey(c))
                    dic[c] += 1;
                else
                    dic.Add(c, 1);
            }

            throw new NotImplementedException("Not yet implemented");
        }

        public int LengthOfLongestSubstring(string s)
        {
            if(s.Length == 0 || s.Length == 1) return s.Length;

            string sub = "";
            int tmp = 0;
            foreach(char c in s)
            {
                if(sub.IndexOf(c) != -1)
                {
                    tmp = Math.Max(sub.Length, tmp);
                    int ind = sub.IndexOf(c) + 1;
                    sub = sub.Substring(ind);
                    sub += c;
                }
                else
                {
                    sub += c;
                }
            }

            return Math.Max(sub.Length, tmp);
        }


    }
}
