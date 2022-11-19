void RemoveChild(TreeNode node, TreeNode child)
{
    if (node == null)
    {
        return;
    }
    if (node.left?.val == child.val)
    {
        node.left = null;
    }
    else if (node.right?.val == child.val)
    {
        node.right = null;
    }
}

void Subtree(TreeNode node, TreeNode parent, int[] to_delete, List<TreeNode> roots)
{
    if (node == null)
    {
        return;
    }

    if (to_delete.Contains(node.val))
    {
        RemoveChild(parent, node);
        Subtree(node.left, null, to_delete, roots);
        Subtree(node.right, null, to_delete, roots);
    }
    else
    {
        if (parent == null)
        {
            roots.Add(node);
        }
        Subtree(node.left, node, to_delete, roots);
        Subtree(node.right, node, to_delete, roots);
    }
}

IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
{
    List<TreeNode> roots = new List<TreeNode>();

    if (to_delete == null || to_delete.Length == 0)
    {
        return roots;
    }

    Subtree(root, null, to_delete, roots);

    return roots;
}

TreeNode root = null;
int[] to_delete = null;

root = new TreeNode()
{
    val = 1,
    left = new TreeNode()
    {
        val = 2,
        left = new TreeNode()
        {
            val = 4
        },
        right = new TreeNode()
        {
            val = 5
        }
    },
    right = new TreeNode()
    {
        val = 3,
        left = new TreeNode()
        {
            val = 6
        },
        right = new TreeNode()
        {
            val = 7
        }
    }
};

to_delete = new int[] { 3, 5 };

var roots = DelNodes(root, to_delete);
Console.WriteLine(string.Join(", ", roots.Select(x => x.val)));

root = new TreeNode()
{
    val = 1,
    left = new TreeNode()
    {
        val = 2,
        left = new TreeNode()
        {
            val = 4
        }
    },
    right = new TreeNode()
    {
        val = 3
    }
};

to_delete = new int[] { 3, 5 };

roots = DelNodes(root, to_delete);
Console.WriteLine(string.Join(", ", roots.Select(x => x.val)));
