using System.Collections.Generic;

namespace Algoritmy
{
    public class Binary_Search // Big O (Log N)
    {
        public int? BinarySearch(IList<int> list, int item)
        {
            int low = 0;
            int high = list.Count - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                var tempItem = list[mid];
                if (tempItem == item) return mid;
                if (tempItem > item)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return null;
        }
    }
}