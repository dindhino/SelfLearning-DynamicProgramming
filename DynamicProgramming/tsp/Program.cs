// See https://aka.ms/new-console-template for more information
const int INF = 999999999;

List<List<List<int>>> distance = new List<List<List<int>>>();
List<List<int>> dp = new List<List<int>>();
int nHouse, limit, r, c;
List<KeyValuePair<int, int>> house = new List<KeyValuePair<int, int>>();
List<List<char>> gridMap = new List<List<char>>();
List<int> X = new List<int>() { -1, 0, 0, 1 };
List<int> Y = new List<int>() { 0, 1, -1, 0 };
void Init()
{
    house.Clear();
    house.Add(new KeyValuePair<int, int>(0, 0));
    for (int i = 0; i < r; i++)
    {
        for (int j = 0; j < c; j++)
        {
            if (gridMap[i][j] == '*')
                house.Add(new KeyValuePair<int, int>(i, j));
        }
    }

    nHouse = house.Count;
    limit = (1 << nHouse) - 1;

    dp = new List<List<int>>();
    for (int i = 0; i < nHouse; i++)
    {
        List<int> dpRow = new List<int>();
        for (int j = 0; j < limit; j++)
            dpRow.Add(-1);
        dp.Add(dpRow);
    }

    distance = new List<List<List<int>>>();
    for (int i = 0; i < r; i++)
    {
        List<List<int>> distCol = new List<List<int>>();
        for (int j = 0; j < c; j++)
        {
            List<int> distHouse = new List<int>();
            for (int k = 0; k < nHouse; k++)
                distHouse.Add(-1);
            distCol.Add(distHouse);
        }
        distance.Add(distCol);
    }

    for (int i = 0; i < nHouse; i++)
        GetDist(i);
}

void GetDist(int idx)
{
    List<List<bool>> vis = new List<List<bool>>();
    for (int i = 0; i < r; i++)
    {
        List<bool> visItem = new List<bool>();
        for (int j = 0; j < c; j++)
            visItem.Add(false);
        vis.Add(visItem);
    }

    int cx = house[idx].Key;
    int cy = house[idx].Value;

    Queue<KeyValuePair<int, int>> pq = new Queue<KeyValuePair<int, int>>();
    pq.Enqueue(new KeyValuePair<int, int>(cx, cy));

    for (int i = 0; i < r; i++)
        for (int j = 0; j < c; j++)
            distance[i][j][idx] = INF;

    vis[cx][cy] = true;
    distance[cx][cy][idx] = 0;

    while (pq.Count() > 0)
    {
        var x = pq.Peek();
        pq.Dequeue();
        for (int i = 0; i < 4; i++)
        {
            cx = x.Key + X[i];
            cy = x.Value + Y[i];
            if (Safe(cx, cy))
            {
                if (vis[cx][cy])
                    continue;
                vis[cx][cy] = true;
                distance[cx][cy][idx] = distance[x.Key][x.Value][idx] + 1;
                pq.Enqueue(new KeyValuePair<int, int>(cx, cy));
            }
        }
    }

}

bool Safe(int x, int y)
{
    if (x >= r || y >= c || x < 0 || y < 0)
        return false;
    if (gridMap[x][y] == '#')
        return false;
    return true;
}

int Solve(int idx, int mask)
{
    if (mask == limit)
        return distance[0][0][idx];

    if (dp[idx][mask] != -1)
        return dp[idx][mask];

    int ret = INF;

    for (int i = 0; i < nHouse; i++)
    {
        if ((mask & (1 << i)) == 0)
        {
            int newMask = mask | (1 << i);
            ret = Math.Min(ret, Solve(i, newMask) + distance[house[i].Key][house[i].Value][idx]);
        }
    }

    return dp[idx][mask] = ret;
}

void JustSolve()
{
    r = gridMap.Count;
    c = gridMap[0].Count;
    Console.WriteLine("The given grid :");
    for (int i = 0; i < r; i++)
    {
        for (int j = 0; j < c; j++)
            Console.Write(gridMap[i][j] + " ");
        Console.WriteLine();
    }
    Init();
    int ans = Solve(0, 1);
    Console.WriteLine("Minimum distance for the given grid : " + (ans >= INF ? "not possible" : ans));
}

#region Case 1
gridMap = new List<List<char>>()
{
    new List<char>(){'.', '.', '.', '.', '.', '*', '.'},
    new List<char>(){'.', '.', '.', '#', '.', '.', '.'},
    new List<char>(){'.', '*', '.', '#', '.', '*', '.'},
    new List<char>(){'.', '.', '.', '.', '.', '.', '.'}
};
JustSolve();
#endregion Case 1

Console.WriteLine();

#region Case 2
gridMap = new List<List<char>>()
{
    new List<char>(){'.', '.', '.', '#', '.', '.', '.'},
    new List<char>(){'.', '.', '.', '#', '.', '*', '.'},
    new List<char>(){'.', '.', '.', '#', '.', '.', '.'},
    new List<char>(){'.', '*', '.', '#', '.', '*', '.'},
    new List<char>(){'.', '.', '.', '#', '.', '.', '.'}
};
JustSolve();
#endregion Case 2

Console.ReadLine();