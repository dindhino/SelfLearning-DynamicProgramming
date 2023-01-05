// See https://aka.ms/new-console-template for more information
int Fibo(int n)
{
    List<int> dp = new List<int>();
    for (int i = 0; i <= n; i++)
        dp.Add(-1);
    return FiboHelper(n, dp);
}

int FiboHelper(int n, List<int> dp)
{
    if (n <= 1) return n;
    if (dp[n] != -1) return dp[n];

    return dp[n] = FiboHelper(n - 1, dp) + FiboHelper(n - 2, dp);
}

int n = 5;
Console.WriteLine(Fibo(n));
Console.ReadLine();