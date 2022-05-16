namespace Algoritmit
{
    public class Sorting
    {

        public int[] sortArray(int[] nums)
        {
            sort(nums, 0, nums.Length - 1);

            return nums;
        }

        void sort(int[] arr, int b, int e)
        {
            if (b == e) return;

            int mid = b + (e - b) / 2;

            sort(arr, b, mid);
            sort(arr, mid + 1, e);
            merge(arr, b, mid, e);
        }

        void merge(int[] arr, int b, int m, int e)
        {
            int l = e - b + 1;

            int i = b, j = m + 1;

            int[] res = new int[l];
            int k = 0;

            while (i <= m || j <= e)
            {
                if (j > e || (i <= m && arr[i] < arr[j]))
                    res[k++] = arr[i++];
                else
                    res[k++] = arr[j++];
            }

            for (i = 0; i < l; i++)
            {
                arr[b + i] = res[i];
            }
        }
    }
}
