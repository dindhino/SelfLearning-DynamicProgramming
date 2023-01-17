// See https://aka.ms/new-console-template for more information
int nCr(int n, int r)
{
    if (r > n) return 0;
    if (n - r > r) r = n - r;
    int[] SPF = new int[n + 1];
    for (int i = 1; i <= n; i++)
        SPF[i] = i;
    for (int i = 4; i <= n; i += 2)
        SPF[i] = 2;

    for (int i = 3; i * i < n + 1; i += 2)
    {
        if (SPF[i] == i)
        {
            for (int j = i * i; j < n + 1; j += i)
                if (SPF[j] == j)
                    SPF[j] = i;
        }
    }

    Dictionary<int, int> prime_pow = new Dictionary<int, int>();
    for (int i = r + 1; i < n + 1; i++)
    {
        int t = i;
        while (t > 1)
        {
            if (prime_pow.ContainsKey(SPF[t]))
                prime_pow[SPF[t]] = prime_pow[SPF[t]] + 1;
            else
                prime_pow.Add(SPF[t], 1);
            t /= SPF[t];
        }
    }

    for (int i = 1; i < n - r + 1; i++)
    {
        int t = i;
        while (t > 1)
        {
            if (prime_pow.ContainsKey(SPF[t]))
                prime_pow[SPF[t]] = prime_pow[SPF[t]] - 1;
            t /= SPF[t];
        }
    }

    long ans = 1, mod = 1000000007;
    foreach (int i in prime_pow.Keys)
        ans = (ans * Pow(i, prime_pow[i], mod)) % mod;
    return (int)ans;
}

long Pow(long b, long exp, long mod)
{
    long ret = 1;
    while (exp > 0)
    {
        if ((exp & 1) > 0)
            ret = (ret * b) % mod;
        b = (b * b) % mod;
        exp >>= 1;
    }
    return ret;
}

int n = 5, k = 2;
Console.Write("Value of C(" + n + "," + k + ") is "
              + nCr(n, k));

Console.ReadLine();