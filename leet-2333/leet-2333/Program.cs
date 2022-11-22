// complexity: O(3*N + n * log n)
// space: O(n)
long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2)
{
    int k = k1 + k2;
    int n = nums1.Length;
    var diffs = new List<int>();

    // O(n)
    for (int i = 0; i < nums1.Length; ++i)
    {
        diffs.Add(Math.Abs(nums1[i] - nums2[i]));
    }

    if (k > 0)
    {
        // O(n log n)
        diffs.Sort();

        int begin = n;
        int k_delta = k;
        {
            // O(n)
            int j = diffs.Count - 1;
            int k_sum = 0;
            while (j >= 0 && k_sum < k)
            {
                if (j == 0 || diffs[j - 1] < diffs[j])
                {
                    var diff = j > 0 ? diffs[j] - diffs[j - 1] : diffs[j];
                    k_delta = Math.Min(diff * (n - j), k - k_sum);
                    k_sum += k_delta;
                    begin = j;
                }
                --j;
            }
        }

        int target_val = diffs[begin] - (k_delta / (n - begin));
        int minus_one_count = k_delta % (n - begin);

        for (int i = begin; i < n; i++)
        {
            int d = 0;
            if (minus_one_count > 0)
            {
                d = 1;
                --minus_one_count;
            }
            diffs[i] = target_val - d;
        }
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

nums1 = new int[] { 1, 4, 10 };
nums2 = new int[] { 4, 7, 13 };
k1 = 3;
k2 = 6;
expected = 0;

result = MinSumSquareDiff(nums1, nums2, k1, k2);
Console.WriteLine($"[{string.Join(", ", nums1)}] - [{string.Join(", ", nums2)}], k1 = {k1}, k2 = {k2} => {result} (expected {expected})");

nums1 = new int[] { 1, 4, 10 };
nums2 = new int[] { 4, 7, 13 };
k1 = 2;
k2 = 2;
expected = 9;

result = MinSumSquareDiff(nums1, nums2, k1, k2);
Console.WriteLine($"[{string.Join(", ", nums1)}] - [{string.Join(", ", nums2)}], k1 = {k1}, k2 = {k2} => {result} (expected {expected})");

nums1 = new int[] { 1, 4, 10, 12 };
nums2 = new int[] { 5, 8, 6, 9 };
k1 = 9;
k2 = 5;
expected = 1;

result = MinSumSquareDiff(nums1, nums2, k1, k2);
Console.WriteLine($"[{string.Join(", ", nums1)}] - [{string.Join(", ", nums2)}], k1 = {k1}, k2 = {k2} => {result} (expected {expected})");

nums1 = new int[] { 1, 4, 10, 12 };
nums2 = new int[] { 5, 8, 6, 9 };
k1 = 4;
k2 = 5;
expected = 10;

result = MinSumSquareDiff(nums1, nums2, k1, k2);
Console.WriteLine($"[{string.Join(", ", nums1)}] - [{string.Join(", ", nums2)}], k1 = {k1}, k2 = {k2} => {result} (expected {expected})");

nums1 = new int[] { 1, 4, 10, 12 };
nums2 = new int[] { 5, 8, 6, 9 };
k1 = 10;
k2 = 5;
expected = 0;

result = MinSumSquareDiff(nums1, nums2, k1, k2);
Console.WriteLine($"[{string.Join(", ", nums1)}] - [{string.Join(", ", nums2)}], k1 = {k1}, k2 = {k2} => {result} (expected {expected})");

nums1 = new int[] { 1, 4, 10, 12, 15 };
nums2 = new int[] { 5, 8, 6, 9, 12 };
k1 = 11;
k2 = 5;
expected = 2;

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

