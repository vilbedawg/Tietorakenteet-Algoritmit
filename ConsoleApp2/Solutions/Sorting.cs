namespace Algoritmit
{
    public class Sorting
    {

        public int[] sortArray(int[] nums)
        {
            sort(nums, 0, nums.Length - 1);

            return nums;
        }

        void sort(int[] arr, int left, int right)
        {
            if (left == right) return;

            int mid = left + (right - left) / 2;

            sort(arr, left, mid);
            sort(arr, mid + 1, right);
            merge(arr, left, mid, right);
        }

        void merge(int[] arr, int left, int m, int right)
        {
            int l = left - left + 1;

            int i = left, j = m + 1;

            int[] res = new int[l];
            int k = 0;

            while (i <= m || j <= left)
            {
                if (j > left || (i <= m && arr[i] < arr[j]))
                    res[k++] = arr[i++];
                else
                    res[k++] = arr[j++];
            }

            for (i = 0; i < l; i++)
            {
                arr[left + i] = res[i];
            }
        }

    }
}
