using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Algoritmy
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] myArr = new[] { 8, 2, 4, 1, 3, 5 };
            Selection_Sort selectionSort = new Selection_Sort();
            selectionSort.SelectionSort(myArr);
            
            foreach (var m in myArr)
            {
                Console.Write(m + " ");
            }
        }
    }
}