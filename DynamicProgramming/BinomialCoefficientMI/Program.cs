// See https://aka.ms/new-console-template for more information
int BinomialCoeff(int n, int r)
{
    if (r > n) return 0;
    long m = 1000000007;
    long[] inv = new long[r + 1];
    inv[0] = 1;

    if (r + 1 >= 2) inv[1] = 1;
    
    for (int i = 2; i <= r; i++)
        inv[i] = m - (m / i) * inv[(int)(m % i)] % m;
    
    int ans = 1;

    for (int i = 2; i <= r; i++)
        ans = (int)(((ans % m) * (inv[i] % m)) % m);

    for (int i = n; i >= (n - r + 1); i--)
        ans = (int)(((ans % m) * (i % m)) % m);
    return ans;
}

int n = 5, k = 2;
Console.Write("Value of C(" + n + "," + k + ") is "
              + BinomialCoeff(n, k));

Console.ReadLine();
