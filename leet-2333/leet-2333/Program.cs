// complexity: O(max(n, M)) where M - max(abs(diffs))
// space: O(n)
long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2)
{
    int k = k1 + k2;
    int n = nums1.Length;
    var diffs = new int[n];

    // O(n)
    int max = 0;
    for (int i = 0; i < nums1.Length; ++i)
    {
        diffs[i] = Math.Abs(nums1[i] - nums2[i]);
        if(diffs[i] > max )
        {
            max = diffs[i];
        }
    }

    var buckets = new int[max+1];
    for(int i = 0; i < diffs.Length; ++i)
    {
        buckets[diffs[i]] = ++buckets[diffs[i]];
    }

    var k_left = k;
    for(int i = buckets.Length-1; i > 0 && k > 0; --i)
    {
        if( buckets[i] == 0)
        {
            continue;
        }

        var d = Math.Min(k_left, buckets[i]);
        buckets[i] = buckets[i] - d;
        buckets[i-1] = buckets[i - 1] + d;
        k_left -= d;
    }

    // O(n)
    long sum = 0;
    for (int i = 0; i < buckets.Length; ++i)
    {
        sum += (long)buckets[i] * i * i;
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

