using Codewars.DivideAndConquer;
using Codewars.Sorting;

namespace Codewars;

public class Program
{
    public static void Main2()
    {
        int[] nums = { -17, 5, 3, -10, 6, 1, 4, -3, 8, 1, -13, 4 };
        
        var DaC = new LargestSubrange();
        int largestSubrange = DaC.MaxSubArray(nums);
        
        Console.WriteLine("Before: -17, 5, 3, -10, 6, 1, 4, -3, 8, 1, -13, 4");
        Console.WriteLine("After:  " + largestSubrange);


    }

}