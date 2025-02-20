

public class RemoveAllMarkedElementsOfList
{
    
    public static int[] Remove(int[] integerList, int[] valuesList)
    {
        return integerList.Where(x => !valuesList.Contains(x)).ToArray();
    }

    
}