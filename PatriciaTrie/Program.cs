using System;
using PatriciaTrieLib;

namespace PatriciaTrie
{
    class Program
    {
        static void Main(string[] args)
        {
            var patriciaTrie = new PatriciaTrieLib.PatriciaTrie();

            while (true)
            {
                Console.WriteLine("1. Вставить");
                Console.WriteLine("2. Найти");
                Console.WriteLine("3. Удалить");
                Console.WriteLine("4. Показать дерево");
                var action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        Console.WriteLine("Введите ключ:");
                        patriciaTrie.Insert(Console.ReadLine(), 0);
                        break;
                    case "2":
                        Console.WriteLine("Введите ключ:");
                        Console.WriteLine(patriciaTrie.Lookup(Console.ReadLine()));
                        break;
                    case "3":
                        Console.WriteLine("Введите ключ:");
                        Console.WriteLine(patriciaTrie.Delete(Console.ReadLine()));
                        break;
                    case "4":
                        Console.WriteLine(patriciaTrie);
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
