using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the pattern S:");
        string s = Console.ReadLine();

        Console.WriteLine("Enter the text T:");
        string t = Console.ReadLine();

        RabinKarp(s, t);
    }

    static void RabinKarp(string s, string t)
    {
        int p = 31; 
        int n = s.Length; // Length pattern S
        int m = t.Length; // Length text T

        // powers of p
        int[] p_pow = new int[Math.Max(n, m)];
        p_pow[0] = 1;
        for (int i = 1; i < p_pow.Length; i++)
        {
            p_pow[i] = p_pow[i - 1] * p;
        }

        // hash S
        int s_hash = 0;
        for (int i = 0; i < n; i++)
        {
            s_hash += (s[i] - 'a' + 1) * p_pow[i];
        }

        // hashes prefixes T
        int[] t_hashes = new int[m];
        for (int i = 0; i < m; i++)
        {
            t_hashes[i] = (t[i] - 'a' + 1) * p_pow[i];
            if (i > 0)
            {
                t_hashes[i] += t_hashes[i - 1];
            }
        }

        // occurrences of S in T
        Console.WriteLine("\nPositions where S appears in T:");
        for (int i = 0; i <= m - n; i++)
        {
            int current_hash = t_hashes[i + n - 1];
            if (i > 0)
            {
                current_hash -= t_hashes[i - 1];
            }

            if (current_hash == s_hash * p_pow[i])
            {
                // if strings are actually equal (handle hash collisions)
                bool match = true;
                for (int j = 0; j < n; j++)
                {
                    if (s[j] != t[i + j])
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
