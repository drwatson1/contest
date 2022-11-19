// complexity: O(n)
// space: O(n)
IList<int> MaxScoreIndices(int[] nums)
{
    List<int> indexes = new List<int>();

    int[] count = new int[nums.Length+1];

    int z_count = 0;
    for(int i = 1; i <= nums.Length; i++)
    {
        if (nums[i-1] == 0 )
        {
            ++z_count;
        }
        count[i] += z_count;
    }

    int o_count = 0;
    for(int i = nums.Length-1; i >= 0; i--)
    {
        if(nums[i]==1)
        {
            o_count++;
        }
        count[i] += o_count;
    }

    int max = 0;
    for(int i = 0; i < count.Length; i++)
    {
        if (count[i] == max)
        {
            indexes.Add(i);
        }
        else if (count[i] > max)
        {
            max = count[i];
            indexes.Clear();
            indexes.Add(i);
        }
    }

    return indexes;
}

int[] nums = null;
int[] expected = null;
IList<int> result = null;

nums = new int[] { 0 };
expected = new int[] { 1 };
result = MaxScoreIndices(nums);
Console.WriteLine($"[{string.Join(",", nums)}] => [{string.Join(",", result)}] (expected: [{string.Join(",", expected)}])");

nums = new int[] { 0, 0, 0 };
expected = new int[] { 3 };
result = MaxScoreIndices(nums);
Console.WriteLine($"[{string.Join(",", nums)}] => [{string.Join(",", result)}] (expected: [{string.Join(",", expected)}])");

nums = new int[] { 1 };
expected = new int[] { 0 };
result = MaxScoreIndices(nums);
Console.WriteLine($"[{string.Join(",", nums)}] => [{string.Join(",", result)}] (expected: [{string.Join(",", expected)}])");

nums = new int[] { 1, 1 };
expected = new int[] { 0 };
result = MaxScoreIndices(nums);
Console.WriteLine($"[{string.Join(",", nums)}] => [{string.Join(",", result)}] (expected: [{string.Join(",", expected)}])");

nums = new int[] { 0, 0, 1, 0 };
expected = new int[] { 2, 4 };
result = MaxScoreIndices(nums);
Console.WriteLine($"[{string.Join(",", nums)}] => [{string.Join(",", result)}] (expected: [{string.Join(",", expected)}])");

