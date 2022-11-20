// complexity: O(4*N + n * log n)
// space: O(2*n)
long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2)
{
    int k = k1 + k2;
    var diffs = new List<int>();

    // O(n)
    for (int i = 0; i < nums1.Length; ++i)
    {
        diffs.Add(Math.Abs(nums1[i] - nums2[i]));
    }

    // O(n log n)
    diffs.Sort();

    var diff_pairs = new List<(int, int, int, int)>();
    int b = diffs.Count;

    {
        // O(n)
        int j = diffs.Count - 1;
        while (j >= 0 && k > 0)
        {
            if (j == 0 || diffs[j - 1] < diffs[j])
            {
                var diff = j > 0 ? Math.Min(diffs[j] - diffs[j - 1], Math.Min(diffs[j], k)) : Math.Min(diffs[j], k);
                var c = diffs.Count - j;
                var k_delta = Math.Min(c * diff, k);
                k -= k_delta;
                diff_pairs.Add((j, b, diff, k_delta));
                b = j;
            }
            --j;
        }
    }

    int sum_diff = 0;
    // O(n)
    for (int i = diff_pairs.Count - 1; i >= 0; --i)
    {
        var p = diff_pairs[i];
        int k_delta = p.Item4;
        int diff = p.Item3;
        for (int j = p.Item1; j < p.Item2 && k_delta > 0; ++j)
        {
            var delta = Math.Min(diffs[j], Math.Min(diff, k_delta));
            diffs[j] = diffs[j] - delta;
            k_delta -= delta;
        }
        sum_diff += diff;
    }

    // O(n)
    long sum = 0;
    for (int i = 0; i < diffs.Count; ++i)
    {
        sum += (long)diffs[i] * diffs[i];
    }

    return sum;
}

int[] nums1 = null;
int[] nums2 = null;
int k1 = 0;
int k2 = 0;
long expected = 0;
long result = 0;

nums1 = new int[] { 1, 4, 10, 12 };
nums2 = new int[] { 5, 8, 6, 9 };
k1 = 10;
k2 = 5;
expected = 0;

result = MinSumSquareDiff(nums1, nums2, k1, k2);
Console.WriteLine($"[{string.Join(", ", nums1)}] - [{string.Join(", ", nums2)}], k1 = {k1}, k2 = {k2} => {result} (expected {expected})");


nums1 = new int[] { 1, 4, 10, 12 };
nums2 = new int[] { 5, 8, 6, 9 };
k1 = 1;
k2 = 1;
expected = 43;

result = MinSumSquareDiff(nums1, nums2, k1, k2);
Console.WriteLine($"[{string.Join(", ", nums1)}] - [{string.Join(", ", nums2)}], k1 = {k1}, k2 = {k2} => {result} (expected {expected})");

nums1 = new int[] { 1, 2, 3, 4 };
nums2 = new int[] { 2, 10, 20, 19 };
k1 = 0;
k2 = 0;
expected = 579;

result = MinSumSquareDiff(nums1, nums2, k1, k2);
Console.WriteLine($"[{string.Join(", ", nums1)}] - [{string.Join(", ", nums2)}], k1 = {k1}, k2 = {k2} => {result} (expected {expected})");

