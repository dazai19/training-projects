
namespace Algoritmy;

public class Selection_Sort
{
    public int[] SelectionSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            var smallestIndex = i;
            for (int remainingIndex = i + 1; remainingIndex < arr.Length; remainingIndex++)
            {
                if (arr[remainingIndex] < arr[smallestIndex])
                {
                    smallestIndex = remainingIndex;
                }
            }

            int tempItem = arr[i];
            arr[i] = arr[smallestIndex];
            arr[smallestIndex] = tempItem;
        }
        return arr;
    }
}