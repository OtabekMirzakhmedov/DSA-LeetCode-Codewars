using Codewars.DivideAndConquer;
using Codewars.Sorting;

namespace Codewars;

public class Program
{
    public static void Main2()
    {
        int[] nums1 = { 1, 3};
        int[] nums2 = { 2 };

        var closestPair = new FindMedianSortedArray();
        float closestDistance = closestPair.CalculateMedian(nums1, nums2);

        Console.WriteLine(closestDistance);


    }

}