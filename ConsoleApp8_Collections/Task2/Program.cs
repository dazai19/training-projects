using System;
using System.Collections.Generic;

namespace Task2
{
    internal class Program
    {
        public static void Main()
        {
            Dictionary<string, string> pnBook = new Dictionary<string, string>();

            EnterKeyValueOn(pnBook);

            foreach (KeyValuePair<string, string> pair in pnBook)
            {
                Console.WriteLine(pair);
            }

            Console.WriteLine("Search F.I.O by phone number: ");
            SearchInList(pnBook, Console.ReadLine());
        }

        private static void EnterKeyValueOn(Dictionary<string, string> list)
        {
            while (true)
            {
                string pnNmber, pnName;
                Console.WriteLine("Enter phone number - ");
                Console.Write("+7");
                pnNmber = Console.ReadLine();
                if (pnNmber == "") break;
                pnNmber = "+7" + pnNmber;
                Console.WriteLine("Enter F.I.O user - ");
                pnName = Console.ReadLine();
                list.Add(pnNmber, pnName);
            }
        }

        private static void SearchInList(Dictionary<string, string> list, string searchKey)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("The list is empty");
            }
            else
            {
                string value;
                if (list.TryGetValue(searchKey, out value))
                {
                    Console.WriteLine("Phone number = {0} | F.I.O = {1}", searchKey, value);
                }
                else
                {
                    Console.WriteLine("Phone number = {0} is not found.", searchKey);
                }
            }
        }
    }
}