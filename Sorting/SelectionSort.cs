namespace Codewars.Sorting;

public class SelectionSort
{
    public int[] Sort(int[] nums)
    {
        int length = nums.Length;
        for (int i = 0; i < length-1; i++)
        {
            int minpos = i;
            for (int j = i+1; j < length; j++)
            {
                if (nums[j] < nums[minpos])
                {
                    minpos = j;
                }
            }

            if (minpos != i)
            {
                (nums[minpos], nums[i]) = (nums[i], nums[minpos]);
            }
        }

        return nums;
    }
}