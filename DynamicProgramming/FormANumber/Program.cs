// See https://aka.ms/new-console-template for more information
int n = 7;
List<int> dp = new List<int>();
for (int i = 0; i <= n; i++)
    dp.Add(-1);
int Solve(int n)
{
    if (n < 0)
        return 0;
    if (n == 0)
    {
        dp[n] = 1;
        return dp[n];
    }

    if (dp[n] != -1)
        return dp[n];

    return dp[n] = Solve(n - 1) + Solve(n - 3) + Solve(n - 5);
}

Console.WriteLine(Solve(n));

Console.ReadLine();
