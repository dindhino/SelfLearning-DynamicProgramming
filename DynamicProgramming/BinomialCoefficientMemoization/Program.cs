// See https://aka.ms/new-console-template for more information
int BinomialCoeff(int n, int k)
{
    List<int>[] dp = new List<int>[n + 1];
    for (int i = 0; i < (n + 1); i++)
    {
        dp[i] = new List<int>();
        for (int j = 0; j <= k; j++)
            dp[i].Add(-1);
    }
    return BinomialCoeffUtil(n, k, dp);
}

int BinomialCoeffUtil(int n, int k, List<int>[] dp)
{
    if (dp[n][k] != -1)
        return dp[n][k];

    if (k == 0 || k == n)
    {
        dp[n][k] = 1;
        return dp[n][k];
    }

    return dp[n][k] = BinomialCoeffUtil(n - 1, k - 1, dp)
                        + BinomialCoeffUtil(n - 1, k, dp);
}

int n = 5, k = 2;
Console.Write("Value of C(" + n + "," + k + ") is "
              + BinomialCoeff(n, k));

Console.ReadLine();
