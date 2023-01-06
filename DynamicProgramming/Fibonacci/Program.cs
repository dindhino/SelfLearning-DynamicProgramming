// See https://aka.ms/new-console-template for more information
int Fib_Memoization(int n)
{
    List<int> dp = new List<int>();
    for (int i = 0; i <= n; i++)
        dp.Add(-1);

    if (dp[n] == -1)
    {
        if (n <= 1)
            dp[n] = n;
        else
            dp[n] = Fib_Memoization(n - 1) + Fib_Memoization(n - 2);
    }
    return dp[n];

}

int Fib_Tabulated(int n)
{
    List<int> dp = new List<int>();
    for (int i = 0; i <= n; i++)
        dp.Add(-1);

    dp[0] = 0;
    dp[1] = 1;

    for (int i = 2; i <= n; i++)
        dp[i] = dp[i - 1] + dp[i - 2];

    return dp[n];
}

int n = 5;
Console.WriteLine(Fib_Memoization(n));
Console.WriteLine(Fib_Tabulated(n));
Console.ReadLine();