namespace Algoritmy;

public class Recursion
{
    public int Fact(int x)
    {
        if (x <= 1) return 1;

        return x * Fact(x - 1);
    }
}