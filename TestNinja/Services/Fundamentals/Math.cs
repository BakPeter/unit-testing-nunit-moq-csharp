using TestNinja.Interfaces.Fundamentals;

namespace TestNinja.Services.Fundamentals;

public class Math : IMath
{
    public int Add(int n1, int n2)
    {
        return n1 + n2;
    }

    public int Max(int n1, int n2)
    {
        return n1 > n2 ? n1 : n2;
    }

    public int[] GetOddNumbers(int limit)
    {
        var oddNumbers = new List<int>();

        for (int i = 0; i <= limit; i++)
        {
            if (i % 2 != 0) oddNumbers.Add(i);

        }
        return oddNumbers.ToArray();
    }
}