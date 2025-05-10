using System;

namespace Tree
{
    class Tree
    {
        public Tree Left;
        public Tree Right;
        public char Value;

        public static List<char> list = new List<char>();
        public static int index = 0; 

        public Tree(char value)
        {
            Value = value;
        }

        public static Tree Build(List<char> nodes)
        {
            if (index >= nodes.Count) return null;

            char current = nodes[index++];
            if (current == '.') return null;

            Tree node = new Tree(current);
            node.Left = Build(nodes);
            node.Right = Build(nodes);
            return node;
        }

        public static void TreeWalk_Pr(Tree node)
        {
            if (node == null) return;
            list.Add(node.Value);
            TreeWalk_Pr(node.Left);
            TreeWalk_Pr(node.Right);
        }

        public static void TreeWalk_K(Tree node)
        {
            if (node == null) return;
            TreeWalk_K(node.Left);
            TreeWalk_K(node.Right);
            list.Add(node.Value);
        }

        public static List<char> TreeWalk_Obr(Tree node)
        {
            if (node == null) return new List<char>();
            var result = TreeWalk_Obr(node.Left);
            result.Add(node.Value);
            result.AddRange(TreeWalk_Obr(node.Right));
            return result;
        }

        public static int CalcTree(Tree node)
        {
            if (node == null) return 0;
            if (char.IsDigit(node.Value)) return node.Value - '0';
            int left = CalcTree(node.Left);
            int right = CalcTree(node.Right);
            return node.Value switch
            {
                '+' => left + right,
                '-' => left - right,
                '*' => left * right,
                '/' => right != 0 ? left / right : 0,
                _ => 0,
            };
        }

        public static void PrintTree(Tree node)
        {
            if (node == null) return;
            string left = node.Left != null ? node.Left.Value.ToString() : "null";
            string right = node.Right != null ? node.Right.Value.ToString() : "null";
            Console.WriteLine($"value: {node.Value} | left: {left} | right: {right}");
            PrintTree(node.Left);
            PrintTree(node.Right);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Árbol de letras
            List<char> chars = new List<char>() { 'a', 'b', 'd', '.', '.', 'e', '.', '.', 'c', '.', 'f', '.', '.' };
            Tree.index = 0;
            Tree.list.Clear();
            Tree tree1 = Tree.Build(chars);
            Tree.PrintTree(tree1);

            Console.WriteLine("\nStraight order (Preorden):");
            Tree.TreeWalk_Pr(tree1);
            Console.WriteLine(string.Join(" ", Tree.list));

            Tree.list.Clear();
            Console.WriteLine("\nReverse order (Inorden):");
            Tree.list = Tree.TreeWalk_Obr(tree1);
            Console.WriteLine(string.Join(" ", Tree.list));

            Tree.list.Clear();
            Console.WriteLine("\nEnd order (Postorden):");
            Tree.TreeWalk_K(tree1);
            Console.WriteLine(string.Join(" ", Tree.list));

            // Árbol de expresión
            List<char> expr = new List<char>() {
                '/', '*', '+', '2', '.', '.', '3', '.', '.', '-', '7', '.', '.', '4', '.', '.', '3', '.', '.'
            };
            Console.WriteLine();
            Tree.index = 0;
            Tree.list.Clear();
            Tree tree2 = Tree.Build(expr);
            Tree.PrintTree(tree2);

            Console.WriteLine("\nEnd order:");
            Tree.TreeWalk_K(tree2);
            Console.WriteLine(string.Join(" ", Tree.list));

            Console.WriteLine("\nThe equation equals:");
            Console.WriteLine(Tree.CalcTree(tree2));
        }
    }

}
