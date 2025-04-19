namespace Codewars.Sorting
{
    public class MergeSort
    {
        public int[] Sort(int[] nums)
        {
            int length = nums.Length;
            int[] aux = new int[length];
            merge_sort(nums, aux, 0, length - 1);
            return nums;
        }
        
        public void merge_sort(int[] array, int[] aux, int low, int high)
        {
            if (low < high)
            {
                int middle = (low + high) / 2;
                merge_sort(array, aux, low, middle);
                merge_sort(array, aux, middle + 1, high);
                merge(array, aux, low, middle, high);
            }
        }
        
        public void merge(int[] array, int[] aux, int low, int middle, int high)
        {
            for (int k = low; k <= high; k++)
                aux[k] = array[k];

            int i = low, j = middle + 1;
            
            for (int k = low; k <= high; k++)
            {
                if (i > middle)
                    array[k] = aux[j++];
                else if (j > high)
                    array[k] = aux[i++];
                else if (aux[i] <= aux[j])
                    array[k] = aux[i++];
                else
                    array[k] = aux[j++];
            }
        }
    }
}