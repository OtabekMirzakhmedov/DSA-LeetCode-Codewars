using NUnit.Framework;

[TestFixture]
public class RemoveAllMarkedElementsOfListTests
{
    [Test, Order(1)]
    [TestCase(new int[]{1, 1, 2, 3, 1, 2, 3, 4}, new int[]{1,3}, ExpectedResult=new int[]{2, 2, 4})]
    [TestCase(new int[]{1, 1, 2, 3, 1, 2, 3, 4, 4, 3 ,5, 6, 7, 2, 8}, new int[]{1, 3, 4, 2}, ExpectedResult=new int[]{5, 6 ,7 ,8})]
    [TestCase(new int[]{}, new int[]{2, 2, 4, 3}, ExpectedResult=new int[]{})]
    public static int[] FixedTest(int[] integerList, int[] valuesList)
    {
        return RemoveAllMarkedElementsOfList.Remove(integerList, valuesList);
    }
  
    [Test, Order(2)]
    public static void RandomTest([Random(0,100,10)]int len1, [Random(0,5,10)]int len2)
    {
        int[] arr1 = GetRandomIntegerList(len1);
        int[] arr2 = GetRandomIntegerList(len2);
        var expected = Solution(arr1, arr2);
        Assert.That(RemoveAllMarkedElementsOfList.Remove(arr1, arr2), Is.EqualTo(expected), string.Format("Should work for integerList = {0} and valuesList = {1}", string.Join(", ", arr1), string.Join(", ", arr2)));
    }
  
    private static int[] GetRandomIntegerList(int len)
    {
        List<int> list = new List<int>();
        Random r = new Random();
        while(len > 0)
        {
            list.Add(r.Next(100));
            len--;
        }
        return list.ToArray();
    }
  
    private static int[] Solution(int[] integerList, int[] valuesList)
    {
        return integerList.Where(x => !valuesList.Contains(x)).ToArray();
    }
}