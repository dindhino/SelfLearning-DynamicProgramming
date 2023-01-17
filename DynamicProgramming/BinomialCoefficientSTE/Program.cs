// See https://aka.ms/new-console-template for more information
int BinomialCoeff(int n, int k)
{
    int res = 1;
    if (k > n - k) k = n - k;

    for (int i = 0; i < k; ++i)
    {
        res *= (n - i);
        res /= (i + 1);
    }
    return res;
}

int n = 5, k = 2;
Console.Write("Value of C(" + n + "," + k + ") is "
              + BinomialCoeff(n, k));

Console.ReadLine();
