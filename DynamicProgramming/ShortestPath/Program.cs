// See https://aka.ms/new-console-template for more information
const int INF = int.MaxValue;

long ShortestPath(List<List<int>> graph, int u, int v)
{
    int n = graph.Count;

    for (int z = 0; z < n; z++)
        for (int x = 0; x < n; x++)
            for (int y = 0; y < n; y++)
                    graph[x][y] = Math.Min(graph[x][y], (graph[x][z] == INF || graph[z][y] == INF) ? INF : graph[x][z] + graph[z][y]);

    return graph[u][v];
}

List<List<int>> graph = new List<List<int>>()
{
    new List<int>() { 0, 5, INF, 10 },
    new List<int>() { INF, 0, 3, INF },
    new List<int>() { INF, INF, 0, 1 },
    new List<int>() { INF, INF, INF, 0 }
};

Console.WriteLine("Shortest path from 0 to 3: " + ShortestPath(graph, 0, 3));
Console.ReadLine();