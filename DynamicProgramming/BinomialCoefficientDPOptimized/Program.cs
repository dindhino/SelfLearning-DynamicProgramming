// See https://aka.ms/new-console-template for more information
int BinomialCoeff(int n, int k)
{
    int[] C = new int[k + 1];
    C[0] = 1;
    for (int i = 1; i <= n; i++)
    {
        for (int j = Math.Min(i, k); j > 0; j--)
            C[j] = C[j] + C[j - 1];
    }
    return C[k];
}

int n = 5, k = 2;
Console.Write("Value of C(" + n + "," + k + ") is "
              + BinomialCoeff(n, k));

Console.ReadLine();
