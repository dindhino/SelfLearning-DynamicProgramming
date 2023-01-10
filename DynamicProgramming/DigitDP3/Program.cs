// See https://aka.ms/new-console-template for more information

int SumOfDigitsFrom1ToN(int n)
{
    int d = (int)(Math.Log10(n));
    int[] a = new int[d + 1];
    a[0] = 0; a[1] = 45;
    for (int i = 2; i <= d; i++)
        a[i] = a[i - 1] * 10 + 45 *
            (int)(Math.Ceiling(Math.Pow(10, i - 1)));

    return SumOfDigitsFrom1ToNUtil(n, a);
}

int SumOfDigitsFrom1ToNUtil(int n, int[] a)
{
    if (n < 10)
        return (n * (n + 1) / 2);

    int d = (int)(Math.Log10(n));
    int p = (int)(Math.Ceiling(Math.Pow(10, d)));
    int msd = n / p;
    return (msd * a[d] + (msd * (msd - 1) / 2) * p +
        msd * (1 + n % p) + SumOfDigitsFrom1ToNUtil(n % p, a));
}

int n = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Sum of digits in numbers " +
                    "from 1 to " + n + " is " +
                    SumOfDigitsFrom1ToN(n));

Console.ReadLine();
