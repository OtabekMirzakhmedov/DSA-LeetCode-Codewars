using Codewars.DivideAndConquer;
using Codewars.Sorting;

namespace Codewars;

public class Program
{
    public static void Main2()
    {
        int[] nums = { -2, 3, 8, 9, 12, 25, 27};
        
        var sorter = new MergeSort();
        int[] sortedArray = sorter.Sort(nums);
        var closestPair = new ClosestPair();
        int closestDistance = closestPair.FindClosestPair(sortedArray);
        
        Console.WriteLine("Before: -17, 5, 3, -10, 6, 1, 4, -3, 8, 1, -13, 4");
        Console.WriteLine("After:  " + string.Join(' ', sortedArray));
        Console.WriteLine(closestDistance);


    }

}