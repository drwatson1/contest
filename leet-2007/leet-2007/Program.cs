// See https://aka.ms/new-console-template for more information


void Sort(int[] arr)
{
    if (arr.Length < 2)
    {
        return;
    }
    for (int i = 0; i < arr.Length - 1; i++)
    {
        for (int j = i + 1; j < arr.Length; j++)
        {
            if (arr[i] > arr[j])
            {
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }
    }
}

int Partition(int[] arr, int s, int e)
{
    int p = arr[e];
    int i = s - 1;
    for(int j = s; j < e; j++)
    {
        if (arr[j] < p)
        {
            i++;
            (arr[i], arr[j]) = (arr[j], arr[i]);
        }
    }
    (arr[i+1], arr[e]) = (arr[e], arr[i+1]);
    return i + 1;
}

void QuickSort_(int[] arr, int s, int e)
{
    if (s >= e)
    {
        return;
    }

    int p = Partition(arr, s, e);

    QuickSort_(arr, 0, p - 1);
    QuickSort_(arr, p + 1, e);
}

void QuickSort(int[] arr)
{
    if( arr == null || arr.Length < 2)
    {
        return;
    }

    QuickSort_(arr, 0, arr.Length - 1);
}

int[] FindOriginalArray2(int[] changed)
{
    if (changed == null || changed.Length < 2 || (changed.Length & 1) == 1)
    {
        return new int[0];
    }

    QuickSort(changed);

    int k = -1;
    bool[] originals = new bool[changed.Length];
    int[] res = new int[changed.Length / 2];
    for (int i = changed.Length - 1; k < changed.Length / 2 && i > 0; i--)
    {
        if (originals[i])
        {
            continue;
        }
        if ((changed[i] & 1) == 1)
        {
            return new int[0];
        }
        bool found = false;
        for (int j = i - 1; j >= 0; j--)
        {
            if (originals[j])
            {
                continue;
            }
            var doubled = changed[j] * 2;
            if (doubled == changed[i])
            {
                k++;
                originals[j] = true;
                res[k] = changed[j];
                found = true;
                break;
            }
            else if (doubled < changed[i])
            {
                return new int[0];
            }
        }
        if (!found)
        {
            return new int[0];
        }
    }

    return res;
}

int[] FindOriginalArray3(int[] changed)
{
    if (changed == null || changed.Length < 2 || (changed.Length & 1) == 1)
    {
        return new int[0];
    }

    QuickSort(changed);
    LinkedList<int> sorted = new LinkedList<int>(changed);

    int k = -1;
    int[] res = new int[changed.Length / 2];
    while(sorted.Count > 0)
    {
        var original = sorted.First;
        int doubled = original.Value * 2;

        var current = original.Next;
        bool found = false;
        while(current != null)
        {
            if( doubled == current.Value)
            {
                k++;
                res[k] = original.Value;
                sorted.Remove(original);
                sorted.Remove(current);
                found = true;
                break;
            }
            else
            {
                if( doubled < current.Value)
                {
                    return new int[0];
                }
                current = current.Next;
            }
        }
        if( !found)
        {
            return new int[0];
        }
    }

    return res;
}

int[] FindOriginalArray(int[] changed)
{
    if (changed == null || changed.Length < 2 || (changed.Length & 1) == 1)
    {
        return new int[0];
    }

    var d = new Dictionary<int, int>();
    foreach (int i in changed)
    {
        if (d.TryGetValue(i, out int v))
        {
            d[i] = v + 1;
        }
        else
        {
            d.Add(i, 1);
        }
    }

    var sorted = changed.ToList();
    sorted.Sort();

    int k = -1;
    int[] res = new int[changed.Length / 2];

    foreach(int i in sorted)
    {
        if( d[i] == 0)
        {
            continue;
        }
        if ( !d.TryGetValue(i * 2, out int v))
        {
            return new int[0];
        }
        if ( d[i] > v)
        {
            return new int[0];
        }
        k++;
        res[k] = i;
        if (i == 0)
        {
            if( v < 2)
            {
                return new int[0];
            }
            d[i] = v - 2;
        }
        else
        {
            d[i * 2] = v - 1;
            d[i] = d[i] - 1;
        }
    }

    return res;
}

var arr = new int[] { 0, 1, 0, 0 };
Console.Write("[" + string.Join(", ", arr) + "]");
arr = FindOriginalArray(arr);
Console.WriteLine(" - [" + string.Join(", ", arr) + "]");

arr = new int[] { 1, 3, 4, 2, 6, 8 };
Console.Write("[" + string.Join(", ", arr) + "]");
arr = FindOriginalArray(arr);
Console.WriteLine(" - [" + string.Join(", ", arr) + "]");

arr = new int[] { 1};
Console.Write("[" + string.Join(", ", arr) + "]");
arr = FindOriginalArray(arr);
Console.WriteLine(" - [" + string.Join(", ", arr) + "]");


arr = new int[] { 0, 3, 2, 4, 6, 0 };
Console.Write("[" + string.Join(", ", arr) + "]");
arr = FindOriginalArray(arr);
Console.WriteLine(" - [" + string.Join(", ", arr) + "]");

arr = new int[] { 3, 3, 3, 3 };
Console.Write("[" + string.Join(", ", arr) + "]");
arr = FindOriginalArray(arr);
Console.WriteLine(" - [" + string.Join(", ", arr) + "]");

/*
var arr = new int[] { 1, 3, 4, 2, 6, 8 };
QuickSort(arr);
Console.WriteLine(string.Join(", ", arr));
*/