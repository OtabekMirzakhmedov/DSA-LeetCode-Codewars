using Codewars.Sorting;

namespace Codewars;

public class Program
{
    public static void Main2()
    {
        int[] nums = { 64, 25, 12, 22, 11 };
        
        var sorter = new HeapSort();
        int[] sorted = sorter.MinSort(nums);
        
        Console.WriteLine("Before: 64, 25, 12, 22, 11");
        Console.WriteLine("After:  " + string.Join(", ", sorted));


    }

}