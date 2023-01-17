// See https://aka.ms/new-console-template for more information
int BinomialCoeff(int n, int k)
{
    int[,] C = new int[n + 1, k + 1];
    int i, j;

    for (i = 0; i <= n; i++)
    {
        for (j = 0; j <= Math.Min(i, k); j++)
        {
            if (j == 0 || j == i)
                C[i, j] = 1;
            else
                C[i, j] = C[i - 1, j - 1] + C[i - 1, j];
        }
    }

    return C[n, k];
}

int n = 5, k = 2;
Console.Write("Value of C(" + n + "," + k + ") is "
              + BinomialCoeff(n, k));

Console.ReadLine();
