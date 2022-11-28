

int CountNodes(TreeNode root)
{
    int height(TreeNode root, Func<TreeNode, TreeNode> get_node)
    {
        TreeNode cur_node = root;
        int count = 0;
        while (cur_node != null)
        {
            count++;
            cur_node = get_node(cur_node);
        }
        return count;
    }

    if ( root == null)
    {
        return 0;
    }

    int left_height = height(root.left, x => x.left);
    int right_height = height(root.right, x => x.right);

    if (left_height == right_height)
    {
        return (int)Math.Pow(2, left_height + 1) - 1;
    }
    else
    {
        int left_count = CountNodes(root.left);
        int right_count = CountNodes(root.right);

        return left_count + right_count + 1;
    }
}

TreeNode root = null;
int expected = 0;
int result;

