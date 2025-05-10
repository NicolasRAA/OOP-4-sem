using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int n = 100;
        int length = 4;

        // using only 5 letters of the alphabet
        string[] stringArray = GenerateRandomStrings(n, length);

        Console.WriteLine($"Strings({n}): {string.Join(" ", stringArray)}");

        int p = 31;
        int m = length; 
        int[] p_pow = new int[m];
        p_pow[0] = 1;
        for (int i = 1; i < m; i++)
        {
            p_pow[i] = p_pow[i - 1] * p;
        }

        var hashs = new Dictionary<int, int>();
        for (int i = 0; i < n; i++)
        {
            hashs[i] = 0;
            for (int j = 0; j < stringArray[i].Length; j++)
            {
                hashs[i] += (stringArray[i][j] - 'a' + 1) * p_pow[j];
            }
        }

        Console.WriteLine("\nHash numbers and hashes:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"{i + 1} {hashs[i]}");
        }

        var hashGroups = hashs.GroupBy(pair => pair.Value)
                              .OrderBy(group => group.First().Key)
                              .ToList();

        Console.WriteLine("\nGroups of equal hashes:");
        for (int i = 0; i < hashGroups.Count; i++)
        {
            Console.Write($"Group {i + 1}: ");
            Console.WriteLine(string.Join(" ", hashGroups[i].Select(pair => pair.Key + 1)));
        }
    }

    static string[] GenerateRandomStrings(int n, int length)
    {
        Random random = new Random();
        string[] strings = new string[n];
        for (int i = 0; i < n; i++)
        {
            strings[i] = GenerateRandomString(length, random);
        }
        return strings;
    }

    static string GenerateRandomString(int length, Random random)
    {
        const string chars = "abc"; 
        char[] stringChars = new char[length];
        for (int i = 0; i < length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }
        return new string(stringChars);
    }
}
