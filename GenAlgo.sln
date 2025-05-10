using System;
using System.Security.Cryptography.X509Certificates;

class Generation
{
    public int a;
    public int b;
    public int c;
    public int d;
    public static Random r = new Random();
    public int ex_res; //ожидаемый результат
    public Func<int, int, int, int, int> f;
    private int? real_res; //получаемый результат
    public int RealResult
    {
        get
        {
            if (real_res == null)
            {
                real_res = f(a, b, c, d);
            }
            return (int)real_res;
        }
    }
    public Generation(Func<int, int, int, int, int> f, int a, int b, int c, int d, int ex_res)
    {
        this.f = f;
        this.a = a;
        this.b = b;
        this.c = c;
        this.d = d;
        this.ex_res = ex_res;
    }
    public static Generation NewGen(Generation p1, Generation p2)
    {
        int x = r.Next(1, 4);
        switch (x)
        {
            case 1: return new Generation(p1.f, p1.a, p1.b, p2.c, p2.d, p2.ex_res);
            case 2: return new Generation(p1.f, p1.a, p2.b, p2.c, p2.d, p2.ex_res);
            case 3: return new Generation(p1.f, p1.a, p1.b, p1.c, p2.d, p2.ex_res);
            default: return null;
        }
    }
    public void Change()
    {
        int imposter = r.Next(1, 5);
        switch (imposter)
        {
            case 1:
                a = r.Next(1, 50);
                break;
            case 2:
                b = r.Next(1, 50);
                break;
            case 3:
                c = r.Next(1, 50);
                break;
            case 4:
                d = r.Next(1, 50);
                break;
            default:
                break;
        }
    }
    public int GetAc()
    {
        return Math.Abs((int)(ex_res - RealResult));
    }
    public static double SrKoef(List<Generation> generations)
    {
        double sum = 0;
        foreach (Generation item in generations)
        {
            sum += item.GetAc();
        }
        return sum / generations.Count();
    }
}

class Program
{
    public static int res = 30;
    public static Func<int, int, int, int, int> f = (a, b, c, d) => a + 2 * b + 3 * c + 4 * d;
    public static Random r = new Random();

    static void Main(string[] args)
    {
        List<Generation> generations = new List<Generation>();
        for (int i = 0; i < 5; i++)
        {
            generations.Add(new Generation(f, r.Next(1, 30), r.Next(1, 30), r.Next(1, 30), r.Next(1, 30), res));
        }

        List<Generation> initialPopulation = generations
            .Select(g => new Generation(g.f, g.a, g.b, g.c, g.d, g.ex_res))
            .ToList();

        for (int i = 0; ; i++)
        {
            Console.WriteLine("Iteration " + (i + 1));
            foreach (var item in generations)
            {
                Console.WriteLine("a = " + item.a + " | b = " + item.b + " | c = " + item.c + " | d = " + item.d);
            }
            Console.WriteLine("---");

            double koef1 = Generation.SrKoef(generations);
            var best = generations
                .OrderBy(g => g.GetAc())
                .ToList();
            var match = best.FirstOrDefault(g => g.RealResult == res);
            if (match != null)
            {
                Solution(match, i);
                break;
            }

            generations.Clear();
            generations.Add(Generation.NewGen(best[0], best[1]));
            generations.Add(Generation.NewGen(best[1], best[0]));
            generations.Add(Generation.NewGen(best[0], best[2]));
            generations.Add(Generation.NewGen(best[2], best[0]));
            generations.Add(Generation.NewGen(best[1], best[2]));

            double koef2 = Generation.SrKoef(generations);
            if (koef2 <= koef1)
            {
                int x = r.Next(1, 5);
                for (int j = 0; j < x; j++)
                {
                    generations[r.Next(0, 5)].Change();
                }
            }
        }

        PrintPopulation(initialPopulation, "Initial Population");
        PrintPopulation(generations, "Final Population");
    }

    public static void PrintPopulation(List<Generation> gens, string title)
    {
        Console.WriteLine($"\n{title}");
        foreach (var g in gens)
        {
            Console.WriteLine($"a = {g.a} | b = {g.b} | c = {g.c} | d = {g.d} | Value = {g.RealResult}");
        }
    }

    public static void Solution(Generation g, int iteration)
    {
        Console.WriteLine("\nSolution found in " + (iteration + 1) + " iterations:");
        Console.WriteLine("a = " + g.a + " | b = " + g.b + " | c = " + g.c + " | d = " + g.d);

        int part1 = g.a;
        int part2 = 2 * g.b;
        int part3 = 3 * g.c;
        int part4 = 4 * g.d;
        int result = part1 + part2 + part3 + part4;

        Console.WriteLine("\nValue verification:");
        Console.WriteLine($"{g.a} + 2 * {g.b} + 3 * {g.c} + 4 * {g.d} |=> {part1} + {part2} + {part3} + {part4} = {result}\n");
    }
}
