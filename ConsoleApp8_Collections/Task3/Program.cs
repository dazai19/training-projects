using System;
using System.Collections.Generic;

namespace Task3
{
    internal static class Program
    {
        public static void Main()
        {
            HashSet<int> hashSet = new HashSet<int>();
            while (true)
            {
                Console.Write("Input value: ");
                int num = int.Parse(Console.ReadLine() ?? "0");
                if (hashSet.Contains(num))
                {
                    Console.WriteLine("The number is present in the collection");
                }
                else
                {
                    hashSet.Add(num);
                    Console.WriteLine("Number added to the collection");
                }
                Console.WriteLine("continue? y/n");
                string check = Console.ReadLine();
                if(check == "n") break;
            }
        }
    }
}