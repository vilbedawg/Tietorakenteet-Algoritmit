namespace Algoritmit
{
    public class Searching
    {
        private static int interpolationSearch(int[] array, int value)
        {
            int high = array.Length - 1;
            int low = 0;

            while (value >= array[low] && value <= array[high] && low <= high)
            {
                int mid = low + ((value - array[low]) * (high - low) / (array[high] - array[low]));

                Console.WriteLine("mid is : " + mid);
                if (array[mid] == value)
                {
                    return mid;
                }
                else if (array[mid] < value)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }
    }
}
