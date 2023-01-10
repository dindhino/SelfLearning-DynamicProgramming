// See https://aka.ms/new-console-template for more information
const int nIndex = 9, nMaxDigit = 18, nTight = 2;
List<List<List<long>>> dp;

void Init()
{
    dp = new List<List<List<long>>>();
    for (int i = 0; i <= nMaxDigit; i++)
    {
        List<List<long>> dpCol = new List<List<long>>();
        for (int j = 0; j <= nMaxDigit * nIndex; j++)
        {
            List<long> dpTight = new List<long>();
            for (int k = 0; k <= nTight; k++)
                dpTight.Add(-1);
            dpCol.Add(dpTight);
        }
        dp.Add(dpCol);
    }
}

void GetDigits(int x, List<int> digit)
{
    while (x != 0)
    {
        digit.Add(x % 10);
        x /= 10;
    }
}

long JustDigitSum(int idx, int sum, int tight, List<int> digit)
{
    if (idx == -1) return sum;
    if (dp[idx][sum][tight] != -1 && tight != 1) return dp[idx][sum][tight];
    long ret = 0;
    int k = (tight != 0) ? digit[idx] : nIndex;
    for (int i = 0; i <= k; i++)
    {
        int newTight = (digit[idx] == i) ? tight : 0;
        ret += JustDigitSum(idx - 1, sum + i, newTight, digit);
    }
    if (tight != 0) dp[idx][sum][tight] = ret;
    return ret;
}

long DigitSum(int x)
{
    List<int> digit = new List<int>();
    GetDigits(x, digit);
    return JustDigitSum(digit.Count - 1, 0, 1, digit);
}

int RangeDigitSum(int a, int b)
{
    Init();
    return (int)(DigitSum(b) - DigitSum(a - 1));
}

int a = Convert.ToInt32(Console.ReadLine());
int b = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Digit sum for given range: " + RangeDigitSum(a, b));
Console.ReadLine();