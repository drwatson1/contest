// complexity: O(N)
// Space: ?
bool isLeaf(TreeNode node) => node.left == null && node.right == null;

void dfs(TreeNode node, int targetSum, int sum, IList<int> path, IList<IList<int>> paths)
{
    if (node == null)
    {
        return;
    }
    sum += node.val;

    path.Add(node.val);
    if (!isLeaf(node))
    {
        if (node.left != null)
        {
            dfs(node.left, targetSum, sum, path, paths);
            path.RemoveAt(path.Count - 1);
        }
        if (node.right != null)
        {
            dfs(node.right, targetSum, sum, path, paths);
            path.RemoveAt(path.Count - 1);
        }
        return;
    }

    if (sum != targetSum)
    {
        return;
    }

    paths.Add(path.ToList());

    return;
}

IList<IList<int>> PathSum(TreeNode root, int targetSum)
{
    IList<int> path = new List<int>();
    IList<IList<int>> paths = new List<IList<int>>();

    int sum = 0;
    dfs(root, targetSum, sum, path, paths);

    return paths.Select(x => (IList<int>)x).ToList();
}

void PrintResult(IList<IList<int>> res)
{
    Console.Write("[");
    for (int i = 0; i < res.Count; i++)
    {
        string s = "";
        for (int j = 0; j < res[i].Count; j++)
        {
            if (s.Length > 0)
            {
                s += ",";
            }
            s += res[i][j];
        }
        Console.Write($"[{s}]");
    }
    Console.WriteLine("]");
}

TreeNode root = null;
int targetSum = 0;

targetSum = 22;
root = new TreeNode(5,
    new TreeNode(4,
        new TreeNode(11,
            new TreeNode(7),
            new TreeNode(2))
        ),
    new TreeNode(8,
        new TreeNode(13),
        new TreeNode(4,
            new TreeNode(5),
            new TreeNode(1)
        )
    )
);

var res = PathSum(root, targetSum);
PrintResult(res);

root = new TreeNode(1,
    new TreeNode(2),
    new TreeNode(3));
targetSum = 5;

res = PathSum(root, targetSum);
PrintResult(res);

root = new TreeNode(1,
    new TreeNode(2));
targetSum = 0;

res = PathSum(root, targetSum);
PrintResult(res);
