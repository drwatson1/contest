bool IsValid(int[][] heights, int r, int c)
{
    return r >= 0 && r < heights.Length && c >= 0 && c < heights[0].Length;
}

int MinimumEffortPath(int[][] heights)
{
    bool[][] visited = new bool[heights.Length][];
    int[][] efforts = new int[heights.Length][];
    for (int i = 0; i < heights.Length; i++)
    {
        visited[i] = new bool[heights[0].Length];
        efforts[i] = new int[heights[0].Length];
    }
    LinkedList<(int r, int c)> queue = new LinkedList<(int, int)>();
    queue.AddLast((0, 0));
    visited[0][0] = true;

    void AddNextEdge((int r, int c) cur, int r, int c)
    {
        if (IsValid(heights, r, c))
        {
            (int r, int c) next = (r, c);
            var e = Math.Max(efforts[cur.r][cur.c], Math.Abs(heights[r][c] - heights[cur.r][cur.c]));
            if (!visited[r][c])
            {
                queue.AddLast(next);
                visited[r][c] = true;
                efforts[r][c] = e;
            }
            else
            {
                if (e < efforts[r][c])
                {
                    efforts[r][c] = e;
                    queue.AddLast(next);
                }
            }
        }

    }

    while (queue.Count > 0)
    {
        var cur = queue.First.Value;

        queue.RemoveFirst();

        AddNextEdge(cur, cur.r, cur.c + 1); // right
        AddNextEdge(cur, cur.r + 1, cur.c); // down
        AddNextEdge(cur, cur.r, cur.c - 1); // left
        AddNextEdge(cur, cur.r - 1, cur.c); // up
    }

    return efforts[heights.Length - 1][heights[0].Length - 1];
}

int[][] heights;
int res = 0;

heights = new int[][] { new int[] { 1, 1}, new int[] { 1, 1} };
res = MinimumEffortPath(heights);
Console.WriteLine($"0 -> {res}");

heights = new int[][] { new int[] { 1, 3 }, new int[] { 2, 3 } };
res = MinimumEffortPath(heights);
Console.WriteLine($"1 -> {res}");

heights = new int[][] { new int[] { 1, 2, 2 }, new int[] { 3, 8, 2 }, new int[] { 5, 3, 5 } };
res = MinimumEffortPath(heights);
Console.WriteLine($"2 -> {res}");

heights = new int[][] { new int[] { 1, 2, 3 }, new int[] { 3, 8, 4 }, new int[] { 5, 3, 5 } };
res = MinimumEffortPath(heights);
Console.WriteLine($"1 -> {res}");

heights = new int[][] { new int[] { 1, 2, 1, 1, 1 }, new int[] { 1, 2, 1, 2, 1 }, new int[] { 1, 2, 1, 2, 1 }, new int[] { 1, 2, 1, 2, 1 }, new int[] { 1, 1, 1, 2, 1 } };
res = MinimumEffortPath(heights);
Console.WriteLine($"0 -> {res}");

