using System;
using System.Collections.Generic;

namespace LAB06_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Sorter mySorter1 = new Sorter();
            mySorter1.SetAlgorithm(new InsertionSort());
            var myList1 = new List<int>() { 6, 2, 3, 5, 1 };
            myList1 = mySorter1.Sort(myList1);
            foreach (int i in myList1) Console.WriteLine(i);


            Console.WriteLine("");
            Sorter mySorter2 = new Sorter();
            mySorter1.SetAlgorithm(new SelectionSort());
            var myList2 = new List<int>() { 6, 2, 3, 5, 1 };
            myList1 = mySorter1.Sort(myList1);
            foreach (int i in myList1) Console.WriteLine(i);

        }
    }
}
