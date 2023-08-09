using System;
using System.Collections.Generic;

namespace Algoritmy
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Binary_Search binarySearch = new Binary_Search();
            IList<int> myList = new List<int> {1, 2, 3, 4, 5};
            Console.WriteLine(binarySearch.BinarySearch(myList, 3).ToString());
        }
    }
}