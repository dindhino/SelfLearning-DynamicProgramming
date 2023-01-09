// See https://aka.ms/new-console-template for more information
List<List<int>> capList = new List<List<int>>();
int allMask;
List<List<int>> dp = new List<List<int>>();
const int MOD = 1000000007;

void Init(int n)
{
    allMask = (1 << n) - 1;

    for (int i = 0; i < 101; i++)
        capList.Add(new List<int>());

    for (int i = 0; i < 1025; i++)
    {
        List<int> dpRow = new List<int>();
        for (int j = 0; j < 101; j++)
            dpRow.Add(-1);
        dp.Add(dpRow);
    }
}

void CountWays(int n)
{
    string str;
    List<string> split;
    int x;
    Init(n);

    for (int i = 0; i < n; i++)
    {
        str = Console.ReadLine();
        split = str.Split(" ").ToList();
        for (int j = 0; j < split.Count; j++)
        {
            x = Convert.ToInt32(split[j]);
            capList[x].Add(i);
        }
    }

    Console.WriteLine(CountWaysUtil(0, 1));
}

long CountWaysUtil(int mask, int i)
{
    if (mask == allMask) return 1;
    if (i > 100) return 0;
    if (dp[mask][i] != -1) return dp[mask][i];
    long ways = CountWaysUtil(mask, i + 1);
    int size = capList[i].Count();

    for (int j = 0; j < size; j++)
    {
        if ((mask & (1 << capList[i][j])) != 0) continue;
        else ways += CountWaysUtil(mask | (1 << capList[i][j]), i + 1); 
        ways %= MOD;
    }

    return dp[mask][i] = (int)ways;
}

int n = Convert.ToInt32(Console.ReadLine());
CountWays(n);
Console.ReadLine();