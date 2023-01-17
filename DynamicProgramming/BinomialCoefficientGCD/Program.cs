// See https://aka.ms/new-console-template for more information
int nCr(int n, int r)
{
    if (r > n) return 0;
    if (r > n - r) r = n - r;
    int mod = 1000000007;
    int[] arr = new int[r];
    for (int i = n - r + 1; i <= n; i++)
        arr[i + r - n - 1] = i;
    long ans = 1;

    for (int k = 1; k < r + 1; k++)
    {
        int j = 0, i = k;
        while (j < arr.Length)
        {
            int x = GCD(i, arr[j]);
            if (x > 1)
            {
                arr[j] /= x;
                i /= x;
            }
            if (i == 1)
                break;
            j++;
        }
    }

    foreach (int i in arr)
        ans = (ans * i) % mod;

    return (int)ans;
}

int GCD(int a, int b)
{
    if (b == 0) return a;
    return GCD(b, a % b);
}

int n = 5, k = 2;
Console.Write("Value of C(" + n + "," + k + ") is "
              + nCr(n, k));

Console.ReadLine();
