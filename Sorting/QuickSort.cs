namespace Codewars.Sorting;

public class QuickSort
{
    public int[] Sort(int[] nums)
    {
        quick_sort(nums, 0,nums.Length-1);
        return nums;
    }

    public void quick_sort(int[] array, int low, int high)
    {
        int PartitionIndex;
        if (low < high)
        {
            PartitionIndex = partition(array, low, high);
            quick_sort(array, low, PartitionIndex-1);
            quick_sort(array, PartitionIndex+1, high);
        }
    }

    public int partition(int[] array, int low, int high)
    {
        int i;
        int PivotElementIndex;
        int firstHigh;

        PivotElementIndex = high;
        firstHigh = low;
        for (i = low; i < high; i++)
        {
            if (array[i] < array[PivotElementIndex])
            {
                (array[i], array[firstHigh]) = (array[firstHigh], array[i]);
                firstHigh++;
            }
        }

        (array[PivotElementIndex], array[firstHigh]) = (array[firstHigh], array[PivotElementIndex]);
        return firstHigh;
    }
}