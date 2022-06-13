namespace Algoritmit
{
    public class Arrays
    {
        public void ReverseString(char[] s)
        {
            if (s.Length == 0 || s == null)
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

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int k = m + n - 1;
            m--;
            n--;

            while (m >= 0 && n >= 0)
            {
                if (nums1[m] > nums2[n])
                {
                    nums1[k--] = nums1[m--];
                }
                else
                {
                    nums1[k--] = nums2[n--];
                }
            }

            while (n >= 0)
            {
                nums1[k--] = nums2[n--];
            }
        }

        public bool IsPalindrome(int x)
        {
            if (x == 0) return true;

            if (x < 0 || x % 10 == 0)
            {
                return false;
            }

            int rev = 0, temp = x;
            while (temp > 0)
            {

                rev = rev * 10 + temp % 10;
                temp /= 10;
            }
            return x == rev;

        }

        public void MoveZeroes(int[] nums)
        {
            int j = 0;
            
            for (int i = 0; i < nums.Length; i++)
                if (nums[i] != 0) 
                    nums[j++] = nums[i];
           

            while (j < nums.Length)
                nums[j++] = 0;
        }

        public int MaxSubArray(int[] nums)
        {
            int maxSum = nums[0];
            int currentSum = maxSum;
          
            for(int i = 1; i < nums.Length; i++)
            {
                currentSum = Math.Max(nums[i] + currentSum, nums[i]);
                maxSum = Math.Max(maxSum, currentSum);
            }

            return maxSum;
        }

        public bool ValidAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            var charCount = new int[226];
            foreach (var c in s)
            {
                charCount[c]++;
            }

            foreach (var c in t)
            {
                charCount[c]--;
                if (charCount[c] < 0)
                {
                    return false;
                }
            }
            return true;
        }

        public int FindMaxConsecutiveOnes(int[] nums)
        {

            int max = 0;
            int currentMax = 0;

            foreach (int num in nums)
            {
                if (num == 1)
                {
                    currentMax++;
                    if (max < currentMax)
                    {
                        max = currentMax;
                    }
                }
                else
                {
                    if (max < currentMax)
                    {
                        max = currentMax;
                    }
                    currentMax = 0;
                }
            }
            return max;
        }

        public int FindNumbers(int[] nums)
        {
            int count = 0;

            foreach(int num in nums)
            {
                if (num.ToString().Length % 2 == 0)
                {
                    count++;
                }
            }
            return count;
        }

        public int[] SortedSquares(int[] nums)
        {
            //for(int i = 0; i < nums.Length; i++)
            //{
            //    nums[i] *= nums[i];
            //}
            int a = 1;
            int b = 10;
            Swap(a, b);

            void Swap(int left, int right)
            {
                if (left >= right) return;

                if (right - left == 1)
                {
                    if (nums[left] <= nums[right]) return;

                    (nums[left], nums[right]) = (nums[right], nums[left]);

                    return;
                }
            }

            return nums;
        }

        public int RemoveDuplicates(int[] nums)
        {

            var count = (nums.Length == 0 ? 0 : 1);

            foreach (var num in nums)
                if (nums[count - 1] < num)
                    nums[count++] = num;

            return count;
        }

        public int SearchInsert(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return 0;

            int n = nums.Length;
            int l = 0;
            int r = n - 1;
            while (l < r)
            {
                int m = l + (r - l) / 2;

                if (nums[m] == target) return m;
                else if (nums[m] > target) r = m; // right could be the result
                else l = m + 1; // m + 1 could be the result
            }

            // 1 element left at the end
            // post-processing
            return nums[l] < target ? l + 1 : l;
        }

        public int CountPrefixes(string[] words, string s)
        {
            int count = 0;
            foreach (string i in words)
            {
                if(i.Length == 0) continue;
                if (s.StartsWith(i)) count++;
            }
            return count;
        }

        public int RemoveElement(int[] nums, int val)
        {

            int index = 0;
            int count = 0; 

            for (int i = 0; i < nums.Length; i++)
            {

                if (nums[index] == val)
                {
                    count++;
                }
                else
                {
                    nums[index - count] = nums[i];
                }

                index++;
            }

            return nums.Length - count;

        }
    }
}
