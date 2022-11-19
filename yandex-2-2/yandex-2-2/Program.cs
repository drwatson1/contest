bool foo(string s1, string s2)
{
    if( Math.Abs(s1.Length - s2.Length) > 1 )
    {
        return false;
    }

    if (s1.Length < s2.Length)
    {
        (s1, s2) = (s2, s1);
    }

    if (s1.Length > s2.Length) // del
    {
        int c = 0;
        int i = 0;

        while(c < 2 && i < s2.Length)
        {
            if (s1[i+c] != s2[i])
            {
                c++;
            }
            else
            {
                i++;
            }
        }
        return c < 2;
    }

    {
        int c = 0;
        int i = 0;
        while (c < 2 && i < s1.Length)
        {
            if (s2[i] != s1[i])
            {
                ++c;
            }
            i++;
        }
        return c < 2;
    }
}

(string s1, string s2) s;

s = ("s", "");
Console.WriteLine($"{s.s1} - {s.s2} -> {foo(s.s1, s.s2)}");
s = ("cats", "cat");
Console.WriteLine($"{s.s1} - {s.s2} -> {foo(s.s1, s.s2)}");
s = ("cat", "at");
Console.WriteLine($"{s.s1} - {s.s2} -> {foo(s.s1, s.s2)}");
s = ("cat", "ct");
Console.WriteLine($"{s.s1} - {s.s2} -> {foo(s.s1, s.s2)}");
s = ("cats", "cam");
Console.WriteLine($"{s.s1} - {s.s2} -> {foo(s.s1, s.s2)}");
s = ("cats", "mat");
Console.WriteLine($"{s.s1} - {s.s2} -> {foo(s.s1, s.s2)}");

s = ("cat", "cats");
Console.WriteLine($"{s.s1} - {s.s2} -> {foo(s.s1, s.s2)}");
s = ("cat", "scat");
Console.WriteLine($"{s.s1} - {s.s2} -> {foo(s.s1, s.s2)}");
s = ("cat", "csat");
Console.WriteLine($"{s.s1} - {s.s2} -> {foo(s.s1, s.s2)}");
s = ("cat", "cass");
Console.WriteLine($"{s.s1} - {s.s2} -> {foo(s.s1, s.s2)}");

s = ("cat", "rat");
Console.WriteLine($"{s.s1} - {s.s2} -> {foo(s.s1, s.s2)}");
s = ("cat", "crt");
Console.WriteLine($"{s.s1} - {s.s2} -> {foo(s.s1, s.s2)}");
s = ("cat", "car");
Console.WriteLine($"{s.s1} - {s.s2} -> {foo(s.s1, s.s2)}");
s = ("cat", "crm");
Console.WriteLine($"{s.s1} - {s.s2} -> {foo(s.s1, s.s2)}");
s = ("cat", "mar");
Console.WriteLine($"{s.s1} - {s.s2} -> {foo(s.s1, s.s2)}");
