
namespace Codewars.CountIPAddresses;
public class CountIPAddresses
{
    public static long IpsBetween(string start, string end)
    {
        var startList = start.Split('.').Select(int.Parse).ToArray();
        var endList = end.Split('.').Select(int.Parse).ToArray();;
        long addressesCount = 0;
        for (int i = 0; i < 4; i++)
        {

            if (endList[i] != startList[i])
            {
                addressesCount += (endList[i] - startList[i]) * (long)Math.Pow(256, 3-i);
                
            }
        }
        return addressesCount;
    }
}
