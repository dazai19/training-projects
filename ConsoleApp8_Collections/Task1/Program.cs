using System;
using System.Collections.Generic;

namespace ConsoleApp8_Collections
{
    internal class Program
    {
        public static void Main()
        {
            List<int> list = new List<int>();

            CompletionList(list);
            
            ShowList(list);

            RemoveItem(list);

            ShowList(list);
        }
        
        private static void ShowList(List<int> list)
        {
            Console.WriteLine($"\nList count: {list.Count}");
            foreach (int item in list)
            {
                Console.Write($"{item.ToString()} ");
            }
        }
        private static void CompletionList(List<int> list)
        {
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                list.Add(rand.Next(0,100));
            }
        }
        private static void RemoveItem(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > 25 && list[i] < 50)
                {
                    list.Remove(i);
                }
            }
        }
    }
}