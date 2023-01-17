// See https://aka.ms/new-console-template for more information
int BinomialCoeff(int n, int k)
{
    if (k > n) return 0;
    if (k == 0 || k == n) return 1;
    return BinomialCoeff(n - 1, k - 1)
            + BinomialCoeff(n - 1, k);
}

int n = 5, k = 2;
Console.Write("Value of C(" + n + "," + k + ") is "
              + BinomialCoeff(n, k));

Console.ReadLine();
