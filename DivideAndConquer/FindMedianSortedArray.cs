namespace Codewars.DivideAndConquer;

public class FindMedianSortedArray
{
    public float CalculateMedian(int[] nums1, int[] nums2)
    {
        int m = nums1.Length;
        int n = nums2.Length;

        if (m > n)
        {
            return CalculateMedian(nums2, nums1);
        }
        
        int totalLength = m + n;
        int halfLength = (totalLength + 1) / 2;
        int left = 0;
        int right = m;
        
        while (left <= right)
        {
            int partitionX = (left + right) / 2;
            int partitionY = halfLength - partitionX;
            int maxX_left = (partitionX == 0) ? int.MinValue : nums1[partitionX - 1];
            int minX_right = (partitionX == m) ? int.MaxValue : nums1[partitionX];
            
            int maxY_left = (partitionY == 0) ? int.MinValue : nums2[partitionY - 1];
            int minY_right = (partitionY == n) ? int.MaxValue : nums2[partitionY];

            if (maxX_left <= minY_right && maxY_left <= minX_right)
            {
                if (totalLength % 2 != 0)
                {
                    return Math.Max(maxX_left, maxY_left);
                }
                else
                {
                    return (Math.Max(maxX_left, maxY_left) + Math.Min(minX_right, minY_right)) / 2.0f;
                }
            }
            else if (maxX_left > minY_right)
            {
                right = partitionX - 1;
            }
            else
            {
                left = partitionX + 1;
            }
        }
        
        throw new ArgumentException("Input arrays are not sorted");
    }
}