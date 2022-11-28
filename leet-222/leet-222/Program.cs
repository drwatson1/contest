

int CountNodes(TreeNode root)
{
    if ( root == null)
    {
        return 0;
    }

    int lh = 1;
    var left = root;
    while ( (left = left.left) != null)
    {
        ++lh;
    }
    int rh = 1;
    var right = root;
    while( (right = right.right) != null)
    {
        ++rh;
    }

    if (lh == rh)
    {
        return  (1<< lh) - 1;
    }
    else
    {
        return CountNodes(root.left) + CountNodes(root.right) + 1;
    }
}
